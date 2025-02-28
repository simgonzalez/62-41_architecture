import React, { useState, useEffect } from "react";
import { View, StyleSheet, ScrollView } from "react-native";
import { TextInput, Button, Dialog, Portal, List } from "react-native-paper";
import { IngredientOpenMealDb } from "@src/types/IngredientOpenMealDb";
import { Food } from "@src/types/Food";
import useIngredients from "@hooks/useIngredients";
import useIngredientSearch from "@hooks/useIngredientSearch";

interface TheMealDbIngredientSelectorProps {
  onSelectIngredient: (ingredient: IngredientOpenMealDb) => void;
  initialFood?: Food | null;
}

const TheMealDbIngredientSelector: React.FC<
  TheMealDbIngredientSelectorProps
> = ({ onSelectIngredient, initialFood = null }) => {
  const { ingredients, filteredIngredients, setFilteredIngredients } =
    useIngredients();
  const { searchQuery, handleSearch } = useIngredientSearch(
    ingredients,
    setFilteredIngredients
  );
  const [selectedIngredient, setSelectedIngredient] =
    useState<IngredientOpenMealDb | null>(null);
  const [dialogVisible, setDialogVisible] = useState(false);

  useEffect(() => {
    if (initialFood && ingredients.length > 0) {
      const matchingIngredient = ingredients.find(
        (ingredient) =>
          ingredient.strIngredient.toLowerCase() ===
          initialFood.name?.toLowerCase()
      );

      if (matchingIngredient) {
        setSelectedIngredient(matchingIngredient);
        handleSearch(matchingIngredient.strIngredient);
      } else {
        handleSearch(initialFood.name);
      }
    }
  }, [initialFood, ingredients]);

  const handleSelectIngredient = (ingredient: IngredientOpenMealDb) => {
    onSelectIngredient(ingredient);
    setSelectedIngredient(ingredient);
    handleSearch(ingredient.strIngredient);
    setDialogVisible(false);
  };

  return (
    <View style={styles.container}>
      <TextInput
        label="Select an ingredient"
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
          <Dialog.Title>Select Ingredient</Dialog.Title>
          <Dialog.Content style={styles.dialogContent}>
            <ScrollView>
              <List.Section>
                {filteredIngredients.map((ingredient) => (
                  <List.Item
                    key={ingredient.idIngredient}
                    title={ingredient.strIngredient}
                    onPress={() => handleSelectIngredient(ingredient)}
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
