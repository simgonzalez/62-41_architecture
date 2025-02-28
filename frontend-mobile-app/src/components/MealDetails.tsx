import { HydratedMeal } from "@src/types/Meal";
import React from "react";
import { Linking, ScrollView } from "react-native";
import { Button, Dialog, Divider, Text } from "react-native-paper";

interface MealDetailsProps {
  meal: HydratedMeal;
  visible: boolean;
  onClose: () => void;
}

const MealDetails: React.FC<MealDetailsProps> = ({
  meal,
  visible,
  onClose,
}) => {
  return (
    <Dialog visible={visible} onDismiss={onClose} style={{ height: "80%" }}>
      <Dialog.Title>{meal.strMeal}</Dialog.Title>
      <Dialog.ScrollArea>
        <ScrollView>
          <Text variant="labelLarge">
            Category: <Text>{meal.strCategory}</Text>
          </Text>
          <Text variant="labelLarge">
            Tags: <Text>{meal.strTags}</Text>
          </Text>
          <Text variant="labelLarge">
            Area: <Text>{meal.strArea}</Text>
          </Text>
          <Divider />
          <Text variant="labelLarge">Instructions: </Text>
          <Text>{meal.strInstructions}</Text>
          {meal.strYoutube && (
            <Button
              mode={"text"}
              onPress={() => Linking.openURL(meal.strYoutube!)}
            >
              Watch on YouTube
            </Button>
          )}
        </ScrollView>
      </Dialog.ScrollArea>
      <Dialog.Actions>
        <Button onPress={onClose}>Close</Button>
      </Dialog.Actions>
    </Dialog>
  );
};

export default MealDetails;
