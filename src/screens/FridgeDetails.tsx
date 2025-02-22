import React from "react";
import { View, StyleSheet } from "react-native";
import { useRoute } from "@react-navigation/native";
import { Fridge } from "@src/types/Fridge";
import { Text } from "react-native-paper";
import Icon from "react-native-vector-icons/MaterialIcons";

const FridgeDetails = () => {
  const route = useRoute();
  const { fridge } = route.params as { fridge: Fridge };

  return (
    <View style={styles.container}>
      <View style={styles.locationContainer}>
        <Icon name="location-on" size={24} color="black" />
        <Text variant="bodyLarge" style={styles.locationText}>
          {fridge.location.name}
        </Text>
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
  },
  locationContainer: {
    flexDirection: "row",
    alignItems: "center",
  },
  locationText: {
    marginLeft: 8,
  },
});

export default FridgeDetails;
