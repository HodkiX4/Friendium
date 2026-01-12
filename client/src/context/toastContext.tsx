import React, { createContext, useContext, useRef } from "react";
import toast from "react-hot-toast";

const ToastContext = createContext({
    showSuccess: (message: string) => {},
    showError: (message: string) => {}
});

export const ToastProvider = ({ children }: { children: React.ReactNode }) => {
    const toastId = useRef<string | undefined>(undefined);

    const showSuccess = (message: string) => {
        if(toastId.current) toast.remove(toastId.current);
        toastId.current = toast.success(message);
    }

    const showError = (message: string) => {
        if(toastId.current) toast.remove(toastId.current);
        toastId.current = toast.error(message);
    }

    return (
        <ToastContext.Provider value={{ showSuccess, showError }}>
            {children}
        </ToastContext.Provider>
    )
}

export const useToast = () => useContext(ToastContext);