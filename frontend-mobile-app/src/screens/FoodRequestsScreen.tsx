import React, { useState, useEffect } from "react";
import { View, StyleSheet, ScrollView } from "react-native";
import { Text, Button, useTheme, ActivityIndicator } from "react-native-paper";
import ContributeRequestModal from "@components/ContributeRequestModal";
import FoodRequestCard from "@components/FoodRequestCard";
import { RequestService } from "@services/RequestService"; 
import ApiService from "@services/ApiService";
import type { FoodRequest, FoodRequestItem } from "@src/types/FoodRequest";
import type { FridgeItem } from "@src/types/FridgeItem";

const FoodRequestsScreen = () => {
  const { colors } = useTheme();
  const [requests, setRequests] = useState<FoodRequest[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [selectedRequest, setSelectedRequest] = useState<FoodRequest | null>(null);
  const [modalVisible, setModalVisible] = useState(false);
  const [fridgeItems, setFridgeItems] = useState<any[]>([]);
  const [loadingFridgeItems, setLoadingFridgeItems] = useState(false);

  const fetchRequests = async () => {
    setLoading(true);
    setError(null);
    try {
      const data = await RequestService.getAllRequests();
      setRequests(data);
    } catch (err: any) {
      setError("Failed to load food requests.");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    const fetchFridgeItems = async () => {
      setLoadingFridgeItems(true);
      try {
        const items = await ApiService.getUserFridgeItems();
        setFridgeItems(items);
      } catch (error) {
        setFridgeItems([]);
      } finally {
        setLoadingFridgeItems(false);
      }
    };
    fetchFridgeItems();
  }, []);

  useEffect(() => {
    fetchRequests();
  }, []);

  useEffect(() => {
    if (!modalVisible) {
      fetchRequests();
    }
  }, [modalVisible, fridgeItems]);

  const handleContributePress = (request: FoodRequest) => {
    setSelectedRequest(request);
    setModalVisible(true);
  };

  const handleCloseModal = () => {
    setModalVisible(false);
    setSelectedRequest(null);
    fetchRequests();
  };

  function getFulfillableItems(requestItems: FoodRequestItem[], fridgeItems: FridgeItem[]): number[] {
    return requestItems.filter((item) => {
      const matchingFridgeItems = fridgeItems.filter(
        (fridgeItem) =>
          fridgeItem.food.ingredientOpenMealDbName.toLowerCase() === item.food.ingredientOpenMealDbName.toLowerCase() &&
          fridgeItem.unit.name === item.unit.name &&
          fridgeItem.quantity >= item.quantity
      );
      return matchingFridgeItems.length > 0;
    }).map(item => item.id);
  }

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
          requests
            .filter((request) => {
              if (!request.deadlineDate) return true;
              const deadline = new Date(request.deadlineDate);
              return deadline.getTime() >= Date.now();
            })
            .map((request) => {
              const items = request.items || [];
              const fulfillableItems = getFulfillableItems(items, fridgeItems);
              const requestWithStatus = {
                ...request,
                title: request.name,
                organization: request.organizationName,
                canFulfill: fulfillableItems.length > 0,
                fulfillableItems,
                items,
              };
              return (
                <FoodRequestCard
                  key={request.id}
                  request={requestWithStatus}
                  onContributePress={handleContributePress}
                />
              );
            })
        )}
      </ScrollView>

      <ContributeRequestModal
        visible={modalVisible}
        request={
          selectedRequest
            ? {
              ...selectedRequest,
              canFulfill: true,
              fulfillableItems: (selectedRequest.items || []).map(item => item.id),
            }
            : null
        }
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