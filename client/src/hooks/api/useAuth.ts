import type { ILoginPayload, ISignupPayload } from "../../models/auth.model";
import { authApiSerivce } from "../../services/api/auth.api";
import { authValidationService } from "../../services/validation/auth.validation";
import { useToast } from "../../context/toastContext";
import { useAuthStore } from "../../store/authStore";
import { useState, useCallback } from "react";
import type { IUser } from "../../models/user.model";

export const useAuth = () => {
    const { showSuccess, showError } = useToast();
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [errors, setErrors] = useState<Record<string, string> | null>(null);
    const { setUser } = useAuthStore();

    const login = useCallback(async (payload: ILoginPayload): Promise<IUser | null> => {
        if (isLoading) return null;

        const validationErrors = authValidationService.validateLogin(payload);
        if (validationErrors) {
            setErrors(validationErrors);
            return null;
        }

        setIsLoading(true);
        try {
            const data = await authApiSerivce.login(payload);
            if (data) {
                setUser(data);
                showSuccess("Logged in successfully");
            }
            console.log(data);
            
            return data ?? null;
        } catch (error) {
            showError("Login failed");
            return null;
        } finally {
            setIsLoading(false);
        }
    }, [isLoading, showError, showSuccess, setUser]);

    const signup = useCallback(async (payload: ISignupPayload): Promise<IUser | null> => {
        if (isLoading) return null;

        const validationErrors = authValidationService.validateSignup(payload);
        if (validationErrors) {
            setErrors(validationErrors);
            return null;
        }

        setErrors(null);
        setIsLoading(true);
        try {
            const data = await authApiSerivce.register(payload);
            if (data) {
                setUser(data);
                showSuccess("Signed up successfully");
            }
            return data ?? null;
        } catch (error) {
            console.log(error);
            
            showError("Signup failed");
            return null;
        } finally {
            setIsLoading(false);
        }
    }, [isLoading, showError, showSuccess, setUser]);

    const logout = useCallback(async (): Promise<void> => {
        if (isLoading) return;

        setIsLoading(true);
        try {
            await authApiSerivce.logout();
            setUser(null);
            showSuccess("Logged out successfully");
        } catch (error) {
            showError("Logout failed");
        } finally {
            setIsLoading(false);
        }
    }, [isLoading, showError, showSuccess, setUser]);

    const getMe = useCallback(async (): Promise<IUser | null> => {
        if (isLoading) return null;

        setIsLoading(true);
        try {
            const user = await authApiSerivce.getMe();
            if (user) {
                setUser(user);
            }
            return user ?? null;
        } catch (error) {
            console.error(error);
            return null;
        } finally {
            setIsLoading(false);
        }
    }, [isLoading, showError, setUser]);

    return {
        login,
        signup,
        logout,
        getMe,
        isLoading,
        errors
    };
}