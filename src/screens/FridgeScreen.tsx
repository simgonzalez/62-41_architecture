import React from 'react';
import { View, Text, StyleSheet } from 'react-native';

const FridgeScreen = () => {
  return (
    <View style={styles.container}>
      <Text>Fridge Details</Text>
      {/* Add components to manage specific fridge details */}
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});

export default FridgeScreen;