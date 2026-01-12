import type { ILoginPayload, ISignupPayload } from "../../models/auth.model";
import { API } from "../../lib/axiosInstance";
import type { IUser } from "../../models/user.model";

export const authApiSerivce = {
    login: async (payload: ILoginPayload): Promise<IUser> => {
        const res = await API
            .post<IUser>("/auth/login", payload);
        return res.data;
    },
    register: async (payload: ISignupPayload): Promise<IUser> => {
        const res = await API
            .post<IUser>("/auth/register", payload);
        return res.data;
    },
    logout: async () => {
        const res = await API
            .post("/auth/logout");
        return res.data;
    },
    getMe: async (): Promise<IUser> => {
        const res = await API
            .get<IUser>("/auth/me");
        return res.data;
    }
}