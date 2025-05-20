import React, { useState } from "react";
import { View, StyleSheet } from "react-native";
import { Avatar, List, Text, useTheme } from "react-native-paper";
import { FridgeItem } from "@src/types/FridgeItem";
import { getIngredientImageUrl } from "@services/TheMealDbService";
import { parseISO } from "date-fns/parseISO";
import { formatDistanceToNow } from "date-fns/formatDistanceToNow";
import AddEditFridgeItemModal from "./AddEditFridgeItemModal";

type FridgeItemsListProps = {
  items: FridgeItem[];
  onItemsUpdate?: () => void;
};

const FridgeItemsList: React.FC<FridgeItemsListProps> = ({
  items,
  onItemsUpdate,
}) => {
  const { colors } = useTheme();
  const [modalVisible, setModalVisible] = useState(false);
  const [pressedItem, setPressedItem] = useState<FridgeItem>();

  const getPerishableDateStyle = (perishableDate: string) => {
    const date = parseISO(perishableDate);
    const now = new Date();
    const diffInDays = (date.getTime() - now.getTime()) / (1000 * 3600 * 24);
    return diffInDays < 2 ? { color: colors.error } : {};
  };

  return (
    <View style={styles.container}>
      {items.map((item: FridgeItem) => (
        <List.Item
          key={item.id}
          title={item.food.name}
          description={() => (
            <View>
              <Text>{item.fridge.name}</Text>
              <Text>
                {item.quantity.name} {item.quantity.code}
              </Text>
              <Text style={getPerishableDateStyle(item.expirationDate)}>
                Expires{" "}
                {formatDistanceToNow(parseISO(item.expirationDate), {
                  addSuffix: true,
                })}
              </Text>
            </View>
          )}
          onPress={() => {
            setPressedItem(item);
            setModalVisible(true);
          }}
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
      <AddEditFridgeItemModal
        visible={modalVisible}
        onModalClose={() => {
          setModalVisible(false);
          if (onItemsUpdate) onItemsUpdate();
        }}
        fridgeItem={pressedItem!}
      />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    width: "100%",
  },
});

export default FridgeItemsList;
