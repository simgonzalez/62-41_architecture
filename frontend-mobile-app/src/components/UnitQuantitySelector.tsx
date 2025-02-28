import React, { useState, useEffect } from "react";
import { StyleSheet, View, TouchableOpacity } from "react-native";
import { TextInput, Dialog, Portal, Button, List } from "react-native-paper";
import useUnits from "@hooks/useUnits";
import { Quantity } from "@src/types/Quantity";

interface UnitQuantitySelectorProps {
  quantity: Quantity;
  setQuantity: (quantity: Quantity) => void;
}

const UnitQuantitySelector: React.FC<UnitQuantitySelectorProps> = ({
  quantity,
  setQuantity,
}) => {
  const { units } = useUnits();
  const [localQuantity, setLocalQuantity] = useState(quantity.value.toString());
  const [unitDialogVisible, setUnitDialogVisible] = useState(false);

  useEffect(() => {
    setLocalQuantity(quantity.value.toString());
  }, [quantity]);

  const handleQuantityChange = (text: string) => {
    setLocalQuantity(text);
  };

  const handleQuantityBlur = () => {
    setQuantity({ ...quantity, value: parseFloat(localQuantity) || 0 });
  };

  const handleSelectUnit = (selectedUnit: string) => {
    setQuantity({ ...quantity, unit: selectedUnit });
    setUnitDialogVisible(false);
  };

  return (
    <View style={styles.quantityContainer}>
      <TextInput
        label="Quantity"
        value={localQuantity}
        onChangeText={handleQuantityChange}
        onBlur={handleQuantityBlur}
        keyboardType="numeric"
        style={[styles.input, styles.quantityInput]}
      />
      <TouchableOpacity
        style={styles.unitInputContainer}
        onPress={() => setUnitDialogVisible(true)}
      >
        <TextInput
          label="Unit"
          value={quantity.unit}
          editable={false}
          style={[styles.input, styles.unitInput]}
          right={
            <TextInput.Icon
              icon="chevron-down"
              onPress={() => setUnitDialogVisible(true)}
            />
          }
        />
      </TouchableOpacity>
      <Portal>
        <Dialog
          visible={unitDialogVisible}
          onDismiss={() => setUnitDialogVisible(false)}
        >
          <Dialog.Title>Select Unit</Dialog.Title>
          <Dialog.Content>
            <List.Section>
              {units.map((unit) => (
                <List.Item
                  key={unit}
                  title={unit}
                  onPress={() => handleSelectUnit(unit)}
                />
              ))}
            </List.Section>
          </Dialog.Content>
          <Dialog.Actions>
            <Button onPress={() => setUnitDialogVisible(false)}>Cancel</Button>
          </Dialog.Actions>
        </Dialog>
      </Portal>
    </View>
  );
};

const styles = StyleSheet.create({
  quantityContainer: {
    flexDirection: "row",
    alignItems: "center",
  },
  input: {
    marginBottom: 10,
  },
  quantityInput: {
    flex: 2,
    marginRight: 10,
  },
  unitInputContainer: {
    flex: 1,
  },
  unitInput: {
    flex: 1,
  },
});

export default UnitQuantitySelector;
