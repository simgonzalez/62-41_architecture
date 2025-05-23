import React from "react";
import { View, StyleSheet } from "react-native";
import { Button, useTheme } from "react-native-paper";
import { useNavigation } from "@react-navigation/native";
import type { StackNavigationProp } from '@react-navigation/stack';
import ApiService from "../services/ApiService";
type RootStackParamList = {
  Login: undefined;
  // add other routes here if needed
};

const UserScreen = () => {
  const { colors } = useTheme();
  const navigation = useNavigation<StackNavigationProp<RootStackParamList>>();

  const handleLogout = async () => {
    try {
      await ApiService.post("logout", {});
      ApiService.setToken(""); 
      navigation.reset({
        index: 0,
        routes: [{ name: "Login" }],
      });
    } catch (error) {
      console.error("Logout failed:", error);
    }
  };

  const handleDeleteAccount = async () => {
    try {
      await ApiService.delete("user");
      ApiService.setToken("");
      navigation.reset({
        index: 0,
        routes: [{ name: "Login" }],
      });
    } catch (error) {
      console.error("Delete account failed:", error);
    }
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