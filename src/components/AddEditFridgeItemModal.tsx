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
import { useFridgeItems } from "@contexts/FridgeItemsContext";

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

    const { newItemFood, setNewItemFood, handleSelectIngredient } =
      useIngredientSelection(fridgeItem?.food);
    const { markAsDirty } = useFridgeItems();

    const {
      newItemQuantity,
      setNewItemQuantity,
      newItemExpirationDate,
      setNewItemExpirationDate,
      handleSaveItem,
    } = useSaveItem(fridge, onModalClose, fridgeItem);

    useEffect(() => {
      const loadFridge = async () => {
        if (fridgeItem) {
          const fridgeData = await FridgeService.getById(fridgeItem.fridge.id);
          setFridge(fridgeData);
          setNewItemFood(fridgeItem.food);
          setNewItemQuantity(fridgeItem.quantity);
          setNewItemExpirationDate(new Date(fridgeItem.expirationDate));
        }
      };
      loadFridge();
    }, [fridgeItem]);

    const onSave = async () => {
      if (!newItemFood) return;

      setIsSubmitting(true);
      try {
        if (fridgeItem.id > 0) {
          const updatedItem = {
            id: fridgeItem.id,
            fridge: fridgeItem.fridge,
            food: newItemFood,
            quantity: newItemQuantity,
            expirationDate: newItemExpirationDate.toISOString(),
          };

          FridgeItemService.update(updatedItem.id, updatedItem);
        } else {
          await handleSaveItem(newItemFood);
        }

        markAsDirty();
        onModalClose();
      } catch (error) {
        console.error("Error saving item:", error);
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
            onPress: async () => {
              try {
                await FridgeItemService.delete(fridgeItem.id);
                markAsDirty();
                onModalClose();
              } catch (error) {
                console.error("Error deleting item:", error);
                Alert.alert("Error", "Could not delete item");
              }
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
              onSelectIngredient={handleSelectIngredient}
            />
            <UnitQuantitySelector
              quantity={newItemQuantity}
              setQuantity={setNewItemQuantity}
            />
            <DatePickerInput
              locale="en-GB"
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
