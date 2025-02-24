import React from "react";
import { ScrollView, StyleSheet, TouchableOpacity } from "react-native";
import { Card, Text, Avatar, Portal } from "react-native-paper";
import { getIngredientImageUrl } from "@src/services/TheMealDbService";
import MealDetails from "@src/components/MealDetails";
import useMealsByIngredient from "@hooks/useMealsByIngredient";
import useSelectedMeal from "@hooks/useSelectedMeal";

interface MealRecommendationsProps {
  ingredientName: string;
}

const MealRecommendations: React.FC<MealRecommendationsProps> = ({
  ingredientName,
}) => {
  const { hydratedMeals } = useMealsByIngredient(ingredientName);
  const { selectedMeal, visible, handleMealPress, handleClose } =
    useSelectedMeal();

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
