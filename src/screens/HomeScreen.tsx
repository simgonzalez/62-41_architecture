import React from "react";
import { ScrollView, View, StyleSheet } from "react-native";
import { Text } from "react-native-paper";
import FoodManagement from "@components/FoodManagement";
import Recommendations from "@components/Recommendations";

const HomeScreen = () => {
  return (
    <ScrollView contentContainerStyle={styles.container}>
      <View style={styles.section}>
        <Text variant="titleLarge">Recommendations</Text>
        <Recommendations />
      </View>
      <View style={styles.section}>
        <Text variant="titleLarge">Food Management</Text>
        <FoodManagement />
      </View>
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  container: {
    flexGrow: 1,
    padding: 20,
  },
  section: {
    flex: 1,
    marginBottom: 20,
    width: "100%",
  },
});

export default HomeScreen;
