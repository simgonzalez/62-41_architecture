import React, { useState, useEffect } from "react";
import FridgesList from "@src/components/FridgesList";
import { Fridge } from "@src/types/Fridge";
import { useIsFocused } from "@react-navigation/native";
import { FridgeService } from "@src/services/FridgeService";
import { View, StyleSheet } from "react-native";
import { Text, useTheme, FAB } from "react-native-paper";
import { useSnackbar } from "@src/contexts/SnackbarProvider";
import AddFridgeModal from "@src/components/AddFridgeModal";
import useFridges from "@hooks/useFridges";

const FridgesScreen = () => {
  const { fridges, error, loadFridges } = useFridges();
  const [modalVisible, setModalVisible] = useState(false);
  const isFocused = useIsFocused();
  const { showSnackbar } = useSnackbar();
  const { colors } = useTheme();

  const handleCreateFridge = () => {
    setModalVisible(true);
  };

  const handleDeleteFridge = async (fridge: Fridge) => {
    const success = await FridgeService.delete(fridge.id);
    loadFridges();

    if (success) {
      showSnackbar("The fridge has been successfully deleted.", () => {
        FridgeService.create(fridge);
      });
    } else {
      showSnackbar("There was an error deleting the fridge.");
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
      <AddFridgeModal
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
