import React, { useEffect, useState } from "react";
import { View, StyleSheet, ScrollView } from "react-native";
import {
  TextInput,
  Button,
  useTheme,
  Dialog,
  Portal,
  List,
  IconButton,
} from "react-native-paper";
import { fetchIngredients } from "@src/services/IngredientService";
import { IngredientOpenMealDb } from "@src/types/IngredientOpenMealDb";

interface TheMealDbIngredientSelectorProps {
  onSelectIngredient: (ingredient: IngredientOpenMealDb) => void;
}

const TheMealDbIngredientSelector: React.FC<
  TheMealDbIngredientSelectorProps
> = ({ onSelectIngredient }) => {
  const theme = useTheme();
  const [ingredients, setIngredients] = useState<IngredientOpenMealDb[]>([]);
  const [filteredIngredients, setFilteredIngredients] = useState<
    IngredientOpenMealDb[]
  >([]);
  const [selectedIngredient, setSelectedIngredient] =
    useState<IngredientOpenMealDb | null>(null);
  const [dialogVisible, setDialogVisible] = useState(false);
  const [searchQuery, setSearchQuery] = useState("");

  useEffect(() => {
    const loadIngredients = async () => {
      try {
        const fetchedIngredients = await fetchIngredients();
        setIngredients(fetchedIngredients);
        setFilteredIngredients(fetchedIngredients.slice(0, 30));
      } catch (error) {
        console.error("Error loading ingredients:", error);
      }
    };
    loadIngredients();
  }, []);

  const handleSelectIngredient = (ingredient: IngredientOpenMealDb) => {
    onSelectIngredient(ingredient);
    setSelectedIngredient(ingredient);
    setSearchQuery(ingredient.strIngredient);
    setDialogVisible(false);
  };

  const handleSearch = (query: string) => {
    setSearchQuery(query);
    if (query) {
      const filtered = ingredients.filter((ingredient) =>
        ingredient.strIngredient.toLowerCase().includes(query.toLowerCase())
      );
      setFilteredIngredients(filtered.slice(0, 30));
    } else {
      setFilteredIngredients(ingredients.slice(0, 30));
    }
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
