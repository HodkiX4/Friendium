import { create } from "zustand";
import { persist } from "zustand/middleware";
import type { IChat } from "../models/chat.model";

interface ChatState {
    chats: IChat[];
    setChats: (chats: IChat[]) => void;
}

export const useChatStore = create<ChatState>()(
    persist(
        (set) => ({
            chats: [],
            setChats: (chats) => set({ chats })
        }),
        {
            name: "chat-storage",
            partialize: (state) => ({ chats: state.chats } )
        }
    )
);