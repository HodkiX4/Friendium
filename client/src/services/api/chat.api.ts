import { API } from "../../lib/axiosInstance";
import type { IChat } from "../../models/chat.model";

export const chatService = {
   getAll: async (userId: string): Promise<IChat[]> => {
        const res = await API
            .get<IChat[]>(`/chats/all/${userId}`);
        return res.data;
   },
   getById: async (chatId: string): Promise<IChat> => {
        const res = await API
            .get<IChat>(`/chats/${chatId}`);
        return res.data;
   },
}