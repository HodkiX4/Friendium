export interface IMessage {
    id: string;
    chatId: string;
    userId: string;
    text: string;
    UpdatedAt: string;
}

export interface IAddMessagePayload {
    chatId: string;
    text: string;
}

export interface IUpdateMessagePayload {
    text: string;
}