import { API } from "../../lib/axiosInstance";
import type { IFriendRequest } from "../../models/friendRequest.model";

export const friendRequestService = {
    getPendingRequests: async (): Promise<IFriendRequest[]> => {
        const res = await API
            .get<IFriendRequest[]>("/friends/request/pending");
        return res.data;
    },
    sendFriendRequest: async (recieverId: string): Promise<{ message: string }> => {
        const res = await API
            .get<{ message: string }>(`/friends/request/${recieverId}`);
        return res.data;
    },
    acceptFriendRequst: async (requestId: string): Promise<{ message: string }> => {
        const res = await API
            .get<{ message: string }>(`/friends/request/${requestId}`);
        return res.data;
    }
}