import React, { useState, useEffect } from "react";
import { StyleSheet, View, TouchableOpacity, ScrollView } from "react-native";
import { TextInput, Dialog, Portal, Button, List } from "react-native-paper";
import useUnits from "@hooks/useUnits";
import { Unit } from "@src/types/Unit";
import { UnitApi } from "@services/UnitService";

interface UnitQuantitySelectorProps {
  quantity: number;
  setQuantity: (quantity: number) => void;
  unit: Unit | null;
  setUnit: (unit: Unit) => void;
}

const UnitQuantitySelector: React.FC<UnitQuantitySelectorProps> = ({
  quantity,
  setQuantity,
  unit,
  setUnit,
}) => {
  const { units } = useUnits();
  const [localQuantity, setLocalQuantity] = useState((quantity ?? 0).toString());
  const [unitDialogVisible, setUnitDialogVisible] = useState(false);

  useEffect(() => {
    setLocalQuantity(quantity.toString());
  }, [quantity]);

  const handleQuantityChange = (text: string) => {
    setLocalQuantity(text);
  };

  const handleQuantityBlur = () => {
    const num = parseFloat(localQuantity);
    if (!isNaN(num)) setQuantity(num);
  };

  const handleSelectUnit = (selectedUnit: UnitApi) => {
    setUnit({ id: selectedUnit.id, name: selectedUnit.name, code: selectedUnit.code });
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
          value={unit ? unit.code : ""}
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
            <ScrollView style={{ maxHeight: 250 }}>
              <List.Section>
                {units.map((u) => (
                  <List.Item
                    key={u.id}
                    title={`${u.name} (${u.code})`}
                    onPress={() => handleSelectUnit(u)}
                  />
                ))}
              </List.Section>
            </ScrollView>
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
    minWidth: 120,
  },
  unitInputContainer: {
    flex: 1,
    minWidth: 120,
  },
  unitInput: {
    flex: 1,
    minWidth: 120,
  },
});

export default UnitQuantitySelector;
