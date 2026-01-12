import { create } from "zustand";
import type { IUser } from "../models/user.model";
import { persist } from "zustand/middleware";

interface UsersState {
    users: IUser[];
    setUsers: (users: IUser[]) => void;
}
export const useUsersStore = create<UsersState>()(
     persist(
        (set) => ({
            users: [],
            setUsers: (users) => set({ users }) 
        }),
        {
            name: "users-storage",
            partialize: (state) => ({ users: state.users })
        }
    )
);