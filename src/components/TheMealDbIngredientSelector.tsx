import React, { useState } from "react";
import { View, StyleSheet, ScrollView } from "react-native";
import { TextInput, Button, Dialog, Portal, List } from "react-native-paper";
import { IngredientOpenMealDb } from "@src/types/IngredientOpenMealDb";
import useIngredients from "@hooks/useIngredients";
import useIngredientSearch from "@hooks/useIngredientSearch";

interface TheMealDbIngredientSelectorProps {
  onSelectIngredient: (ingredient: IngredientOpenMealDb) => void;
}

const TheMealDbIngredientSelector: React.FC<
  TheMealDbIngredientSelectorProps
> = ({ onSelectIngredient }) => {
  const { ingredients, filteredIngredients, setFilteredIngredients } =
    useIngredients();
  const { searchQuery, handleSearch } = useIngredientSearch(
    ingredients,
    setFilteredIngredients
  );
  const [selectedIngredient, setSelectedIngredient] =
    useState<IngredientOpenMealDb | null>(null);
  const [dialogVisible, setDialogVisible] = useState(false);

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
