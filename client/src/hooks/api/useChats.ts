import { chatService } from "../../services/api/chat.api";
import { useAsyncHandler } from "../handler/useAsyncHandler";

export const useChats = () => {
    const { runAsync, isLoading } = useAsyncHandler();

    const fetchChats = (userId: string) => {
        return runAsync(async () => {
            const chats = await chatService.getAll(userId);
            console.log(chats);
        });
    }

    const fetchChatById = (chatId: string) => {
        return runAsync(async () => {
            const chat = await chatService.getById(chatId);
            console.log(chat);
        });
    }
    
    return {
        fetchChats,
        fetchChatById,
        isLoading
    };
}