import type { Gender } from "../types/gender.type";

export interface IUserProfile {
    userId: string;
    avatarUrl: string;
    bio: string;
    dateOfBirth: string;
    gender: Gender;
    interests: string[];
    city: string;
    country: string;
    latitude: number;
    longitude: number;
    isVisible: boolean;
}

export interface IUpdateUserProfilePayload {
    avatarUrl?: string;
    bio?: string;
    dateOfBirth?: string;
    gender?: Gender;
    interests?: string[];
    city?: string;
    country?: string;
    isVisible?: boolean;
}