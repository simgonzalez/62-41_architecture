import React from "react";
import { ScrollView, StyleSheet } from "react-native";
import { Card, Text } from "react-native-paper";

const UserManagement = () => {
  return (
    <ScrollView horizontal style={styles.scrollView}>
      <Card style={styles.card}>
        <Card.Title title="Admin" />
        <Card.Content>
          <Text>Admin user details...</Text>
        </Card.Content>
      </Card>
      <Card style={styles.card}>
        <Card.Title title="Normal User" />
        <Card.Content>
          <Text>Normal user details...</Text>
        </Card.Content>
      </Card>
      <Card style={styles.card}>
        <Card.Title title="Normal User" />
        <Card.Content>
          <Text>Normal user details...</Text>
        </Card.Content>
      </Card>
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  scrollView: {
    flexDirection: "row",
  },
  card: {
    width: 200,
    margin: 10,
    padding: 10,
    borderRadius: 10,
  },
});

export default UserManagement;
