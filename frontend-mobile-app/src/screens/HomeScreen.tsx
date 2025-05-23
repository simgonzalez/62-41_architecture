import React, { useEffect, useState } from "react";
import { ScrollView, View, StyleSheet } from "react-native";
import { Divider, Text } from "react-native-paper";
import MealRecommendations from "@components/MealRecommendations";
import FridgeItemsList from "@components/FridgeItemsList";
import ApiService from "@services/ApiService";

const HomeScreen = () => {
  const [fridgeItems, setFridgeItems] = useState<any[]>([]);
  const [loadingFridgeItems, setLoadingFridgeItems] = useState(false);

  useEffect(() => {
    const fetchSortedFridgeItems = async () => {
      setLoadingFridgeItems(true);
      try {
        const items = await ApiService.getUserFridgeItems();
        setFridgeItems(items);
      } catch (error) {
        setFridgeItems([]);
      } finally {
        setLoadingFridgeItems(false);
      }
    };
    fetchSortedFridgeItems();
  }, []);

  return (
    <ScrollView contentContainerStyle={styles.container}>
      <View style={styles.section}>
        <Text variant="titleLarge">Recommendations</Text>
        <MealRecommendations />
      </View>
      <Divider style={styles.divider} />
      <View style={styles.section}>
        <Text variant="titleLarge">Fridges items</Text>
        <ScrollView>
          <FridgeItemsList
            items={fridgeItems}
            loading={loadingFridgeItems}
            onItemsUpdate={async () => {
              const items = await ApiService.getUserFridgeItems();
              setFridgeItems(items);
            }}
          />
        </ScrollView>
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
