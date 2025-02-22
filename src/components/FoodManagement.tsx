import React from "react";
import { ScrollView, StyleSheet } from "react-native";
import { Card, Text } from "react-native-paper";

const FoodManagement = () => {
  return (
    <ScrollView horizontal style={styles.scrollView}>
      <Card style={styles.card}>
        <Card.Title title="Milk" />
        <Card.Content>
          <Text>Details about Milk...</Text>
        </Card.Content>
      </Card>
      <Card style={styles.card}>
        <Card.Title title="Eggs" />
        <Card.Content>
          <Text>Details about Eggs...</Text>
        </Card.Content>
      </Card>
      {/* Add more food items as needed */}
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

export default FoodManagement;
