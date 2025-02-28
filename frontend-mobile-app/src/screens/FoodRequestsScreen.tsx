import React, { useState } from "react";
import { View, StyleSheet, ScrollView } from "react-native";
import { Text, Button, useTheme, ActivityIndicator } from "react-native-paper";
import useFoodRequests, {
  RequestWithFulfillmentStatus,
} from "@hooks/useFoodRequests";
import ContributeRequestModal from "@components/ContributeRequestModal";
import FoodRequestCard from "@components/FoodRequestCard";

const FoodRequestsScreen = () => {
  const { requests, loading, error, fetchRequests } = useFoodRequests();
  const { colors } = useTheme();
  const [selectedRequest, setSelectedRequest] =
    useState<RequestWithFulfillmentStatus | null>(null);
  const [modalVisible, setModalVisible] = useState(false);

  const handleContributePress = (request: RequestWithFulfillmentStatus) => {
    setSelectedRequest(request);
    setModalVisible(true);
  };

  const handleCloseModal = () => {
    setModalVisible(false);
    setSelectedRequest(null);
    fetchRequests();
  };

  if (loading) {
    return (
      <View style={[styles.container, styles.centered]}>
        <ActivityIndicator size="large" />
      </View>
    );
  }

  if (error) {
    return (
      <View style={[styles.container, styles.centered]}>
        <Text variant="bodyLarge" style={{ color: colors.error }}>
          {error}
        </Text>
        <Button onPress={fetchRequests} style={{ marginTop: 10 }}>
          Retry
        </Button>
      </View>
    );
  }

  return (
    <View style={[styles.container, { backgroundColor: colors.background }]}>
      <ScrollView contentContainerStyle={styles.scrollContent}>
        {requests.length === 0 ? (
          <Text variant="bodyLarge" style={styles.emptyText}>
            No food donation requests available at this time.
          </Text>
        ) : (
          requests.map((request) => (
            <FoodRequestCard
              key={request.id}
              request={request}
              onContributePress={handleContributePress}
            />
          ))
        )}
      </ScrollView>

      <ContributeRequestModal
        visible={modalVisible}
        request={selectedRequest}
        onClose={handleCloseModal}
      />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 16,
  },
  centered: {
    justifyContent: "center",
    alignItems: "center",
  },
  scrollContent: {
    paddingBottom: 20,
  },
  header: {
    marginBottom: 16,
  },
  emptyText: {
    textAlign: "center",
    marginTop: 20,
  },
});

export default FoodRequestsScreen;
