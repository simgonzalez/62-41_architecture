import React, { useEffect, useState } from "react";
import { ScrollView, View, StyleSheet } from "react-native";
import { Text } from "react-native-paper";
import MealRecommendations from "@src/components/MealRecommendations";
import FridgeItemsList from "@components/FridgeItemsList";
import { FridgeItemService } from "@services/FridgeItemService";
import { FridgeItem } from "@src/types/FridgeItem";

const HomeScreen = () => {
  const [closestExpiringItem, setClosestExpiringItem] = useState<
    FridgeItem | undefined
  >(undefined);
  const [fridgeItems, setFridgeItems] = useState<FridgeItem[]>([]);

  useEffect(() => {
    const fetchClosestExpiringItem = async () => {
      const item = await FridgeItemService.getByClosestExpirationDate();
      setClosestExpiringItem(item);
    };

    const fetchFridgeItems = async () => {
      const items = await FridgeItemService.getAll();
      setFridgeItems(items);
    };

    fetchClosestExpiringItem();
    fetchFridgeItems();
  }, []);

  return (
    <ScrollView contentContainerStyle={styles.container}>
      <View style={styles.section}>
        <Text variant="titleLarge">Recommendations</Text>
        {closestExpiringItem ? (
          <MealRecommendations
            ingredientName={closestExpiringItem.food.ingredientOpenMealDbName}
          />
        ) : (
          <Text style={styles.noRecommendations}>
            No recommendations could be made, we are sorry about that.
          </Text>
        )}
      </View>
      <View style={styles.section}>
        <Text variant="titleLarge">Fridges items</Text>
        <FridgeItemsList items={fridgeItems} />
      </View>
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
  noRecommendations: {
    color: "red",
    fontStyle: "italic",
    marginTop: 10,
  },
});

export default HomeScreen;
