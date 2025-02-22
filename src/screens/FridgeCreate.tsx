import React, { useState, useEffect } from "react";
import { View, StyleSheet, ScrollView } from "react-native";
import { useNavigation } from "@react-navigation/native";
import { Fridge } from "@src/types/Fridge";
import { addFridge } from "@src/services/FridgeService";
import { useSnackbar } from "@components/SnackbarProvider";
import { TextInput, Text } from "react-native-paper";
import CustomButton from "@components/CustomButton";
import { Picker } from "@react-native-picker/picker";
import { getLocations } from "@src/services/FridgeLocationService";
import { FridgeLocation } from "@src/types/FridgeLocation";

const FridgeCreate = () => {
  const [name, setName] = useState("");
  const [location, setLocation] = useState<FridgeLocation | null>(null);
  const [locations, setLocations] = useState<FridgeLocation[]>([]);
  const navigation = useNavigation();
  const { showSnackbar } = useSnackbar();

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
      navigation.goBack();
    } else {
      showSnackbar("Error creating fridge");
    }
  };

  return (
    <ScrollView contentContainerStyle={styles.container}>
      <Text variant="labelLarge" style={styles.label}>
        Fridge Name
      </Text>
      <TextInput
        value={name}
        onChangeText={setName}
        placeholder="Enter fridge name"
      />

      <Text variant="labelLarge" style={styles.label}>
        Location
      </Text>
      <View style={styles.pickerContainer}>
        <Picker
          selectedValue={location?.id}
          onValueChange={(itemValue) => {
            const selectedLocation = locations.find(
              (loc) => loc.id === itemValue
            );
            setLocation(selectedLocation || null);
          }}
        >
          {locations.map((loc: FridgeLocation) => (
            <Picker.Item key={loc.id} label={loc.name} value={loc.id} />
          ))}
        </Picker>
      </View>

      <View style={styles.buttonContainer}>
        <CustomButton onPress={handleCreateFridge} text="Create Fridge" />
      </View>
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  container: {
    flexGrow: 1,
    padding: 20,
    backgroundColor: "#f5f5f5",
  },
  input: {
    marginBottom: 20,
  },
  label: {
    marginTop: 10,
    marginBottom: 5,
  },
  pickerContainer: {
    borderRadius: 8,
    overflow: "hidden",
    borderWidth: 1,
    borderColor: "#ccc",
  },
  buttonContainer: {
    alignItems: "center",
    marginTop: 20,
  },
});

export default FridgeCreate;
