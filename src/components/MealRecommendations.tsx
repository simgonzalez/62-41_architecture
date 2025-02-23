import React, { useEffect, useState } from "react";
import { ScrollView, StyleSheet, TouchableOpacity } from "react-native";
import { Card, Text, Avatar, Portal, Surface } from "react-native-paper";
import {
  getMealsByIngredient,
  getMealById,
  getIngredientImageUrl,
} from "@src/services/TheMealDbService";
import { DehydratedMeal, HydratedMeal } from "@src/types/Meal";
import MealDetails from "@src/components/MealDetails";

interface MealRecommendationsProps {
  ingredientName: string;
}

const MealRecommendations: React.FC<MealRecommendationsProps> = ({
  ingredientName,
}) => {
  const [meals, setMeals] = useState<DehydratedMeal[]>([]);
  const [hydratedMeals, setHydratedMeals] = useState<HydratedMeal[]>([]);
  const [selectedMeal, setSelectedMeal] = useState<HydratedMeal | null>(null);
  const [visible, setVisible] = useState(false);

  useEffect(() => {
    const fetchMeals = async () => {
      const dehydratedMeals = await getMealsByIngredient(ingredientName);
      setMeals(dehydratedMeals);

      const hydratedMealsPromises = dehydratedMeals.map((meal) =>
        getMealById(meal.idMeal)
      );
      const hydratedMealsResults = await Promise.all(hydratedMealsPromises);
      setHydratedMeals(hydratedMealsResults.filter((meal) => meal !== null));
    };
    fetchMeals();
  }, [ingredientName]);

  const handleMealPress = (meal: HydratedMeal) => {
    setSelectedMeal(meal);
    setVisible(true);
  };

  const handleClose = () => {
    setVisible(false);
    setSelectedMeal(null);
  };

  return (
    <ScrollView>
      <Portal>
        {selectedMeal && (
          <MealDetails
            meal={selectedMeal}
            visible={visible}
            onClose={handleClose}
          />
        )}
      </Portal>
      <ScrollView horizontal style={styles.scrollView}>
        {hydratedMeals.map((meal) => (
          <TouchableOpacity
            key={meal.idMeal}
            onPress={() => handleMealPress(meal)}
          >
            <Card style={styles.card} elevation={4}>
              <Card.Title
                title={meal.strMeal}
                left={() => (
                  <Avatar.Image
                    size={40}
                    source={{ uri: getIngredientImageUrl(ingredientName) }}
                  />
                )}
              />
              <Card.Content>
                <Text variant="labelLarge">
                  Category: <Text>{meal.strCategory}</Text>
                </Text>
                <Text variant="labelLarge">
                  Area: <Text>{meal.strArea}</Text>
                </Text>
                <Text variant="labelLarge">
                  Tags: <Text>{meal.strTags ?? "-"}</Text>
                </Text>
              </Card.Content>
            </Card>
          </TouchableOpacity>
        ))}
      </ScrollView>
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  scrollView: {
    flexDirection: "row",
  },
  card: {
    flex: 1,
    margin: 10,
    padding: 10,
    borderRadius: 10,
  },
  label: {
    fontWeight: "bold",
    marginTop: 5,
  },
});

export default MealRecommendations;
