import React, { useState, useEffect } from "react";
import { View, StyleSheet, useColorScheme } from "react-native";
import { Text, Switch } from "react-native-paper";

const UserScreen = () => {
  const colorScheme = useColorScheme();
  const [isDarkMode, setIsDarkMode] = useState(colorScheme === "dark");

  useEffect(() => {
    setIsDarkMode(colorScheme === "dark");
  }, [colorScheme]);

  const toggleDarkMode = () => {
    setIsDarkMode((prevMode) => !prevMode);
  };

  return (
    <View style={styles.container}>
      <Text variant="titleLarge">User Preferences and Info</Text>
      <View style={styles.preferenceContainer}>
        <Text>Dark Mode</Text>
        <Switch value={isDarkMode} onValueChange={toggleDarkMode} />
      </View>
      {/* Add more components to manage user preferences and info */}
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: "center",
    justifyContent: "center",
  },
  preferenceContainer: {
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "space-between",
    width: "80%",
    marginTop: 20,
  },
});

export default UserScreen;
