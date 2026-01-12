import { messageService } from "../../services/api/message.api";
import { useAsyncHandler } from "../handler/useAsyncHandler";

export const useMessages = () => {
    const { runAsync, isLoading } = useAsyncHandler();

    const getMessageById = (messageId: string) => {
        runAsync(async () => {
            const message = await messageService.getById(messageId);
            console.log(message);
        });
    }

    const sendMessage = (chatId: string, content: string) => {
        runAsync(async () => {
            const message = await messageService.send(chatId, content);
            console.log(message);
        });
    }

    const updateMessage = (messageId: string, content: string) => {
        runAsync(async () => {
            const message = await messageService.update(messageId, content);
            console.log(message);
        });
    }

    const deleteMessage = (messageId: string) => {
        runAsync(async () => {
            await messageService.delete(messageId);
            console.log(`Message ${messageId} deleted`);
        });
    }

    return {
        getMessageById,
        sendMessage,
        updateMessage,
        deleteMessage,
        isLoading
    };
}