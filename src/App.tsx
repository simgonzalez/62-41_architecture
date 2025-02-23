import React from "react";
import {
  MD3DarkTheme,
  MD3LightTheme,
  Provider as PaperProvider,
} from "react-native-paper";
import { SnackbarProvider } from "@components/SnackbarProvider";
import LoginNavigation from "./navigations/LoginNavigation";
import { useColorScheme } from "react-native";
import { useMaterial3Theme } from "@pchmn/expo-material3-theme";

const App = () => {
  const colorScheme = useColorScheme();
  const { theme } = useMaterial3Theme();

  const paperTheme =
    colorScheme === "dark"
      ? { ...MD3DarkTheme, colors: theme.dark }
      : { ...MD3LightTheme, colors: theme.light };

  return (
    <PaperProvider theme={paperTheme}>
      <SnackbarProvider>
        <LoginNavigation />
      </SnackbarProvider>
    </PaperProvider>
  );
};

export default App;
