import { create } from "zustand";
import { persist } from "zustand/middleware";
import type { IUserSearchResult } from "../models/userProfile.model";

interface UsersState {
    publicUsers: IUserSearchResult[];
    setPublicUsers: (users: IUserSearchResult[]) => void;
}
export const useUsersStore = create<UsersState>()(
     persist(
        (set) => ({
            publicUsers: [],
            setPublicUsers: (publicUsers) => set({ publicUsers }) 
        }),
        {
            name: "users-storage",
            partialize: (state) => ({ publicUsers: state.publicUsers })
        }
    )
);