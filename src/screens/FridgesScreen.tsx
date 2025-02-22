import React, { useEffect, useState } from "react";
import FridgesList from "@src/components/FridgesList";
import { Fridge } from "@src/types/Fridge";
import {
  NavigationProp,
  useIsFocused,
  useNavigation,
} from "@react-navigation/native";
import {
  addFridge,
  deleteFridge,
  fetchFridges,
} from "@src/services/FridgeService";
import { View, StyleSheet } from "react-native";
import { Text } from "react-native-paper";
import { FridgeStackParamList } from "@src/navigations/FridgeStack";
import CustomButton from "@src/components/CustomButton";
import { useSnackbar } from "@src/components/SnackbarProvider";

const FridgesScreen = () => {
  const [fridges, setFridges] = useState<Fridge[]>([]);
  const [error, setError] = useState<string | null>(null);
  const isFocused = useIsFocused();
  const navigation = useNavigation<NavigationProp<FridgeStackParamList>>();
  const { showSnackbar } = useSnackbar();

  const handleCreateFridge = () => {
    navigation.navigate("CreateFridge");
  };

  const handleDeleteFridge = async (fridge: Fridge) => {
    const success = await deleteFridge(fridge.id);
    loadFridges();

    if (success) {
      showSnackbar("The fridge has been successfully deleted.", () => {
        addFridge(fridge);
      });
    } else {
      showSnackbar("There was an error deleting the fridge.");
    }
  };

  const loadFridges = async () => {
    try {
      const fetchedFridges = await fetchFridges();
      setFridges(fetchedFridges);
      setError(null);
    } catch (err) {
      setError("Error loading fridges");
    }
  };

  useEffect(() => {
    if (isFocused) {
      loadFridges();
    }
  }, [isFocused]);

  return (
    <View style={styles.container}>
      {error ? (
        <Text variant="bodyLarge" style={styles.error}>
          {error}
        </Text>
      ) : (
        <FridgesList fridges={fridges} onDeleteFridge={handleDeleteFridge} />
      )}

      <View style={styles.buttonContainer}>
        <CustomButton onPress={handleCreateFridge} text="Create New Fridge" />
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 16,
  },
  error: {
    color: "red",
    fontSize: 16,
    textAlign: "center",
    marginTop: 20,
  },
  buttonContainer: {
    alignItems: "center",
    marginTop: 10,
  },
});

export default FridgesScreen;
