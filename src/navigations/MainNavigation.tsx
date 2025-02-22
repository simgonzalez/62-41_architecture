import React, { useEffect } from "react";
import {
  NavigationContainer,
  NavigationIndependentTree,
} from "@react-navigation/native";
import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
import HomeScreen from "@screens/HomeScreen";
import FridgeStack from "@navigations/FridgeStack";
import UserScreen from "@screens/UserScreen";
import Icon from "react-native-vector-icons/Ionicons";
import { Keyboard } from "react-native";

const Tab = createBottomTabNavigator();

const tabIcon = ({ route }: { route: { name: string } }) => ({
  tabBarIcon: ({ color, size }: { color: string; size: number }) => {
    let iconName = "";

    if (route.name === "Home") {
      iconName = "home-outline";
    } else if (route.name === "FridgesScreen") {
      iconName = "snow-outline";
    } else if (route.name === "User") {
      iconName = "person-outline";
    }

    return <Icon name={iconName} color={color} size={size} />;
  },
});

const Navigation = () => {
  const [isKeyboardVisible, setKeyboardVisible] = React.useState(false);

  useEffect(() => {
    const keyboardDidShowListener = Keyboard.addListener(
      "keyboardDidShow",
      () => {
        setKeyboardVisible(true);
      }
    );
    const keyboardDidHideListener = Keyboard.addListener(
      "keyboardDidHide",
      () => {
        setKeyboardVisible(false);
      }
    );

    return () => {
      keyboardDidHideListener.remove();
      keyboardDidShowListener.remove();
    };
  }, []);

  return (
    <Tab.Navigator
      screenOptions={({ route }) => ({
        ...tabIcon({ route }),
        headerShown: route.name !== "FridgesScreen",
        headerTitleStyle: { fontWeight: "bold" },
        tabBarStyle: {
          display: isKeyboardVisible ? "none" : "flex",
          height: 75,
        },
        tabBarIconStyle: { marginTop: 10 },
        tabBarLabelStyle: { fontSize: 12 },
      })}
    >
      <Tab.Screen name="Home" component={HomeScreen} />
      <Tab.Screen
        name="FridgesScreen"
        component={FridgeStack}
        options={{ tabBarLabel: "Fridges" }}
      />
      <Tab.Screen name="User" component={UserScreen} />
    </Tab.Navigator>
  );
};

export default Navigation;
