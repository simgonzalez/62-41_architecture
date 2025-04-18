import React from "react";
import { StyleSheet, TouchableOpacity, View, FlatList } from "react-native";
import { useNavigation, NavigationProp } from "@react-navigation/native";
import { Fridge } from "@src/types/Fridge";
import { FridgeStackParamList } from "@navigations/FridgeStack";
import { Text, IconButton, useTheme } from "react-native-paper";
import ReanimatedSwipeable from "react-native-gesture-handler/ReanimatedSwipeable";

interface FridgesListProps {
  fridges: Fridge[];
  onDeleteFridge: (fridge: Fridge) => void;
}

const FridgesList: React.FC<FridgesListProps> = ({
  fridges,
  onDeleteFridge,
}) => {
  const navigation = useNavigation<NavigationProp<FridgeStackParamList>>();
  const { colors } = useTheme();

  const handlePress = (fridge: Fridge) => {
    navigation.navigate("FridgeDetails", { fridge });
  };

  const handleDelete = async (fridge: Fridge) => {
    onDeleteFridge(fridge);
  };

  const renderRightActions = (fridge: Fridge) => (
    <View>
      <TouchableOpacity onPress={() => handleDelete(fridge)}>
        <IconButton
          style={[styles.rightAction, { backgroundColor: colors.error }]}
          icon="delete"
          size={24}
          iconColor="white"
        />
      </TouchableOpacity>
    </View>
  );

  return (
    <View style={styles.container}>
      <FlatList
        data={fridges}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item: fridge }) => (
          <ReanimatedSwipeable
            renderRightActions={() => renderRightActions(fridge)}
            overshootRight={false}
          >
            <TouchableOpacity onPress={() => handlePress(fridge)}>
              <View style={[styles.item, { backgroundColor: colors.surface }]}>
                <IconButton icon={"fridge-outline"} size={24} />
                <View style={styles.itemText}>
                  <Text
                    variant="titleMedium"
                    style={{ color: colors.onSurface }}
                  >
                    {fridge.name}
                  </Text>
                  <Text style={{ color: colors.onSurface }}>
                    {fridge.location.name}
                  </Text>
                </View>
                <IconButton icon="chevron-right" size={24} />
              </View>
            </TouchableOpacity>
          </ReanimatedSwipeable>
        )}
        ListEmptyComponent={
          <Text style={[styles.emptyMessage, { color: colors.onSurface }]}>
            No fridges found
          </Text>
        }
        contentContainerStyle={styles.listContent}
      />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  listContent: {
    paddingVertical: 10,
  },
  item: {
    flexDirection: "row",
    alignItems: "center",
    padding: 15,
    marginVertical: 5,
    borderRadius: 8,
    shadowColor: "#000",
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.1,
    shadowRadius: 8,
    elevation: 2,
    width: "100%",
  },
  itemText: {
    flex: 1,
    marginLeft: 10,
  },
  emptyMessage: {
    textAlign: "center",
    marginTop: 20,
    fontSize: 16,
  },
  rightAction: {
    justifyContent: "center",
    alignItems: "center",
    borderRadius: 8,
    paddingVertical: 10,
    height: "88%",
    width: 75,
  },
});

export default FridgesList;
