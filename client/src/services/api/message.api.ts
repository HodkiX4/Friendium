import { API } from "../../lib/axiosInstance";
import type { IMessage } from "../../models/message.model";

export const messageService = {
    getById: async (messageId: string): Promise<IMessage> => {
        const res = await API
            .get<IMessage>(`/messages/${messageId}`);
        return res.data;
    },
    send: async (chatId: string, content: string): Promise<IMessage> => {
        const res = await API
            .post<IMessage>("/messages/send", { chatId, content });
        return res.data;
    },
    update: async (messageId: string, content: string): Promise<IMessage> => {
        const res = await API
            .put<IMessage>(`/messages/${messageId}`, { content });
        return res.data;
    },
    delete: async (messageId: string): Promise<void> => {
        await API
            .delete(`/messages/${messageId}`);
    }
}