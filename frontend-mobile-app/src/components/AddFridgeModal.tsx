import React, { useState } from "react";
import { View, StyleSheet, ScrollView, TouchableOpacity } from "react-native";
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
import useLocations from "@src/hooks/useLocations";
import useCreateFridge from "@hooks/useCreateFridge";
import { FridgeLocation } from "@src/types/FridgeLocation";

interface FridgeCreateModalProps {
  visible: boolean;
  onDismiss: () => void;
  onFridgeCreated: () => void;
}

const AddFridgeModal: React.FC<FridgeCreateModalProps> = ({
  visible,
  onDismiss,
  onFridgeCreated,
}) => {
  const { colors } = useTheme();
  const { locations, location, setLocation } = useLocations();
  const { name, setName, handleCreateFridge } = useCreateFridge(
    onFridgeCreated,
    onDismiss
  );
  const [locationDialogVisible, setLocationDialogVisible] = useState(false);

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
            <Button
              onPress={() => handleCreateFridge(location)}
              mode="contained"
            >
              Create fridge
            </Button>
          </View>
        </ScrollView>
      </Modal>

      <Dialog
        visible={locationDialogVisible}
        onDismiss={() => setLocationDialogVisible(false)}
        style={{ height: "80%" }}
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

export default AddFridgeModal;
