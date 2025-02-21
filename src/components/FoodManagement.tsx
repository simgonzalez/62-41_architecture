import React from 'react';
import { ScrollView, Text, StyleSheet } from 'react-native';
import { Card } from '@rneui/themed';

const FoodManagement = () => {
  return (
    <ScrollView horizontal style={styles.scrollView}>
      <Card containerStyle={styles.card}>
        <Card.Title>Milk</Card.Title>
        <Card.Divider />
        <Text>Details about Milk...</Text>
      </Card>
      <Card containerStyle={styles.card}>
        <Card.Title>Eggs</Card.Title>
        <Card.Divider />
        <Text>Details about Eggs...</Text>
      </Card>
      {/* Add more food items as needed */}
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

export default FoodManagement;