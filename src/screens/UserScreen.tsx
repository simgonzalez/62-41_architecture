import React from "react";
import { View, StyleSheet } from "react-native";
import { Button, useTheme } from "react-native-paper";

const UserScreen = () => {
  const { colors } = useTheme();

  const handleLogout = () => {
    // TODO Implement logout functionality here
  };

  const handleDeleteAccount = () => {
    // TODO Implement delete account functionality here
  };

  return (
    <View style={[styles.container, { backgroundColor: colors.background }]}>
      <Button
        mode="contained"
        onPress={handleLogout}
        style={[styles.button, { backgroundColor: colors.primary }]}
      >
        Logout
      </Button>
      <Button
        mode="contained-tonal"
        onPress={handleDeleteAccount}
        style={[styles.button]}
      >
        Delete Account
      </Button>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: "center",
    justifyContent: "center",
    padding: 20,
  },
  title: {
    marginBottom: 20,
  },
  button: {
    width: "100%",
    marginTop: 10,
  },
});

export default UserScreen;
