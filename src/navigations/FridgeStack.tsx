import React from "react";
import { createStackNavigator } from "@react-navigation/stack";
import FridgesScreen from "@screens/FridgesScreen";
import FridgeDetails from "@screens/FridgeDetails";
import { RouteProp } from "@react-navigation/native";
import { Fridge } from "@src/types/Fridge";
import FridgeCreate from "@src/screens/FridgeCreate";
import FridgeDetailsMenu from "@src/components/FridgeDetailsMenu";
import { View } from "react-native";

export type FridgeStackParamList = {
  Fridges: undefined;
  FridgeDetails: { fridge: Fridge };
  CreateFridge: undefined;
};

const Stack = createStackNavigator<FridgeStackParamList>();

const FridgeStack = () => (
  <Stack.Navigator>
    <Stack.Screen
      name="Fridges"
      component={FridgesScreen}
      options={{
        title: "My Fridges",
        headerTitleStyle: { fontWeight: "bold" },
      }}
    />
    <Stack.Screen
      name="FridgeDetails"
      component={FridgeDetails}
      options={({
        route,
      }: {
        route: RouteProp<FridgeStackParamList, "FridgeDetails">;
      }) => ({
        title: route.params.fridge.name,
        headerRight: () => (
          <View style={{ marginRight: 10 }}>
            <FridgeDetailsMenu />
          </View>
        ),
      })}
    />
    <Stack.Screen
      name="CreateFridge"
      component={FridgeCreate}
      options={{
        title: "Create New Fridge",
      }}
    />
  </Stack.Navigator>
);

export default FridgeStack;
