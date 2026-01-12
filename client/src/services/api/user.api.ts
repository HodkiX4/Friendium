import { API } from "../../lib/axiosInstance"
import type { IUser } from "../../models/user.model";

export const userService = {
    getAll: async (): Promise<IUser[]> => {
        const res = await API
            .get<IUser[]>("/users/all");
        return res.data;
    },
    getById: async (userId: string): Promise<IUser> => {
        const res = await API
            .get<IUser>(`/users/${userId}`);
        return res.data;
    }
}