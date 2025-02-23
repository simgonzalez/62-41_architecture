import React, { useState, useEffect, useCallback } from "react";
import { StyleSheet, View, ScrollView } from "react-native";
import {
  Modal,
  Portal,
  Text,
  TextInput,
  Button,
  Menu,
} from "react-native-paper";
import { FridgeItemService } from "@services/FridgeItemService";
import { UnitService } from "@services/UnitService";
import { Fridge } from "@src/types/Fridge";
import { Food } from "@src/types/Food";
import TheMealDbIngredientSelector from "@components/TheMealDbIngredientSelector";
import { IngredientOpenMealDb } from "@src/types/IngredientOpenMealDb";
import { addDays } from "date-fns";
import { DatePickerInput } from "react-native-paper-dates";

interface AddItemModalProps {
  visible: boolean;
  onDismiss: () => void;
  fridge: Fridge;
  onItemAdded: () => void;
}

const AddItemModal: React.FC<AddItemModalProps> = React.memo(
  ({ visible, onDismiss, fridge, onItemAdded }) => {
    const [newItemName, setNewItemName] = useState("");
    const [newItemFood, setNewItemFood] = useState<Food>({
      id: 0,
      name: "",
      ingredientOpenMealDbName: "",
    });
    const [newItemQuantity, setNewItemQuantity] = useState(500);
    const [newItemUnit, setNewItemUnit] = useState("gr");
    const [newItemExpirationDate, setNewItemExpirationDate] = useState(
      addDays(new Date(), 7)
    );
    const [menuVisible, setMenuVisible] = useState(false);
    const [units, setUnits] = useState<string[]>([]);

    useEffect(() => {
      const fetchUnits = async () => {
        const availableUnits = await UnitService.getUnits();
        setUnits(availableUnits);
      };

      fetchUnits();
    }, []);

    const handleSaveItem = useCallback(async () => {
      const newItem = {
        id: 0,
        name: newItemName,
        food: newItemFood,
        quantity: newItemQuantity,
        unit: newItemUnit,
        expirationDate: newItemExpirationDate,
        fridgeId: fridge.id,
      };
      FridgeItemService.addItem(newItem);
      setNewItemName("");
      setNewItemFood({ id: 0, name: "", ingredientOpenMealDbName: "" });
      setNewItemQuantity(1);
      setNewItemUnit("gr");
      setNewItemExpirationDate(addDays(new Date(), 7));
      onDismiss();
      onItemAdded();
    }, [
      newItemName,
      newItemFood,
      newItemQuantity,
      newItemUnit,
      newItemExpirationDate,
      fridge.id,
      onDismiss,
      onItemAdded,
    ]);

    const handleSelectIngredient = useCallback(
      (ingredient: IngredientOpenMealDb) => {
        setNewItemFood({
          id: ingredient.idIngredient,
          name: ingredient.strIngredient,
          ingredientOpenMealDbName: ingredient.strIngredient,
        });
      },
      []
    );

    return (
      <Portal>
        <Modal
          visible={visible}
          onDismiss={onDismiss}
          contentContainerStyle={styles.modalContainer}
        >
          <ScrollView>
            <Text variant="titleLarge" style={styles.title}>
              Add New Item
            </Text>
            <TextInput
              label="Fridge"
              value={fridge.name}
              disabled
              style={styles.input}
            />
            <TextInput
              label="Item Name"
              value={newItemName}
              onChangeText={setNewItemName}
              style={styles.input}
            />
            <TheMealDbIngredientSelector
              onSelectIngredient={handleSelectIngredient}
            />
            <View style={styles.quantityContainer}>
              <TextInput
                label="Quantity"
                value={newItemQuantity.toString()}
                onChangeText={(text) => setNewItemQuantity(parseInt(text))}
                keyboardType="numeric"
                style={[styles.input, styles.quantityInput]}
              />
              <Menu
                visible={menuVisible}
                onDismiss={() => setMenuVisible(false)}
                anchor={
                  <Button onPress={() => setMenuVisible(true)}>
                    {newItemUnit}
                  </Button>
                }
              >
                {units.map((unit) => (
                  <Menu.Item
                    key={unit}
                    onPress={() => {
                      setNewItemUnit(unit);
                      setMenuVisible(false);
                    }}
                    title={unit}
                  />
                ))}
              </Menu>
            </View>

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
              onPress={handleSaveItem}
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
    backgroundColor: "white",
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
  quantityContainer: {
    flexDirection: "row",
    alignItems: "center",
    marginBottom: 10,
  },
  quantityInput: {
    flex: 1,
  },
  saveButton: {
    marginTop: 20,
  },
});

export default AddItemModal;
