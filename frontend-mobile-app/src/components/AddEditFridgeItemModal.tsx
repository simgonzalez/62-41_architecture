import React, { useEffect, useState } from "react";
import { StyleSheet, ScrollView, View, Alert } from "react-native";
import {
  Modal,
  Portal,
  Text,
  TextInput,
  Button,
  useTheme,
} from "react-native-paper";
import { Fridge } from "@src/types/Fridge";
import { FridgeItem } from "@src/types/FridgeItem";
import TheMealDbIngredientSelector from "@components/TheMealDbIngredientSelector";
import { DatePickerInput } from "react-native-paper-dates";
import useIngredientSelection from "@hooks/useIngredientSelection";
import useSaveItem from "@hooks/useSaveItem";
import UnitQuantitySelector from "@components/UnitQuantitySelector";
import { FridgeService } from "@services/FridgeService";
import { FridgeItemService } from "@services/FridgeItemService";
import { useFridgeItemsContext } from "@contexts/FridgeItemsContext";

interface AddEditFridgeItemModalProps {
  visible: boolean;
  fridgeItem: FridgeItem;
  onModalClose: () => void;
}

const AddEditFridgeItemModal: React.FC<AddEditFridgeItemModalProps> =
  React.memo(({ visible, fridgeItem, onModalClose }) => {
    const theme = useTheme();
    const [fridge, setFridge] = useState<Fridge | null>(null);
    const [isSubmitting, setIsSubmitting] = useState(false);

    const { newItemFood, setNewItemFood } = useIngredientSelection(fridgeItem?.food);
    const { markAsDirty } = useFridgeItemsContext();

    const {
      newItemQuantity,
      setNewItemQuantity,
      newItemUnit,
      setNewItemUnit,
      newItemExpirationDate,
      setNewItemExpirationDate,
      handleSaveItem,
    } = useSaveItem(fridge, onModalClose, fridgeItem);

    useEffect(() => {
      const loadFridge = async () => {
        if (fridgeItem) {
          // Editing existing item
          const fridgeData = await FridgeService.getById(fridgeItem.fridge.id);
          setFridge(fridgeData);
          setNewItemFood(fridgeItem.food);
          setNewItemQuantity(fridgeItem.quantity);
          setNewItemUnit(fridgeItem.unit);
          setNewItemExpirationDate(new Date(fridgeItem.expirationDate));
        } else {
          // Creating new item: set type-safe defaults
          setFridge(null);
          setNewItemFood(null); // Food | null
          setNewItemQuantity(0);
          setNewItemUnit(null); // Unit | null
          setNewItemExpirationDate(new Date());
        }
      };
      loadFridge();
    }, [fridgeItem, visible]);

    const onSave = async () => {
      if (!newItemFood || !newItemUnit) return;

      setIsSubmitting(true);
      try {
        if (fridgeItem.id > 0) {
          const updatedItem = {
            id: fridgeItem.id,
            fridge: fridgeItem.fridge,
            food: newItemFood,
            quantity: newItemQuantity,
            unit: newItemUnit,
            expirationDate: newItemExpirationDate.toISOString().slice(0, 10),
          };

          // Debug log for update payload
          console.log("FridgeItemService.update payload:", {
            fridgeId: updatedItem.fridge.id,
            itemId: updatedItem.id,
            payload: {
              food_id: updatedItem.food.id, // <-- ensure this is a valid id
              quantity: updatedItem.quantity,
              unit_id: updatedItem.unit.id, // <-- use id, not name
              expiration_date: updatedItem.expirationDate, // already YYYY-MM-DD
            },
          });

          if (!updatedItem.food.id) {
            Alert.alert("Error", "Selected food is missing an id. Please select a valid food from the list.");
            setIsSubmitting(false);
            return;
          }
          if (!updatedItem.unit.id) {
            Alert.alert("Error", "Selected unit is missing an id. Please select a valid unit.");
            setIsSubmitting(false);
            return;
          }

          await FridgeItemService.update(
            updatedItem.fridge.id,
            updatedItem.id,
            {
              food_id: updatedItem.food.id,
              quantity: updatedItem.quantity,
              unit_id: updatedItem.unit.id, // <-- use id
              expiration_date: updatedItem.expirationDate,
            }
          );
        } else {
          // Debug log for create payload
          console.log("handleSaveItem payload:", {
            food: newItemFood,
            quantity: newItemQuantity,
            unit: newItemUnit,
            expirationDate: newItemExpirationDate.toISOString().slice(0, 10),
          });
          await handleSaveItem(
            newItemFood,
            newItemQuantity,
            newItemUnit,
            // Pass only the date part as a string
            newItemExpirationDate.toISOString().slice(0, 10)
          );
        }

        markAsDirty();
        onModalClose();
      } catch (error) {
        if (error && typeof error === "object" && "details" in error) {
          console.error("Error saving item:", error, (error as any)["details"]);
        } else {
          console.error("Error saving item:", error);
        }
        Alert.alert("Error", "Could not save item. Please try again.");
      } finally {
        setIsSubmitting(false);
      }
    };

    const handleDelete = () => {
      if (!fridgeItem || fridgeItem.id <= 0) return;

      Alert.alert(
        "Delete Item",
        `Are you sure you want to delete ${fridgeItem.food.name}?`,
        [
          {
            text: "Cancel",
            style: "cancel",
          },
          {
            text: "Delete",
            onPress: () => {
              (async () => {
                try {
                  await FridgeItemService.delete(fridgeItem.fridge.id, fridgeItem.id);
                  markAsDirty();
                  onModalClose();
                } catch (error) {
                  console.error("Error deleting item:", error);
                  Alert.alert("Error", "Could not delete item");
                }
              })();
            },
            style: "destructive",
          },
        ]
      );
    };

    return (
      <Portal>
        <Modal
          visible={visible}
          onDismiss={onModalClose}
          contentContainerStyle={[
            styles.modalContainer,
            { backgroundColor: theme.colors.background },
          ]}
        >
          <ScrollView>
            <Text variant="titleLarge" style={[styles.title]}>
              {fridgeItem?.id > 0 ? "Edit" : "Add"} Fridge Item
            </Text>
            <TextInput
              label="Fridge"
              value={fridge?.name ?? ""}
              disabled
              style={styles.input}
            />
            <TheMealDbIngredientSelector
              initialFood={newItemFood}
              onSelectIngredient={(food) => {
                setNewItemFood(food);
              }}
            />
            <UnitQuantitySelector
              quantity={newItemQuantity}
              setQuantity={setNewItemQuantity}
              unit={newItemUnit}
              setUnit={setNewItemUnit}
            />
            <DatePickerInput
              locale="fr-FR"
              label="Expiration Date"
              value={newItemExpirationDate}
              onChange={(date) => date && setNewItemExpirationDate(date)}
              inputMode="start"
              style={styles.input}
              validRange={{ startDate: new Date() }}
            />
            <View style={styles.buttonContainer}>
              {fridgeItem?.id > 0 && (
                <Button
                  mode="text"
                  onPress={handleDelete}
                  style={styles.deleteButton}
                  disabled={isSubmitting}
                >
                  Delete
                </Button>
              )}
              <Button
                mode="contained"
                onPress={onSave}
                style={styles.saveButton}
                loading={isSubmitting}
                disabled={isSubmitting || !newItemFood}
              >
                Save
              </Button>
            </View>
          </ScrollView>
        </Modal>
      </Portal>
    );
  });

const styles = StyleSheet.create({
  modalContainer: {
    padding: 20,
    margin: 20,
    borderRadius: 8,
    maxHeight: "80%",
  },
  title: {
    marginBottom: 20,
  },
  input: {
    marginBottom: 10,
  },
  buttonContainer: {
    flexDirection: "row",
    justifyContent: "space-between",
    marginTop: 20,
  },
  saveButton: {
    flex: 1,
    marginLeft: 8,
  },
  deleteButton: {
    flex: 1,
    marginRight: 8,
  },
});

export default AddEditFridgeItemModal;
