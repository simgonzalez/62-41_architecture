import React, { useEffect, useState } from "react";
import { View, StyleSheet } from "react-native";
import { TextInput, List, TouchableRipple } from "react-native-paper";
import {
  AutocompleteDropdown,
  AutocompleteDropdownContextProvider,
} from "react-native-autocomplete-dropdown";
import { fetchIngredients } from "@src/services/IngredientService";
import { IngredientOpenMealDb } from "@src/types/IngredientOpenMealDb";

interface TheMealDbIngredientSelectorProps {
  onSelectIngredient: (ingredient: IngredientOpenMealDb) => void;
}

const TheMealDbIngredientSelector: React.FC<
  TheMealDbIngredientSelectorProps
> = ({ onSelectIngredient }) => {
  const [ingredients, setIngredients] = useState<IngredientOpenMealDb[]>([]);
  const [filteredIngredients, setFilteredIngredients] = useState<
    IngredientOpenMealDb[]
  >([]);
  const [query, setQuery] = useState<string>("");

  useEffect(() => {
    const loadIngredients = async () => {
      try {
        const fetchedIngredients = await fetchIngredients();
        setIngredients(fetchedIngredients);
      } catch (error) {
        console.error("Error loading ingredients:", error);
      }
    };
    loadIngredients();
  }, []);

  const findIngredient = (query: string) => {
    if (query) {
      const regex = new RegExp(`${query.trim()}`, "i");
      setFilteredIngredients(
        ingredients.filter(
          (ingredient) => ingredient.strIngredient.search(regex) >= 0
        )
      );
    } else {
      setFilteredIngredients([]);
    }
  };

  const handleSelectIngredient = (
    item: { id: string; title: string } | null
  ) => {
    if (!item) return;
    const ingredient = ingredients.find(
      (ing) => ing.idIngredient.toString() === item.id
    );
    if (ingredient) {
      onSelectIngredient(ingredient);
      setQuery(ingredient.strIngredient);
      setFilteredIngredients([]);
    }
  };

  const handleInputChange = (text: string) => {
    setQuery(text);
    findIngredient(text);
  };

  return (
    <View style={styles.container}>
      <AutocompleteDropdownContextProvider>
        <AutocompleteDropdown
          dataSet={filteredIngredients.map((ingredient) => ({
            id: ingredient.idIngredient.toString(),
            title: ingredient.strIngredient,
          }))}
          onChangeText={handleInputChange}
          onSelectItem={handleSelectIngredient}
          debounce={300}
          inputContainerStyle={styles.inputContainer}
          suggestionsListContainerStyle={styles.list}
          textInputProps={{
            placeholder: "Enter ingredient",
            value: query,
            style: styles.input,
            placeholderTextColor: "#6200ee", // React Native Paper default placeholder color
          }}
          renderItem={(item) => (
            <TouchableRipple onPress={() => handleSelectIngredient(item)}>
              <List.Item title={item.title} />
            </TouchableRipple>
          )}
        />
      </AutocompleteDropdownContextProvider>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    zIndex: 1,
  },
  input: {
    marginBottom: 20,
    borderWidth: 1,
    borderColor: "#6200ee", // React Native Paper default border color
    padding: 10,
    borderRadius: 5,
    color: "#6200ee", // React Native Paper default text color
  },
  inputContainer: {
    borderWidth: 0,
  },
  list: {
    maxHeight: 200,
    zIndex: 3,
  },
});

export default TheMealDbIngredientSelector;
