import React, { useState } from "react";
import { View, StyleSheet } from "react-native";
import { useRoute } from "@react-navigation/native";
import { Fridge } from "@src/types/Fridge";
import { Text, FAB, useTheme } from "react-native-paper";
import Icon from "react-native-vector-icons/MaterialIcons";
import FridgeItemsList from "@components/FridgeItemsList";
import AddEditFridgeItemModal from "@components/AddEditFridgeItemModal";
import useFridgeItems from "@hooks/useFridgeItems";
import { addDays } from "date-fns/addDays";
import { Food } from "@src/types/Food";

const FridgeDetails = () => {
  const route = useRoute();
  const { fridge } = route.params as { fridge: Fridge };
  const { fridgeItems, fetchFridgeItems } = useFridgeItems(fridge.id);
  const { colors } = useTheme();
  const [addItemVisible, setAddItemVisible] = useState(false);

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
        <FridgeItemsList items={fridgeItems} />
      ) : (
        <Text style={[styles.noItemsText, { color: colors.onSurface }]}>
          No items in this fridge
        </Text>
      )}
      <FAB
        style={styles.fab}
        icon="plus"
        onPress={() => {
          setAddItemVisible(true);
        }}
      />
      <AddEditFridgeItemModal
        visible={addItemVisible}
        onModalClose={() => {
          setAddItemVisible(false);
          fetchFridgeItems();
        }}
        fridgeItem={{
          id: -1,
          food: {} as Food,
          quantity: { value: 500, unit: "piece" },
          expirationDate: addDays(Date.now(), 5).toISOString(),
          fridgeId: fridge.id,
        }}
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
