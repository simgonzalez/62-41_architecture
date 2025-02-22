import React, { useState } from "react";
import { View } from "react-native";
import { useNavigation, useRoute } from "@react-navigation/native";
import { Fridge } from "@src/types/Fridge";
import { IconButton, Menu } from "react-native-paper";
import { useSnackbar } from "./SnackbarProvider";
import { addFridge, deleteFridge } from "@src/services/FridgeService";

const FridgeDetailsMenu = () => {
  const route = useRoute();
  const { fridge } = route.params as { fridge: Fridge };
  const navigation = useNavigation();
  const { showSnackbar } = useSnackbar();

  const [menuVisible, setMenuVisible] = useState(false);
  const openMenu = () => setMenuVisible(true);
  const closeMenu = () => setMenuVisible(false);

  const handleDelete = async () => {
    const success = await deleteFridge(fridge.id);

    if (success) {
      showSnackbar("The fridge has been successfully deleted.", () => {
        addFridge(fridge);
      });

      navigation.goBack();
    } else {
      showSnackbar("There was an error deleting the fridge.");
    }
  };
  return (
    <Menu
      visible={menuVisible}
      onDismiss={closeMenu}
      anchor={
        <View>
          <IconButton icon="dots-vertical" size={24} onPress={openMenu} />
        </View>
      }
      anchorPosition={"bottom"}
    >
      <Menu.Item
        onPress={() => {
          closeMenu();
          handleDelete();
        }}
        title="Delete"
      />
    </Menu>
  );
};

export default FridgeDetailsMenu;
