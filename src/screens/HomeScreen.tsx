import React from "react";
import { ScrollView, View, StyleSheet } from "react-native";
import { Divider, Text, useTheme } from "react-native-paper";
import MealRecommendations from "@src/components/MealRecommendations";
import FridgeItemsList from "@components/FridgeItemsList";
import useClosestExpiringItem from "@hooks/useClosestExpiringItem";
import useAllFridgeItems from "@hooks/useAllFridgeItems";

const HomeScreen = () => {
  const { colors } = useTheme();
  const { closestExpiringItem, fetchClosestExpiringItem } =
    useClosestExpiringItem();
  const { fridgeItems, fetchFridgeItems } = useAllFridgeItems();

  return (
    <ScrollView contentContainerStyle={styles.container}>
      <View style={styles.section}>
        <Text variant="titleLarge">Recommendations</Text>
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
