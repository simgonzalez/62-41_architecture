import React, { useState } from "react";
import { ScrollView, View, StyleSheet } from "react-native";
import { Divider, Text, useTheme, IconButton } from "react-native-paper";
import MealRecommendations from "@src/components/MealRecommendations";
import FridgeItemsList from "@components/FridgeItemsList";
import useClosestExpiringItem from "@hooks/useClosestExpiringItem";
import useAllFridgeItems from "@hooks/useAllFridgeItems";
import AddEditFridgeItemModal from "@src/components/AddEditFridgeItemModal";
import { FridgeItem } from "@src/types/FridgeItem";

const HomeScreen = () => {
  const { colors } = useTheme();
  const { closestExpiringItem, fetchClosestExpiringItem } =
    useClosestExpiringItem();
  const { fridgeItems, fetchFridgeItems } = useAllFridgeItems();
  const [modalVisible, setModalVisible] = useState(false);
  const [selectedItem, setSelectedItem] = useState<FridgeItem | undefined>(
    undefined
  );
  const handleEditItem = (item: FridgeItem) => {
    setSelectedItem(item);
    setModalVisible(true);
  };
  const handleItemSaved = () => {
    console.log("saved item");
    setModalVisible(false);
    fetchFridgeItems();
  };
  const handleRefresh = () => {
    fetchClosestExpiringItem();
    fetchFridgeItems();
  };

  return (
    <ScrollView contentContainerStyle={styles.container}>
      <View style={styles.section}>
        <View style={styles.header}>
          <Text variant="titleLarge">Recommendations</Text>
          <IconButton
            icon="refresh"
            size={24}
            onPress={handleRefresh}
            style={styles.refreshButton}
          />
        </View>
        {closestExpiringItem ? (
          <MealRecommendations
            ingredientName={closestExpiringItem.food.ingredientOpenMealDbName}
          />
        ) : (
          <Text style={[styles.noRecommendations, { color: colors.error }]}>
            No recommendations could be made, we are sorry about that.
          </Text>
        )}
      </View>
      <Divider style={styles.divider} />
      <View style={styles.section}>
        <Text variant="titleLarge">Fridges items</Text>
        <FridgeItemsList
          items={fridgeItems}
          onItemPress={(item) => handleEditItem(item)}
        />
      </View>
      <AddEditFridgeItemModal
        visible={modalVisible}
        onDismiss={() => setModalVisible(false)}
        fridgeItem={selectedItem}
        onItemSaved={handleItemSaved}
      />
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
  },
  section: {
    marginBottom: 20,
    width: "100%",
  },
  header: {
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "space-between",
  },
  divider: {
    marginVertical: 10,
  },
  noRecommendations: {
    fontStyle: "italic",
    marginTop: 10,
  },
  refreshButton: {
    marginLeft: 10,
  },
});

export default HomeScreen;
