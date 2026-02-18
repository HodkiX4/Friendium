import { API } from "../../lib/axiosInstance"
import type { IUser } from "../../models/user.model";
import type { IUserSearchResult } from "../../models/userProfile.model";

export interface IUpdateUserPayload {
    firstname?: string;
    lastname?: string;
    email?: string;
    newPassword?: string;
    confirmNewPassword?: string;
}

export const userService = {
    getAll: async (): Promise<IUser[]> => {
        const res = await API
            .get<IUser[]>("/users/all");
        return res.data;
    },
    getPublicUsers: async (): Promise<IUserSearchResult[]> => {
        const res = await API
            .get<IUserSearchResult[]>("/users/search");
        return res.data;
    },
    getById: async (userId: string): Promise<IUser> => {
        const res = await API
            .get<IUser>(`/users/${userId}`);
        return res.data;
    },
    update: async (userId: string, payload: IUpdateUserPayload): Promise<IUser> => {
        const res = await API
            .put<IUser>(`/users/${userId}`, payload);
        return res.data;
    }
}