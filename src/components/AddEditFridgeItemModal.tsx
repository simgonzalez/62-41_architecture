import React, { useEffect, useState } from "react";
import { StyleSheet, ScrollView } from "react-native";
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
          const fridgeData = await FridgeService.getById(fridgeItem.fridgeId);
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
            fridgeId: fridgeItem.fridgeId,
            food: newItemFood,
            quantity: newItemQuantity,
            expirationDate: newItemExpirationDate.toISOString(),
          };

          FridgeItemService.update(updatedItem.id, updatedItem);
        } else {
          await handleSaveItem(newItemFood);
        }

        onModalClose();
      } catch (error) {
        console.error("Error saving item:", error);
      } finally {
        setIsSubmitting(false);
      }
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
              {fridgeItem?.id ? "Edit" : "Add"} Fridge Item
            </Text>
            <TextInput
              label="Fridge"
              value={fridge?.name || ""}
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
            <Button
              mode="contained"
              onPress={onSave}
              style={styles.saveButton}
              loading={isSubmitting}
              disabled={isSubmitting || !newItemFood}
            >
              Save
            </Button>
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
  saveButton: {
    marginTop: 20,
  },
});

export default AddEditFridgeItemModal;
