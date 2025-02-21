import React from 'react';
import { ScrollView, View, StyleSheet, Dimensions } from 'react-native';
import { Divider, Text } from '@rneui/themed';
import UserManagement from '@components/UserManagement';
import FoodManagement from '@components/FoodManagement';
import Recommendations from '@components/Recommendations';

const { width } = Dimensions.get('window');

const HomeScreen = () => {
  return (
    <ScrollView contentContainerStyle={styles.container}>
      <View style={styles.section}>
        <Text h4>User Management</Text>
        <UserManagement />
      </View>
      <Divider />
      <View style={styles.section}>
        <Text h4>Food Management</Text>
        <FoodManagement />
      </View>
      <Divider />
      <View style={styles.section}>
        <Text h4>Recommendations</Text>
        <Recommendations />
      </View>
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  container: {
    flexGrow: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'flex-start',
    padding: 20,
  },
  section: {
    marginBottom: 20,
    width: '100%',
  },
  sectionTitle: {
    fontSize: 18,
    fontWeight: 'bold',
    marginBottom: 10,
  },
  card: {
    width: width - 40, // Adjust the card width to be adaptive
    margin: 10,
    padding: 10,
    borderRadius: 10,
  },
});

export default HomeScreen;
