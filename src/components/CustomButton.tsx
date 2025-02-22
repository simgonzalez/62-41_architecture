import React from "react";
import { StyleSheet } from "react-native";
import { Button } from "react-native-paper";

interface CustomButtonProps {
  onPress: () => void;
  text: string;
}

const CustomButton: React.FC<CustomButtonProps> = ({ onPress, text }) => {
  return (
    <Button
      mode="contained"
      onPress={onPress}
      style={styles.button}
      contentStyle={styles.buttonContent}
    >
      {text}
    </Button>
  );
};

const styles = StyleSheet.create({
  button: {
    borderRadius: 8,
    width: "100%",
  },
  buttonContent: {
    paddingVertical: 15,
  },
});

export default CustomButton;
