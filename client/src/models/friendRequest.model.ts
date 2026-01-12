export interface IFriendRequest {
    id: string;
    senderId: string;
    recieverId: string;
    sentAt: Date;
    isAccepted: boolean;
}