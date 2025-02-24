import React from "react";
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
import TheMealDbIngredientSelector from "@components/TheMealDbIngredientSelector";
import { DatePickerInput } from "react-native-paper-dates";
import useIngredientSelection from "@hooks/useIngredientSelection";
import useCreateItem from "@hooks/useCreateItem";
import UnitQuantitySelector from "@components/UnitQuantitySelector";

interface AddItemModalProps {
  visible: boolean;
  onDismiss: () => void;
  fridge: Fridge;
  onItemAdded: () => void;
}

const AddItemModal: React.FC<AddItemModalProps> = React.memo(
  ({ visible, onDismiss, fridge, onItemAdded }) => {
    const theme = useTheme();
    const { newItemFood, handleSelectIngredient } = useIngredientSelection();
    const {
      newItemQuantity,
      setNewItemQuantity,
      newItemUnit,
      setNewItemUnit,
      newItemExpirationDate,
      setNewItemExpirationDate,
      handleSaveItem,
    } = useCreateItem(fridge, onDismiss, onItemAdded);

    return (
      <Portal>
        <Modal
          visible={visible}
          onDismiss={onDismiss}
          contentContainerStyle={[
            styles.modalContainer,
            { backgroundColor: theme.colors.background },
          ]}
        >
          <ScrollView>
            <Text variant="titleLarge" style={[styles.title]}>
              Add New Item
            </Text>
            <TextInput
              label="Fridge"
              value={fridge.name}
              disabled
              style={styles.input}
            />
            <TheMealDbIngredientSelector
              onSelectIngredient={handleSelectIngredient}
            />
            <UnitQuantitySelector
              quantity={newItemQuantity}
              setQuantity={setNewItemQuantity}
              unit={newItemUnit}
              setUnit={setNewItemUnit}
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
              onPress={() => handleSaveItem(newItemFood)}
              style={styles.saveButton}
            >
              Save
            </Button>
          </ScrollView>
        </Modal>
      </Portal>
    );
  }
);

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

export default AddItemModal;
