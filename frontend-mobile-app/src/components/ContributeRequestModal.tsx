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
import ApiService from "@services/ApiService";
import { FridgeItem } from "@src/types/FridgeItem";
import UnitQuantitySelector from "@components/UnitQuantitySelector";
import { Unit } from "@src/types/Unit";
import { useFridgeItemsContext } from "@contexts/FridgeItemsContext";
import { RequestService } from "@src/services/RequestService";

interface ContributeRequestModalProps {
  visible: boolean;
  request: RequestWithFulfillmentStatus | null;
  onClose: () => void;
}

// Define a new local type for contributions
interface Contribution {
  quantity: number;
  unit: Unit;
}

const ContributeRequestModal: React.FC<ContributeRequestModalProps> = ({
  visible,
  request,
  onClose,
}) => {
  const theme = useTheme();
  const [availableItems, setAvailableItems] = useState<FridgeItem[]>([]);
  // Update contributions state type:
  const [contributions, setContributions] = useState<Map<number, Contribution>>(
    new Map()
  );
  const [isSubmitting, setIsSubmitting] = useState(false);
  const { markAsDirty } = useFridgeItemsContext();

  useEffect(() => {
    const fetchFridgeItems = async () => {
      try {
        const items = await ApiService.getUserFridgeItems();
        setAvailableItems(items);
      } catch {
        setAvailableItems([]);
      }
    };
    fetchFridgeItems();
  }, [request, visible]);

  // Update initialization: preselect contribution using availableItems (if matching)
  useEffect(() => {
    if (request && visible) {
      const initialContributions = new Map<number, Contribution>();
      request.items
        .filter((item) => request.fulfillableItems.includes(item.id))
        .forEach((item) => {
          const matchingItem = availableItems.find(
            (fridgeItem) =>
              fridgeItem.food.ingredientOpenMealDbName.toLowerCase() ===
              item.food.ingredientOpenMealDbName.toLowerCase()
          );
          if (matchingItem) {
            initialContributions.set(item.id, {
              quantity: matchingItem.quantity,
              unit: { ...matchingItem.unit },
            });
          } else {
            // fallback: use request item unit with 0 quantity
            initialContributions.set(item.id, {
              quantity: 0,
              unit: { ...item.unit },
            });
          }
        });
      setContributions(initialContributions);
    }
  }, [request, visible, availableItems]);

  // Update quantity change handler to work with Contribution
  const handleQuantityChange = (itemId: number, newContribution: Contribution) => {
    setContributions(new Map(contributions.set(itemId, newContribution)));
  };

  const handleSubmit = async () => {
    if (!request) return;

    setIsSubmitting(true);
    try {
      // Prepare contributions for API
      const contributedItems = Array.from(contributions.entries())
        .filter(([_, c]) => c.quantity > 0)
        .map(([itemId, c]) => {
          const requestItem = request.items.find((item) => item.id === itemId);
          if (!requestItem) return null;
          return {
            food_id: requestItem.food.id,
            quantity: c.quantity,
            unit_id: c.unit.id,
          };
        })
        .filter((item): item is { food_id: number; quantity: number; unit_id: number } => item !== null);

      if (contributedItems.length === 0) {
        Alert.alert("No Contribution", "Please select at least one item to contribute.");
        setIsSubmitting(false);
        return;
      }

      // Call backend endpoint
      await RequestService.contributeToRequest(request.id, contributedItems);
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
          <Text variant="titleMedium">{request.name}</Text>
          <Text variant="bodyMedium" style={styles.organization}>
            {request.organizationName}
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
                      Requested: {item.quantity} {item.unit.code}
                    </Text>
                    <Text variant="bodySmall" style={styles.label}>
                      Your contribution:
                    </Text>
                    <UnitQuantitySelector
                      quantity={contribution.quantity}
                      setQuantity={(q) =>
                        handleQuantityChange(item.id, { ...contribution, quantity: q })
                      }
                      unit={contribution.unit}
                      setUnit={(unit: Unit) =>
                        handleQuantityChange(item.id, { ...contribution, unit })
                      }
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
