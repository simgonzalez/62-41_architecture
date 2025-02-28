// src/navigations/MainNavigation.tsx
import React from "react";
import { Appbar, BottomNavigation } from "react-native-paper";
import HomeScreen from "@screens/HomeScreen";
import FridgeStack from "@navigations/FridgeStack";
import UserScreen from "@screens/UserScreen";
import RequestsScreen from "@screens/FoodRequestsScreen";
import Icon from "react-native-vector-icons/MaterialCommunityIcons";

const Navigation = () => {
  const [index, setIndex] = React.useState(0);
  const [routes] = React.useState([
    { key: "home", title: "Home", icon: "home-outline" },
    { key: "fridges", title: "Fridges", icon: "snowflake" },
    {
      key: "requests",
      title: "Requests",
      topBarTitle: "Food donations requests",
      icon: "gift-outline",
    },
    { key: "user", title: "User", icon: "account-outline" },
  ]);

  const renderScene = BottomNavigation.SceneMap({
    home: HomeScreen,
    fridges: FridgeStack,
    requests: RequestsScreen,
    user: UserScreen,
  });

  const renderIcon = ({
    route,
    focused,
    color,
  }: {
    route: any;
    focused: boolean;
    color: string;
  }) => {
    return <Icon name={route.icon} size={24} color={color} />;
  };

  return (
    <>
      {routes[index].key !== "fridges" && (
        <Appbar.Header elevated={true}>
          <Appbar.Content
            title={routes[index].topBarTitle ?? routes[index].title}
          />
        </Appbar.Header>
      )}
      <BottomNavigation
        navigationState={{ index, routes }}
        onIndexChange={setIndex}
        renderScene={renderScene}
        renderIcon={renderIcon}
        keyboardHidesNavigationBar={true}
        barStyle={{ height: 75 }}
      />
    </>
  );
};

export default Navigation;
