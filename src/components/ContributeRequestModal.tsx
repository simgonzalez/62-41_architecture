import React, { useState, useEffect } from "react";
import { StyleSheet, ScrollView, View, Alert } from "react-native";
import {
  Modal,
  Portal,
  Text,
  Button,
  useTheme,
  Card,
  Divider,
} from "react-native-paper";
import { RequestWithFulfillmentStatus } from "@hooks/useFoodRequests";
import { FridgeItemService } from "@services/FridgeItemService";
import { FridgeItem } from "@src/types/FridgeItem";
import UnitQuantitySelector from "@components/UnitQuantitySelector";
import { Quantity } from "@src/types/Quantity";
import { useFridgeItems } from "@contexts/FridgeItemsContext";

interface ContributeRequestModalProps {
  visible: boolean;
  request: RequestWithFulfillmentStatus | null;
  onClose: () => void;
}

const ContributeRequestModal: React.FC<ContributeRequestModalProps> = ({
  visible,
  request,
  onClose,
}) => {
  const theme = useTheme();
  const [availableItems, setAvailableItems] = useState<FridgeItem[]>([]);
  const [contributions, setContributions] = useState<Map<number, Quantity>>(
    new Map()
  );
  const [isSubmitting, setIsSubmitting] = useState(false);
  const { markAsDirty } = useFridgeItems();

  useEffect(() => {
    if (request && visible) {
      const fridgeItems = FridgeItemService.getAll();

      const matching = fridgeItems.filter((fridgeItem) =>
        request.items.some(
          (requestItem) =>
            fridgeItem.food.ingredientOpenMealDbName.toLowerCase() ===
            requestItem.food.ingredientOpenMealDbName.toLowerCase()
        )
      );

      setAvailableItems(matching);

      const initialContributions = new Map<number, Quantity>();
      request.items
        .filter((item) => request.fulfillableItems.includes(item.id))
        .forEach((item) => {
          initialContributions.set(item.id, { ...item.quantity });
        });

      setContributions(initialContributions);
    }
  }, [request, visible]);

  const handleQuantityChange = (itemId: number, quantity: Quantity) => {
    setContributions(new Map(contributions.set(itemId, quantity)));
  };

  const handleSubmit = async () => {
    if (!request) return;

    setIsSubmitting(true);
    try {
      const contributedItems = Array.from(contributions.entries());

      for (const [itemId, quantity] of contributedItems) {
        const requestItem = request.items.find((item) => item.id === itemId);
        if (!requestItem) continue;

        const matchingFridgeItem = availableItems.find(
          (item) =>
            item.food.ingredientOpenMealDbName.toLowerCase() ===
            requestItem.food.ingredientOpenMealDbName.toLowerCase()
        );

        if (matchingFridgeItem) {
          const newQuantity =
            matchingFridgeItem.quantity.value - quantity.value;

          if (newQuantity <= 0) {
            await FridgeItemService.delete(matchingFridgeItem.id);
          } else {
            await FridgeItemService.update(matchingFridgeItem.id, {
              ...matchingFridgeItem,
              quantity: {
                ...matchingFridgeItem.quantity,
                value: newQuantity,
              },
            });
          }
        }
      }

      markAsDirty();

      Alert.alert(
        "Contribution Successful",
        "Thank you for your contribution!",
        [{ text: "OK", onPress: onClose }]
      );
    } catch (error) {
      console.error("Error submitting contribution:", error);
      Alert.alert("Error", "Failed to submit your contribution");
    } finally {
      setIsSubmitting(false);
    }
  };

  if (!request) return null;

  return (
    <Portal>
      <Modal
        visible={visible}
        onDismiss={onClose}
        contentContainerStyle={[
          styles.modalContainer,
          { backgroundColor: theme.colors.background },
        ]}
      >
        <ScrollView>
          <Text variant="titleLarge" style={styles.title}>
            Contribute to Request
          </Text>
          <Text variant="titleMedium">{request.title}</Text>
          <Text variant="bodyMedium" style={styles.organization}>
            {request.organization}
          </Text>

          <Divider style={styles.divider} />

          <Text variant="titleSmall" style={styles.sectionTitle}>
            Items you can contribute:
          </Text>

          {request.items
            .filter((item) => request.fulfillableItems.includes(item.id))
            .map((item) => {
              const contribution = contributions.get(item.id);
              if (!contribution) return null;

              return (
                <Card key={item.id} style={styles.itemCard}>
                  <Card.Content>
                    <Text variant="bodyLarge">{item.food.name}</Text>
                    <Text variant="bodyMedium" style={styles.requestedAmount}>
                      Requested: {item.quantity.value} {item.quantity.unit}
                    </Text>
                    <Text variant="bodySmall" style={styles.label}>
                      Your contribution:
                    </Text>
                    <UnitQuantitySelector
                      quantity={contribution}
                      setQuantity={(q) => handleQuantityChange(item.id, q)}
                    />
                  </Card.Content>
                </Card>
              );
            })}

          <View style={styles.buttons}>
            <Button
              mode="outlined"
              onPress={onClose}
              style={[styles.button, styles.cancelButton]}
            >
              Cancel
            </Button>
            <Button
              mode="contained"
              onPress={handleSubmit}
              style={styles.button}
              loading={isSubmitting}
              disabled={isSubmitting}
            >
              Contribute
            </Button>
          </View>
        </ScrollView>
      </Modal>
    </Portal>
  );
};

const styles = StyleSheet.create({
  modalContainer: {
    padding: 20,
    margin: 20,
    borderRadius: 8,
    maxHeight: "80%",
  },
  title: {
    marginBottom: 8,
  },
  organization: {
    opacity: 0.7,
    marginTop: 4,
  },
  divider: {
    marginVertical: 16,
  },
  sectionTitle: {
    marginBottom: 12,
  },
  itemCard: {
    marginBottom: 12,
  },
  requestedAmount: {
    marginTop: 4,
    marginBottom: 12,
  },
  label: {
    marginBottom: 8,
  },
  buttons: {
    flexDirection: "row",
    justifyContent: "space-between",
    marginTop: 16,
  },
  button: {
    flex: 1,
    marginHorizontal: 4,
  },
  cancelButton: {
    borderColor: "gray",
  },
});

export default ContributeRequestModal;
