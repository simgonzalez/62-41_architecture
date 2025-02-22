import React from "react";
import { View, StyleSheet } from "react-native";
import { Text } from "react-native-paper";

const UserScreen = () => {
  return (
    <View style={styles.container}>
      <Text variant="titleLarge">User Preferences and Info</Text>
      {/* Add components to manage user preferences and info */}
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: "center",
    justifyContent: "center",
  },
});

export default UserScreen;
