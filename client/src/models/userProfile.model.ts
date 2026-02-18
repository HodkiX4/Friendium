import type { Gender } from "../types/gender.type";

export interface IUserProfile {
    userId: string;
    avatarUrl?: string | null;
    bio?: string | null;
    dateOfBirth: string;
    gender: Gender;
    interests: string[];
    city?: string | null;
    country?: string | null;
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


export interface IUserSearchResult {
    id: string;
    displayName: string;
    avatarUrl: string | null;
    shortBio: string | null;
    interests: string[] | null;
    city: string | null;
    country: string | null;
    isVisible: boolean;
    gender: Gender;
}