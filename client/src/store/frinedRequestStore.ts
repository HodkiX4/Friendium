import { create } from "zustand";
import { persist } from "zustand/middleware";
import type { IFriendRequest } from "../models/friendRequest.model";

interface friendRequestState {
    friendRequests: IFriendRequest[];
    setFriendRequests: (friendRequests: IFriendRequest[]) => void;
}

export const useFriendRequestStore = create<friendRequestState>()(
    persist(
        (set) => ({
            friendRequests: [],
            setFriendRequests: (friendRequests) => set({ friendRequests })
        }),
        {
            name: "friend-requests-storage",
            partialize: (state) => ({ friendRequests: state.friendRequests })
        }
    )
)