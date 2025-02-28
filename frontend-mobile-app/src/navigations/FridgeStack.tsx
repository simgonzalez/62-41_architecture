import React from "react";
import { createStackNavigator } from "@react-navigation/stack";
import { RouteProp } from "@react-navigation/native";
import { View } from "react-native";
import { Appbar } from "react-native-paper";
import FridgesScreen from "@screens/FridgesScreen";
import FridgeDetailsScreen from "@src/screens/FridgeDetailsScreen";
import FridgeDetailsMenu from "@src/components/FridgeDetailsMenu";
import { Fridge } from "@src/types/Fridge";

export type FridgeStackParamList = {
  Fridges: undefined;
  FridgeDetails: { fridge: Fridge };
  CreateFridge: undefined;
};

const Stack = createStackNavigator<FridgeStackParamList>();

interface CustomAppbarProps {
  navigation: any;
  previous: any;
  title: string;
  rightComponent: React.ReactNode;
}

const CustomAppbar: React.FC<CustomAppbarProps> = ({
  navigation,
  previous,
  title,
  rightComponent,
}) => (
  <Appbar.Header elevated={true}>
    {previous ? <Appbar.BackAction onPress={navigation.goBack} /> : null}
    <Appbar.Content title={title} />
    {rightComponent}
  </Appbar.Header>
);

const FridgeStack = () => (
  <Stack.Navigator
    screenOptions={({ navigation, route }) => ({
      header: ({ navigation, route, options, back }) => {
        const title = options.headerTitle ?? options.title ?? route.name;

        return (
          <CustomAppbar
            navigation={navigation}
            previous={route.name === "Fridges" ? null : back}
            title={title}
            rightComponent={
              options.headerRight
                ? options.headerRight({ tintColor: options.headerTintColor })
                : null
            }
          />
        );
      },
    })}
  >
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
      component={FridgeDetailsScreen}
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
  </Stack.Navigator>
);

export default FridgeStack;
