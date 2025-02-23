import React, { useEffect, useState, useCallback } from "react";
import { ScrollView, View, StyleSheet } from "react-native";
import { Divider, Text, useTheme, IconButton } from "react-native-paper";
import MealRecommendations from "@src/components/MealRecommendations";
import FridgeItemsList from "@components/FridgeItemsList";
import { FridgeItemService } from "@services/FridgeItemService";
import { FridgeItem } from "@src/types/FridgeItem";

const HomeScreen = () => {
  const { colors } = useTheme();
  const [closestExpiringItem, setClosestExpiringItem] = useState<
    FridgeItem | undefined
  >(undefined);
  const [fridgeItems, setFridgeItems] = useState<FridgeItem[]>([]);

  const fetchClosestExpiringItem = useCallback(async () => {
    const item = await FridgeItemService.getByClosestExpirationDate();
    setClosestExpiringItem(item);
  }, []);

  const fetchFridgeItems = useCallback(async () => {
    const items = await FridgeItemService.getAll();
    setFridgeItems(items);
  }, []);

  const handleRefresh = () => {
    fetchClosestExpiringItem();
    fetchFridgeItems();
  };

  useEffect(() => {
    fetchClosestExpiringItem();
    fetchFridgeItems();
  }, [fetchClosestExpiringItem, fetchFridgeItems]);

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
