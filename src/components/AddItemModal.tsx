import React, { useState, useEffect, useCallback } from "react";
import { StyleSheet, View, ScrollView } from "react-native";
import {
  Modal,
  Portal,
  Text,
  TextInput,
  Button,
  useTheme,
  Dialog,
  List,
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
    const theme = useTheme();
    const [newItemFood, setNewItemFood] = useState<Food>({
      id: 0,
      name: "",
      ingredientOpenMealDbName: "",
    });
    const [newItemQuantity, setNewItemQuantity] = useState("500");
    const [newItemUnit, setNewItemUnit] = useState("gr");
    const [newItemExpirationDate, setNewItemExpirationDate] = useState(
      addDays(new Date(), 7)
    );
    const [units, setUnits] = useState<string[]>([]);
    const [unitDialogVisible, setUnitDialogVisible] = useState(false);

    useEffect(() => {
      const fetchUnits = async () => {
        const availableUnits = await UnitService.getUnits();
        setUnits(availableUnits);
      };

      fetchUnits();
    }, []);

    const handleSaveItem = useCallback(async () => {
      const quantity = parseInt(newItemQuantity);
      if (isNaN(quantity)) {
        alert("Please enter a valid quantity.");
        return;
      }

      const newItem = {
        id: 0,
        food: newItemFood,
        quantity: quantity,
        unit: newItemUnit,
        expirationDate: newItemExpirationDate.toISOString(),
        fridgeId: fridge.id,
      };
      FridgeItemService.addItem(newItem);
      setNewItemFood({ id: 0, name: "", ingredientOpenMealDbName: "" });
      setNewItemQuantity("1");
      setNewItemUnit("gr");
      setNewItemExpirationDate(addDays(new Date(), 7));
      onDismiss();
      onItemAdded();
    }, [
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

    const handleSelectUnit = (unit: string) => {
      setNewItemUnit(unit);
      setUnitDialogVisible(false);
    };

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
            <View>
              <TextInput
                label="Quantity"
                value={newItemQuantity}
                onChangeText={setNewItemQuantity}
                keyboardType="numeric"
                style={[styles.input, styles.quantityInput]}
                right={
                  <TextInput.Icon
                    icon="chevron-down"
                    onPress={() => setUnitDialogVisible(true)}
                  />
                }
              />
              <Portal>
                <Dialog
                  visible={unitDialogVisible}
                  onDismiss={() => setUnitDialogVisible(false)}
                >
                  <Dialog.Title>Select Unit</Dialog.Title>
                  <Dialog.Content>
                    <ScrollView>
                      <List.Section>
                        {units.map((unit) => (
                          <List.Item
                            key={unit}
                            title={unit}
                            onPress={() => handleSelectUnit(unit)}
                          />
                        ))}
                      </List.Section>
                    </ScrollView>
                  </Dialog.Content>
                  <Dialog.Actions>
                    <Button onPress={() => setUnitDialogVisible(false)}>
                      Cancel
                    </Button>
                  </Dialog.Actions>
                </Dialog>
              </Portal>
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
  quantityInput: {
    flex: 1,
  },
  saveButton: {
    marginTop: 20,
  },
});

export default AddItemModal;
