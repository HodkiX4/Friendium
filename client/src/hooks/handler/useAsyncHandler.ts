import { useState } from "react"
import { useToast } from "../../context/toastContext";
import { isAxiosError } from "axios";

export const useAsyncHandler = () => {
    const [isLoading, setIsLoading] = useState(false);
    const { showError } = useToast();

    const runAsync = async <T>(fn: () => Promise<T>): Promise<T | null> => {
        if(isLoading) return null;
        setIsLoading(true);

        try {
            return await fn();
        } catch (e) {;
            
            if(isAxiosError(e)) {
                showError(e.response?.data || "Axios error");
            } else if(e instanceof Error) {
                showError(e.message);
            } else {
                showError("Unexpected error");
            }
            return null;
        } finally {
            setIsLoading(false);
        }
    }

    return { runAsync, isLoading }
}