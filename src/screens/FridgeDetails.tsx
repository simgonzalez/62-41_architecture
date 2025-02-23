import React, { useEffect, useState } from "react";
import { View, StyleSheet } from "react-native";
import { useRoute } from "@react-navigation/native";
import { Fridge } from "@src/types/Fridge";
import { FridgeItem } from "@src/types/FridgeItem";
import { Text, Button } from "react-native-paper";
import Icon from "react-native-vector-icons/MaterialIcons";
import FridgeItemsList from "@components/FridgeItemsList";
import AddItemModal from "@components/AddItemModal";
import { FridgeItemService } from "@services/FridgeItemService";

const FridgeDetails = () => {
  const route = useRoute();
  const { fridge } = route.params as { fridge: Fridge };
  const [fridgeItems, setFridgeItems] = useState<FridgeItem[]>([]);
  const [modalVisible, setModalVisible] = useState(false);

  const fetchFridgeItems = async () => {
    const items = await FridgeItemService.getByFridgeId(fridge.id);
    if (items) {
      setFridgeItems(items);
    }
  };

  useEffect(() => {
    fetchFridgeItems();
  }, [fridge.id]);

  const handleAddItem = () => {
    setModalVisible(true);
  };

  const handleItemAdded = () => {
    setModalVisible(false);
    fetchFridgeItems();
  };

  return (
    <View style={styles.container}>
      <View style={styles.locationContainer}>
        <Icon name="location-on" size={24} color="black" />
        <Text variant="bodyLarge" style={styles.locationText}>
          {fridge.location.name}
        </Text>
      </View>
      {fridgeItems.length > 0 ? (
        <FridgeItemsList items={fridgeItems} />
      ) : (
        <Text style={styles.noItemsText}>No items in this fridge</Text>
      )}
      <Button mode="contained" onPress={handleAddItem}>
        Add Item
      </Button>
      <AddItemModal
        visible={modalVisible}
        onDismiss={() => setModalVisible(false)}
        fridge={fridge}
        onItemAdded={handleItemAdded}
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
    color: "gray",
  },
});

export default FridgeDetails;
