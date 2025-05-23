import React, { useState, useEffect } from "react";
import { View, StyleSheet, ScrollView } from "react-native";
import { TextInput, Button, Dialog, Portal, List } from "react-native-paper";
import { Food } from "@src/types/Food";
import ApiService from "@services/ApiService";

interface TheMealDbIngredientSelectorProps {
  onSelectIngredient: (food: Food) => void;
  initialFood?: Food | null;
}

const TheMealDbIngredientSelector: React.FC<
  TheMealDbIngredientSelectorProps
> = ({ onSelectIngredient, initialFood = null }) => {
  const [foods, setFoods] = useState<Food[]>([]);
  const [filteredFoods, setFilteredFoods] = useState<Food[]>([]);
  const [searchQuery, setSearchQuery] = useState("");
  const [dialogVisible, setDialogVisible] = useState(false);

  useEffect(() => {
    ApiService.get("foods").then((data) => {
      setFoods(data);
      setFilteredFoods(data);
    });
  }, []);

  useEffect(() => {
    if (initialFood && foods.length > 0) {
      const matchingFood = foods.find(
        (food) => food.name.toLowerCase() === initialFood.name?.toLowerCase()
      );
      if (matchingFood) {
        setSearchQuery(matchingFood.name);
        setFilteredFoods([matchingFood]);
      } else {
        setSearchQuery(initialFood.name);
      }
    }
  }, [initialFood, foods]);

  const handleSearch = (query: string) => {
    setSearchQuery(query);
    setFilteredFoods(
      foods.filter((food) =>
        food.name.toLowerCase().includes(query.toLowerCase())
      )
    );
  };

  const handleSelectFood = (food: Food) => {
    onSelectIngredient(food);
    setSearchQuery(food.name);
    setDialogVisible(false);
  };

  return (
    <View style={styles.container}>
      <TextInput
        label="Select a food"
        value={searchQuery}
        onChangeText={handleSearch}
        right={
          <TextInput.Icon
            icon="magnify"
            onPress={() => setDialogVisible(true)}
          />
        }
      />
      <Portal>
        <Dialog
          visible={dialogVisible}
          onDismiss={() => setDialogVisible(false)}
        >
          <Dialog.Title>Select Food</Dialog.Title>
          <Dialog.Content style={styles.dialogContent}>
            <ScrollView>
              <List.Section>
                {filteredFoods.map((food) => (
                  <List.Item
                    key={food.id}
                    title={food.name}
                    onPress={() => handleSelectFood(food)}
                  />
                ))}
              </List.Section>
            </ScrollView>
          </Dialog.Content>
          <Dialog.Actions>
            <Button onPress={() => setDialogVisible(false)}>Cancel</Button>
          </Dialog.Actions>
        </Dialog>
      </Portal>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    marginBottom: 10,
  },
  dialogContent: {
    maxHeight: "80%",
  },
});

export default TheMealDbIngredientSelector;
