import React, { useEffect, useState } from "react";
import { ScrollView, StyleSheet } from "react-native";
import { Card, Text } from "react-native-paper";
import { getMealsByIngredient } from "@src/services/api";

const Recommendations = () => {
  const [meals, setMeals] = useState<
    { id: string; name: string; category: string; area: string }[]
  >([]);

  useEffect(() => {
    const fetchMeals = async () => {
      const result = await getMealsByIngredient("chicken");
      setMeals(result);
    };
    fetchMeals();
  }, []);

  return (
    <ScrollView horizontal style={styles.scrollView}>
      {meals.map((meal) => (
        <Card key={meal.id} style={styles.card}>
          <Card.Title title={meal.name} />
          <Card.Content>
            <Text>Category: {meal.category}</Text>
            <Text>Area: {meal.area}</Text>
          </Card.Content>
        </Card>
      ))}
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  scrollView: {
    flexDirection: "row",
  },
  card: {
    width: 200,
    margin: 10,
    padding: 10,
    borderRadius: 10,
  },
});

export default Recommendations;
