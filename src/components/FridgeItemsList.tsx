import React from "react";
import { View, StyleSheet } from "react-native";
import { Avatar, List, Text, useTheme } from "react-native-paper";
import { FridgeItem } from "@src/types/FridgeItem";
import { getIngredientImageUrl } from "@services/TheMealDbService";
import { parseISO } from "date-fns/parseISO";
import { formatDistanceToNow } from "date-fns/formatDistanceToNow";
import useHydratedFridgeItems from "@hooks/useHydratedFridgeItems";
import { HydratedFridgeItem } from "@src/types/HydratedFridgeItem";

interface FridgeItemsListProps {
  items: FridgeItem[];
}

const FridgeItemsList: React.FC<FridgeItemsListProps> = ({ items }) => {
  const { colors } = useTheme();
  const hydratedItems = useHydratedFridgeItems(items);

  const getPerishableDateStyle = (perishableDate: string) => {
    const date = parseISO(perishableDate);
    const now = new Date();
    const diffInDays = (date.getTime() - now.getTime()) / (1000 * 3600 * 24);
    return diffInDays < 2 ? { color: colors.error } : {};
  };

  return (
    <View style={styles.container}>
      {hydratedItems.map((item: HydratedFridgeItem) => (
        <List.Item
          key={item.id}
          title={item.food.name}
          description={() => (
            <View>
              <Text>{item.fridgeName}</Text>
              <Text>
                {item.quantity.value} {item.quantity.unit}
              </Text>
              <Text style={getPerishableDateStyle(item.expirationDate)}>
                Expires{" "}
                {formatDistanceToNow(parseISO(item.expirationDate), {
                  addSuffix: true,
                })}
              </Text>
            </View>
          )}
          left={() => (
            <Avatar.Image
              size={40}
              source={{
                uri: getIngredientImageUrl(item.food.ingredientOpenMealDbName),
              }}
            />
          )}
        />
      ))}
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    width: "100%",
  },
});

export default FridgeItemsList;
