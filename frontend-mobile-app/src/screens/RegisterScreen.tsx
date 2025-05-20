import React, { useState } from "react";
import { View, StyleSheet } from "react-native";
import { TextInput, Button, Text, useTheme } from "react-native-paper";
import { useNavigation } from "@react-navigation/native";
import ApiService from "@services/ApiService";

const RegisterScreen = () => {
  const navigation = useNavigation();
  const [firstName, setFirstName] = useState("");
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);
  const { colors } = useTheme();

  const handleRegister = async () => {
    setError(null);
    if (!firstName || !name || !email || !password || !confirmPassword) {
      setError("Please fill in all fields.");
      return;
    }
    if (password !== confirmPassword) {
      setError("Passwords do not match.");
      return;
    }
    setLoading(true);
    try {
      await ApiService.register(
        email,
        password,
        confirmPassword,
        firstName,
        name
      );
      navigation.navigate("Main");
    } catch (err: any) {
      setError("Registration failed. Please try again.");
    } finally {
      setLoading(false);
    }
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
      {error && (
        <Text
          style={{
            color: colors.error,
            marginBottom: 8,
            textAlign: "center",
          }}
        >
          {error}
        </Text>
      )}
      <TextInput
        label="First Name"
        value={firstName}
        onChangeText={setFirstName}
        style={styles.input}
        autoCapitalize="words"
        theme={{
          colors: { text: colors.onSurface, placeholder: colors.onSurface },
        }}
      />
      <TextInput
        label="Last Name"
        value={name}
        onChangeText={setName}
        style={styles.input}
        autoCapitalize="words"
        theme={{
          colors: { text: colors.onSurface, placeholder: colors.onSurface },
        }}
      />
      <TextInput
        label="Email"
        value={email}
        onChangeText={setEmail}
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
        onChangeText={setPassword}
        style={styles.input}
        secureTextEntry
        theme={{
          colors: { text: colors.onSurface, placeholder: colors.onSurface },
        }}
      />
      <TextInput
        label="Confirm Password"
        value={confirmPassword}
        onChangeText={setConfirmPassword}
        style={styles.input}
        secureTextEntry
        theme={{
          colors: { text: colors.onSurface, placeholder: colors.onSurface },
        }}
      />
      <Button
        mode="contained"
        onPress={handleRegister}
        style={styles.button}
        loading={loading}
        disabled={loading}
      >
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
