import React, { useEffect, useState } from "react";
import { ScrollView, StyleSheet, TouchableOpacity, ActivityIndicator } from "react-native";
import { Card, Text, Avatar, Portal } from "react-native-paper";
import { getRecommendedMeals, getMealById } from "@src/services/TheMealDbService";
import MealDetails from "@src/components/MealDetails";
import useSelectedMeal from "@hooks/useSelectedMeal";

const MealRecommendations: React.FC = () => {
  const [meals, setMeals] = useState<any[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const { selectedMeal, visible, handleMealPress, handleClose } = useSelectedMeal();

  useEffect(() => {
    const fetchRecommendations = async () => {
      setLoading(true);
      setError(null);
      try {
        const recommended = await getRecommendedMeals();
        setMeals(recommended || []);
      } catch (e) {
        setError("No recommendations could be made, we are sorry about that.");
        setMeals([]);
      } finally {
        setLoading(false);
      }
    };
    fetchRecommendations();
  }, []);

  const handleMealPressWithDetails = async (meal: any) => {
    // If the meal already has details, just show it
    if (meal.strInstructions && meal.strCategory && meal.strArea) {
      handleMealPress(meal);
      return;
    }
    // Otherwise, fetch details by id
    try {
      const details = await getMealById(meal.idMeal);
      if (details) {
        handleMealPress({ ...meal, ...details });
      } else {
        handleMealPress(meal);
      }
    } catch {
      handleMealPress(meal);
    }
  };

  if (loading) {
    return <ActivityIndicator style={{ marginVertical: 16 }} />;
  }

  if (error) {
    return <Text style={[styles.noRecommendations, { color: "red" }]}>{error}</Text>;
  }

  if (!meals.length) {
    return (
      <Text style={[styles.noRecommendations, { color: "red" }]}>
        No recommendations could be made, we are sorry about that.
      </Text>
    );
  }

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
        {meals.map((meal) => (
          <TouchableOpacity
            key={meal.idMeal}
            onPress={() => handleMealPressWithDetails(meal)}
          >
            <Card style={styles.card} elevation={4}>
              <Card.Title
                title={meal.strMeal}
                left={() => (
                  <Avatar.Image
                    size={40}
                    source={{ uri: meal.strMealThumb }}
                  />
                )}
              />
              <Card.Content>
                {meal.strCategory && (
                  <Text variant="labelLarge">
                    Category: <Text>{meal.strCategory}</Text>
                  </Text>
                )}
                {meal.strArea && (
                  <Text variant="labelLarge">
                    Area: <Text>{meal.strArea}</Text>
                  </Text>
                )}
                {meal.strTags && (
                  <Text variant="labelLarge">
                    Tags: <Text>{meal.strTags}</Text>
                  </Text>
                )}
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
  noRecommendations: {
    fontStyle: "italic",
    marginTop: 10,
  },
});

export default MealRecommendations;
