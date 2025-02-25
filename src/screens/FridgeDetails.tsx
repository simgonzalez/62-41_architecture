import React, { useState } from "react";
import { View, StyleSheet } from "react-native";
import { useRoute } from "@react-navigation/native";
import { Fridge } from "@src/types/Fridge";
import { Text, FAB, useTheme } from "react-native-paper";
import Icon from "react-native-vector-icons/MaterialIcons";
import FridgeItemsList from "@components/FridgeItemsList";
import AddEditFridgeItemModal from "@components/AddEditFridgeItemModal";
import useFridgeItems from "@hooks/useFridgeItems";
import { FridgeItem } from "@src/types/FridgeItem";
import { addDays } from "date-fns/addDays";

const FridgeDetails = () => {
  const route = useRoute();
  const { fridge } = route.params as { fridge: Fridge };
  const { fridgeItems, fetchFridgeItems } = useFridgeItems(fridge.id);
  const [modalVisible, setModalVisible] = useState(false);
  const [selectedItem, setSelectedItem] = useState<FridgeItem | undefined>(
    undefined
  );
  const { colors } = useTheme();

  const handleAddItem = () => {
    setSelectedItem(undefined);
    setModalVisible(true);
  };

  const handleEditItem = (item: FridgeItem) => {
    setSelectedItem(item);
    setModalVisible(true);
  };

  const handleItemSaved = () => {
    console.log("saved item");
    setModalVisible(false);
    fetchFridgeItems();
  };

  // Create a dummy item with just the fridgeId for add mode
  const newItem = selectedItem || {
    id: null,
    fridgeId: fridge.id,
    food: { id: 0, name: "", image: "", ingredientOpenMealDbName: "" },
    quantity: { value: 0, unit: "g" },
    expirationDate: addDays(new Date(), 7).toISOString(),
  };

  return (
    <View style={[styles.container, { backgroundColor: colors.background }]}>
      <View style={styles.locationContainer}>
        <Icon name="location-on" size={24} color={colors.primary} />
        <Text
          variant="bodyLarge"
          style={[styles.locationText, { color: colors.onBackground }]}
        >
          {fridge.location.name}
        </Text>
      </View>
      {fridgeItems.length > 0 ? (
        <FridgeItemsList items={fridgeItems} onItemPress={handleEditItem} />
      ) : (
        <Text style={[styles.noItemsText, { color: colors.onSurface }]}>
          No items in this fridge
        </Text>
      )}
      <FAB style={styles.fab} icon="plus" onPress={handleAddItem} />
      <AddEditFridgeItemModal
        visible={modalVisible}
        onDismiss={() => setModalVisible(false)}
        fridgeItem={newItem}
        onItemSaved={handleItemSaved}
      />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
  },
  locationContainer: {
    flexDirection: "row",
    alignItems: "center",
    marginBottom: 20,
  },
  locationText: {
    marginLeft: 8,
  },
  noItemsText: {
    textAlign: "center",
    marginTop: 20,
    fontSize: 16,
  },
  fab: {
    position: "absolute",
    right: 16,
    bottom: 16,
  },
});

export default FridgeDetails;
