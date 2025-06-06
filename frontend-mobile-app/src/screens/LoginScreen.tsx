import React, { useState } from "react";
import { View, StyleSheet } from "react-native";
import { TextInput, Button, Text, useTheme, HelperText } from "react-native-paper";
import { useNavigation } from "@react-navigation/native";
import ApiService from "@services/ApiService";

const LoginScreen = () => {
  const navigation = useNavigation();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const { colors } = useTheme();

  const handleLogin = async () => {
    if (!email.trim() || !password) {
      setError("Please provide both email and password.");
      return;
    }
    setError("");
    try {
      const token = await ApiService.login(email, password);
      ApiService.setToken(token);
      navigation.navigate("Main");
    } catch (err) {
      setError("Invalid email or password.");
    }
  };

  const handleRegister = () => {
    navigation.navigate("Register");
  };

  return (
    <View style={[styles.container, { backgroundColor: colors.background }]}>
      <Text
        variant="headlineLarge"
        style={[styles.title, { color: colors.primary }]}
      >
        Welcome to Smart Fridge
      </Text>
      <Text
        variant="titleMedium"
        style={[styles.subtitle, { color: colors.onSurface }]}
      >
        Your smart way to manage groceries
      </Text>
      <HelperText type="error" visible={!!error} style={{ textAlign: "center" }}>
        {error}
      </HelperText>
      <TextInput
        label="Email"
        value={email}
        onChangeText={(text) => setEmail(text)}
        style={styles.input}
        keyboardType="email-address"
        autoCapitalize="none"
        theme={{
          colors: { text: colors.onSurface, placeholder: colors.onSurface },
        }}
      />
      <TextInput
        label="Password"
        value={password}
        onChangeText={(text) => setPassword(text)}
        style={styles.input}
        secureTextEntry
        theme={{
          colors: { text: colors.onSurface, placeholder: colors.onSurface },
        }}
      />
      <Button mode="contained" onPress={handleLogin} style={styles.button}>
        Login
      </Button>
      <Button mode="outlined" onPress={handleRegister} style={styles.button}>
        Register
      </Button>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: "center",
    padding: 16,
  },
  title: {
    marginBottom: 10,
    textAlign: "center",
  },
  subtitle: {
    marginBottom: 20,
    textAlign: "center",
  },
  input: {
    marginBottom: 16,
  },
  button: {
    marginTop: 16,
  },
});

export default LoginScreen;
