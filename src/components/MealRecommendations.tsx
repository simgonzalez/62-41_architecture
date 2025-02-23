import React, { useEffect, useState } from "react";
import { ScrollView, StyleSheet } from "react-native";
import { Card, Text } from "react-native-paper";
import { getMealsByIngredient } from "@src/services/TheMealDbService";

interface MealRecommendationsProps {
  ingredientName: string;
}

const MealRecommendations: React.FC<MealRecommendationsProps> = ({
  ingredientName,
}) => {
  const [meals, setMeals] = useState<
    { idMeal: string; strMeal: string; strCategory: string; strArea: string }[]
  >([]);

  useEffect(() => {
    const fetchMeals = async () => {
      const result = await getMealsByIngredient(ingredientName);
      setMeals(result);
    };
    fetchMeals();
  }, [ingredientName]);

  return (
    <ScrollView horizontal style={styles.scrollView}>
      {meals.map((meal) => (
        <Card key={meal.idMeal} style={styles.card}>
          <Card.Title title={meal.strMeal} />
          <Card.Content>
            <Text>Category: {meal.strCategory}</Text>
            <Text>Area: {meal.strArea}</Text>
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

export default MealRecommendations;
