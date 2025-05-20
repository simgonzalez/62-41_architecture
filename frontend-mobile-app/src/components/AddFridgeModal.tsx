import React, { useState } from "react";
import { View, StyleSheet, ScrollView } from "react-native";
import {
  TextInput,
  Text,
  useTheme,
  Modal,
  Portal,
  Button,
} from "react-native-paper";
import useCreateFridge from "@hooks/useCreateFridge";

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
  const { name, setName, handleCreateFridge } = useCreateFridge(
    onFridgeCreated,
    onDismiss
  );
  const [location, setLocation] = useState("");

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
          <TextInput
            value={location}
            onChangeText={setLocation}
            placeholder="Enter location"
            style={styles.input}
            theme={{
              colors: {
                text: colors.onSurface,
                placeholder: colors.onSurface,
              },
            }}
          />

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
