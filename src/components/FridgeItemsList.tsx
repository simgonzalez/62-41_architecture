import React, { useEffect, useState } from "react";
import { View, StyleSheet } from "react-native";
import { Avatar, List, Text, useTheme } from "react-native-paper";
import { FridgeItem } from "@src/types/FridgeItem";
import { HydratedFridgeItem } from "@src/types/HydratedFridgeItem";
import { getIngredientImageUrl } from "@services/TheMealDbService";
import { FridgeService } from "@services/FridgeService";
import { formatDistanceToNow } from "date-fns/formatDistanceToNow";
import { parseISO } from "date-fns/parseISO";

interface FridgeItemsListProps {
  items: FridgeItem[];
}

const FridgeItemsList: React.FC<FridgeItemsListProps> = ({ items }) => {
  const { colors } = useTheme();
  const [hydratedItems, setHydratedItems] = useState<HydratedFridgeItem[]>([]);

  useEffect(() => {
    const hydrateItems = async () => {
      const itemsWithFridgeNames = await Promise.all(
        items.map(async (item) => {
          const fridge = await FridgeService.getById(item.fridgeId);
          return { ...item, fridgeName: fridge.name };
        })
      );
      setHydratedItems(itemsWithFridgeNames);
    };

    hydrateItems();
  }, [items]);

  const getPerishableDateStyle = (perishableDate: string) => {
    const date = parseISO(perishableDate);
    const now = new Date();
    const diffInDays = (date.getTime() - now.getTime()) / (1000 * 3600 * 24);
    return diffInDays < 2 ? { color: colors.error } : {};
  };

  return (
    <View style={styles.container}>
      {hydratedItems.map((item) => (
        <List.Item
          key={item.id}
          title={item.food.name}
          description={() => (
            <View>
              <Text>{item.fridgeName}</Text>
              <Text>Quantity {item.quantity}</Text>
              <Text style={getPerishableDateStyle(item.expirationDate)}>
                Expire
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
