import React from 'react';
import { ScrollView, View, Text, StyleSheet } from 'react-native';
import { Card } from '@rneui/themed';

const UserManagement = () => {
  return (
    <ScrollView horizontal style={styles.scrollView}>
      <Card containerStyle={styles.card}>
        <Card.Title>Admin</Card.Title>
        <Card.Divider />
        <Text>Admin user details...</Text>
      </Card>
      <Card containerStyle={styles.card}>
        <Card.Title>Normal User</Card.Title>
        <Card.Divider />
        <Text>Normal user details...</Text>
      </Card>
      <Card containerStyle={styles.card}>
        <Card.Title>Normal User</Card.Title>
        <Card.Divider />
        <Text>Normal user details...</Text>
      </Card>
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  scrollView: {
    flexDirection: 'row',
  },
  card: {
    width: 200,
    margin: 10,
    padding: 10,
    borderRadius: 10,
  },
});

export default UserManagement;