import { create } from "zustand";
import type { IUser } from "../models/user.model";
import { persist } from "zustand/middleware";

interface AuthState {
    user: IUser | null;
    setUser: (user: IUser | null) => void;   
}

export const useAuthStore = create<AuthState>()(
    persist(
        (set) => ({
            user: null,
            setUser: (user) => set({ user }) 
        }),
        {
            name: "auth-storage",
            partialize: (state) => ({ user: state.user })
        }
    )
);