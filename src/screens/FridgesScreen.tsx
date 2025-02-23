import React, { useEffect, useState } from "react";
import FridgesList from "@src/components/FridgesList";
import { Fridge } from "@src/types/Fridge";
import { useIsFocused } from "@react-navigation/native";
import {
  addFridge,
  deleteFridge,
  fetchFridges,
} from "@src/services/FridgeService";
import { View, StyleSheet } from "react-native";
import { Text, useTheme, FAB } from "react-native-paper";
import { useSnackbar } from "@src/components/SnackbarProvider";
import FridgeCreateModal from "@components/FridgeCreateModal";

const FridgesScreen = () => {
  const [fridges, setFridges] = useState<Fridge[]>([]);
  const [error, setError] = useState<string | null>(null);
  const [modalVisible, setModalVisible] = useState(false);
  const isFocused = useIsFocused();
  const { showSnackbar } = useSnackbar();
  const { colors } = useTheme();

  const handleCreateFridge = () => {
    setModalVisible(true);
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
    <View style={[styles.container, { backgroundColor: colors.background }]}>
      {error ? (
        <Text
          variant="bodyLarge"
          style={[styles.error, { color: colors.error }]}
        >
          {error}
        </Text>
      ) : (
        <FridgesList fridges={fridges} onDeleteFridge={handleDeleteFridge} />
      )}

      <FAB style={styles.fab} icon="plus" onPress={handleCreateFridge} />
      <FridgeCreateModal
        visible={modalVisible}
        onDismiss={() => setModalVisible(false)}
        onFridgeCreated={loadFridges}
      />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 16,
  },
  error: {
    fontSize: 16,
    textAlign: "center",
    marginTop: 20,
  },
  fab: {
    position: "absolute",
    right: 16,
    bottom: 16,
  },
});

export default FridgesScreen;
