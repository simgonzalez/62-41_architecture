import React from "react";
import { Provider as PaperProvider } from "react-native-paper";
import { SnackbarProvider } from "@components/SnackbarProvider";
import LoginNavigation from "./navigations/LoginNavigation";

const App = () => {
  return (
    <PaperProvider>
      <SnackbarProvider>
        <LoginNavigation />
      </SnackbarProvider>
    </PaperProvider>
  );
};

export default App;
