import React, { useEffect, useState } from 'react';
import { ScrollView, View, Text, StyleSheet } from 'react-native';
import { Card } from '@rneui/themed';
import { getMealsByIngredient } from '@src/services/api';

const Recommendations = () => {
  const [meals, setMeals] = useState<{ id: string; name: string; category: string; area: string; }[]>([]);

  useEffect(() => {
    const fetchMeals = async () => {
      const result = await getMealsByIngredient('chicken');
      setMeals(result);
    };
    fetchMeals();
  }, []);

  return (
    <ScrollView horizontal style={styles.scrollView}>
      {meals.map((meal) => (
        <Card key={meal.id} containerStyle={styles.card}>
          <Card.Title>{meal.name}</Card.Title>
          <Card.Divider />
          <Text>Category: {meal.category}</Text>
          <Text>Area: {meal.area}</Text>
        </Card>
      ))}
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  scrollView: {
    flexDirection: 'row',
  },
  card: {
    width: 200,
    margin: 10,
    padding: 10,
    borderRadius: 10,
  },
});

export default Recommendations;