import React, {
  createContext,
  useContext,
  useState,
  ReactNode,
  useMemo,
} from "react";
import { Snackbar } from "react-native-paper";
import { View, StyleSheet } from "react-native";

interface SnackbarContextType {
  showSnackbar: (message: string, action?: () => void) => void;
}

const SnackbarContext = createContext<SnackbarContextType>({
  showSnackbar: () => {},
});

export const SnackbarProvider = ({ children }: { children: ReactNode }) => {
  const [visible, setVisible] = useState(false);
  const [message, setMessage] = useState("");
  const [action, setAction] = useState<(() => void) | undefined>(undefined);

  const showSnackbar = (msg: string, act?: () => void) => {
    setMessage(msg);
    setAction(() => act);
    setVisible(true);
  };

  const onDismissSnackBar = () => setVisible(false);

  const contextValue = useMemo(() => ({ showSnackbar }), [showSnackbar]);

  return (
    <SnackbarContext.Provider value={contextValue}>
      {children}
      <Snackbar
        visible={visible}
        onDismiss={onDismissSnackBar}
        action={
          action
            ? {
                label: "Undo",
                onPress: action,
              }
            : undefined
        }
        style={styles.snackbar}
      >
        {message}
      </Snackbar>
    </SnackbarContext.Provider>
  );
};

const styles = StyleSheet.create({
  snackbar: {
    position: "absolute",
    bottom: "50%",
  },
});

export const useSnackbar = () => useContext(SnackbarContext);
