import { API } from "../../lib/axiosInstance";
import type { IUserProfile, IUpdateUserProfilePayload } from "../../models/userProfile.model";

export const profileService = {
    getAll: async (): Promise<IUserProfile[]> => {
        const res = await API
            .get<IUserProfile[]>(`/users/profile/all`);
        return res.data;
    },
    getById: async (userId: string): Promise<IUserProfile> => {
        const res = await API
            .get<IUserProfile>(`/users/profile/${userId}`);
        return res.data;
    },
    update: async (userId: string, payload: IUpdateUserProfilePayload): Promise<IUserProfile> => {
        const res = await API
            .put<IUserProfile>(`/users/profile/${userId}`, payload);
        return res.data;
    }
}