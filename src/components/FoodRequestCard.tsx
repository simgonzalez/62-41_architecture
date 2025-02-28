import React from "react";
import { View, StyleSheet } from "react-native";
import { Text, Card, Button, Chip } from "react-native-paper";
import { RequestWithFulfillmentStatus } from "@hooks/useFoodRequests";
import { formatDistanceToNow } from "date-fns/formatDistanceToNow";
import { parseISO } from "date-fns/parseISO";

interface FoodRequestCardProps {
  request: RequestWithFulfillmentStatus;
  onContributePress: (request: RequestWithFulfillmentStatus) => void;
}

const FoodRequestCard: React.FC<FoodRequestCardProps> = ({
  request,
  onContributePress,
}) => {
  const deadlineDate = parseISO(request.deadlineDateISO);
  const timeRemaining = formatDistanceToNow(deadlineDate, {
    addSuffix: true,
  });

  return (
    <Card
      style={[styles.card, { opacity: request.canFulfill ? 1 : 0.6 }]}
      mode="elevated"
    >
      <Card.Title title={request.title} subtitle={request.organization} />
      <Card.Content>
        <Text variant="bodyMedium">{request.description}</Text>
        <Text variant="labelLarge" style={styles.sectionTitle}>
          Requested Items:
        </Text>

        {request.items.map((item) => (
          <View key={item.id} style={styles.itemRow}>
            <Text>
              • {item.food.name}: {item.quantity.value} {item.quantity.unit}
            </Text>
            {request.fulfillableItems.includes(item.id) && (
              <Chip icon="check" mode="outlined" style={{ marginLeft: 8 }}>
                You have this
              </Chip>
            )}
          </View>
        ))}

        <Text variant="labelLarge" style={{ marginTop: 10 }}>
          Deadline: <Text>{timeRemaining}</Text>
        </Text>
      </Card.Content>
      <Card.Actions>
        <Button
          mode="contained"
          disabled={!request.canFulfill}
          onPress={() => onContributePress(request)}
        >
          Contribute
        </Button>
      </Card.Actions>
    </Card>
  );
};

const styles = StyleSheet.create({
  card: {
    marginBottom: 16,
    elevation: 2,
  },
  sectionTitle: {
    marginTop: 10,
    marginBottom: 5,
  },
  itemRow: {
    flexDirection: "row",
    alignItems: "center",
    marginVertical: 4,
  },
});

export default FoodRequestCard;
