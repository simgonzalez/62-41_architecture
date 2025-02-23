import React, { useState, useEffect } from "react";
import { View, StyleSheet, ScrollView, TouchableOpacity } from "react-native";
import { Fridge } from "@src/types/Fridge";
import { addFridge } from "@src/services/FridgeService";
import { useSnackbar } from "@components/SnackbarProvider";
import {
  TextInput,
  Text,
  useTheme,
  Modal,
  Portal,
  Button,
  Dialog,
  List,
} from "react-native-paper";
import { getLocations } from "@src/services/FridgeLocationService";
import { FridgeLocation } from "@src/types/FridgeLocation";

interface FridgeCreateModalProps {
  visible: boolean;
  onDismiss: () => void;
  onFridgeCreated: () => void;
}

const FridgeCreateModal: React.FC<FridgeCreateModalProps> = ({
  visible,
  onDismiss,
  onFridgeCreated,
}) => {
  const [name, setName] = useState("");
  const [location, setLocation] = useState<FridgeLocation | null>(null);
  const [locations, setLocations] = useState<FridgeLocation[]>([]);
  const [locationDialogVisible, setLocationDialogVisible] = useState(false);
  const { showSnackbar } = useSnackbar();
  const { colors } = useTheme();

  useEffect(() => {
    const fetchLocations = async () => {
      const userLocations = await getLocations();
      setLocations(userLocations);
      setLocation(userLocations[0]);
    };

    fetchLocations();
  }, []);

  const handleCreateFridge = async () => {
    if (!location) {
      showSnackbar("Please select a location.");
      return;
    }

    const newFridge: Fridge = {
      id: Math.random(),
      name,
      location,
    };

    const success = await addFridge(newFridge);
    if (success) {
      showSnackbar("The fridge has been successfully created.");
      onFridgeCreated();
      onDismiss();
    } else {
      showSnackbar("Error creating fridge");
    }
  };

  const handleSelectLocation = (selectedLocation: FridgeLocation) => {
    setLocation(selectedLocation);
    setLocationDialogVisible(false);
  };

  return (
    <Portal>
      <Modal
        visible={visible}
        onDismiss={onDismiss}
        contentContainerStyle={[
          styles.modalContainer,
          { backgroundColor: colors.background },
        ]}
      >
        <ScrollView contentContainerStyle={styles.container}>
          <Text
            variant="labelLarge"
            style={[styles.label, { color: colors.onBackground }]}
          >
            Fridge Name
          </Text>
          <TextInput
            value={name}
            onChangeText={setName}
            placeholder="Enter fridge name"
            style={styles.input}
            theme={{
              colors: { text: colors.onSurface, placeholder: colors.onSurface },
            }}
          />

          <Text
            variant="labelLarge"
            style={[styles.label, { color: colors.onBackground }]}
          >
            Location
          </Text>
          <TouchableOpacity onPress={() => setLocationDialogVisible(true)}>
            <TextInput
              value={location?.name ?? ""}
              placeholder="Select location"
              style={styles.input}
              editable={false}
              right={
                <TextInput.Icon
                  icon="chevron-down"
                  onPress={() => setLocationDialogVisible(true)}
                />
              }
              theme={{
                colors: {
                  text: colors.onSurface,
                  placeholder: colors.onSurface,
                },
              }}
            />
          </TouchableOpacity>

          <View style={styles.buttonContainer}>
            <Button onPress={handleCreateFridge} mode="contained">
              Create fridge
            </Button>
          </View>
        </ScrollView>
      </Modal>

      <Dialog
        visible={locationDialogVisible}
        onDismiss={() => setLocationDialogVisible(false)}
      >
        <Dialog.Title>Select Location</Dialog.Title>
        <Dialog.Content>
          {locations.map((loc) => (
            <List.Item
              key={loc.id}
              title={loc.name}
              onPress={() => handleSelectLocation(loc)}
            />
          ))}
        </Dialog.Content>
        <Dialog.Actions>
          <Button onPress={() => setLocationDialogVisible(false)}>
            Cancel
          </Button>
        </Dialog.Actions>
      </Dialog>
    </Portal>
  );
};

const styles = StyleSheet.create({
  modalContainer: {
    padding: 20,
    margin: 20,
    borderRadius: 8,
    maxHeight: "80%",
  },
  container: {
    flexGrow: 1,
    padding: 20,
  },
  input: {
    marginBottom: 20,
  },
  label: {
    marginTop: 10,
    marginBottom: 5,
  },
  buttonContainer: {
    alignItems: "center",
    marginTop: 20,
  },
});

export default FridgeCreateModal;
