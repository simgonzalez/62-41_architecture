import React, { useEffect, useState } from "react";
import { View, StyleSheet } from "react-native";
import { Avatar, List } from "react-native-paper";
import { FridgeItem } from "@src/types/FridgeItem";
import { HydratedFridgeItem } from "@src/types/HydratedFridgeItem";
import { getIngredientImageUrl } from "@services/TheMealDbService";
import { FridgeService } from "@services/FridgeService";

interface FridgeItemsListProps {
  items: FridgeItem[];
}

const FridgeItemsList: React.FC<FridgeItemsListProps> = ({ items }) => {
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

  return (
    <View style={styles.container}>
      {hydratedItems.map((item) => (
        <List.Item
          key={item.id}
          title={item.food.name}
          description={`Fridge: ${item.fridgeName}`}
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
