import type { IMessage } from "./message.model";

export interface IChat {
    id: string;
    userIds: string[];
    messages: IMessage[];
    createdAt: string;
}