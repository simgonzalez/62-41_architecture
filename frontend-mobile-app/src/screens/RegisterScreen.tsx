import React, { useState } from "react";
import { View, StyleSheet } from "react-native";
import { TextInput, Button, Text, useTheme } from "react-native-paper";
import { useNavigation } from "@react-navigation/native";

const RegisterScreen = () => {
  const navigation = useNavigation();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const { colors } = useTheme();

  const handleRegister = () => {
    console.log("Email:", email);
    console.log("Password:", password);
    console.log("Confirm Password:", confirmPassword);

    // TODO Add your registration logic here

    navigation.navigate("Main");
  };

  return (
    <View style={[styles.container, { backgroundColor: colors.background }]}>
      <Text
        variant="headlineLarge"
        style={[styles.title, { color: colors.primary }]}
      >
        Register for Smart Fridge
      </Text>
      <Text
        variant="titleMedium"
        style={[styles.subtitle, { color: colors.onSurface }]}
      >
        Create your account to manage groceries
      </Text>
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
      <TextInput
        label="Confirm Password"
        value={confirmPassword}
        onChangeText={(text) => setConfirmPassword(text)}
        style={styles.input}
        secureTextEntry
        theme={{
          colors: { text: colors.onSurface, placeholder: colors.onSurface },
        }}
      />
      <Button mode="contained" onPress={handleRegister} style={styles.button}>
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

export default RegisterScreen;
