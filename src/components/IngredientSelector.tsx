import React, { useEffect, useState } from "react";
import { View, Text, Button, StyleSheet, TouchableOpacity } from "react-native";
import Autocomplete from "react-native-autocomplete-input";
import { fetchIngredients } from "@src/services/IngredientService";
import { IngredientOpenMealDb } from "@src/types/IngredientOpenMealDb";

const IngredientSelector = () => {
  const [ingredients, setIngredients] = useState<IngredientOpenMealDb[]>([]);
  const [filteredIngredients, setFilteredIngredients] = useState<
    IngredientOpenMealDb[]
  >([]);
  const [selectedIngredient, setSelectedIngredient] = useState<string>("");
  const [newIngredient, setNewIngredient] = useState<string>("");
  const [showWarning, setShowWarning] = useState<boolean>(false);

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

  const handleAddNewIngredient = () => {
    if (newIngredient) {
      const newId = ingredients.length
        ? ingredients[ingredients.length - 1].idIngredient + 1
        : 1;
      setIngredients([
        ...ingredients,
        {
          idIngredient: newId,
          strIngredient: newIngredient,
          strDescription: null,
          strType: null,
        },
      ]);
      setSelectedIngredient(newIngredient);
      setNewIngredient("");
      setShowWarning(false);
    }
  };

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

  const handleSelectIngredient = (ingredient: string) => {
    setSelectedIngredient(ingredient);
    setNewIngredient("");
    setShowWarning(false);
  };

  const handleInputChange = (text: string) => {
    setNewIngredient(text);
    findIngredient(text);
    setShowWarning(
      !ingredients.some(
        (ingredient) =>
          ingredient.strIngredient.toLowerCase() === text.toLowerCase()
      )
    );
  };

  return (
    <View style={styles.container}>
      <Text style={styles.label}>Select or Add Ingredient:</Text>
      <Autocomplete
        data={filteredIngredients}
        defaultValue={newIngredient}
        onChangeText={handleInputChange}
        placeholder="Enter ingredient"
        flatListProps={{
          keyExtractor: (item) => item.idIngredient.toString(),
          renderItem: ({ item }) => (
            <TouchableOpacity
              onPress={() => handleSelectIngredient(item.strIngredient)}
            >
              <Text>{item.strIngredient}</Text>
            </TouchableOpacity>
          ),
        }}
        style={styles.input}
      />
      <Button title="Add Ingredient" onPress={handleAddNewIngredient} />
      {showWarning && (
        <Text style={styles.warning}>
          Note: New ingredients are not eligible for recipe recommendations.
        </Text>
      )}
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    padding: 20,
  },
  label: {
    fontSize: 16,
    marginBottom: 10,
  },
  input: {
    height: 40,
    borderColor: "gray",
    borderWidth: 1,
    marginBottom: 20,
    paddingHorizontal: 10,
  },
  warning: {
    marginTop: 10,
    color: "red",
  },
});

export default IngredientSelector;
