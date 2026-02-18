import { useState } from "react";
import { profileService } from "../../services/api/userProfile.api";
import type { IUserProfile } from "../../models/userProfile.model";

export const useUserProfile = () => {
    const [profile, setProfile] = useState<IUserProfile | null>(null);
    const [isLoading, setIsLoading] = useState<boolean>(false);
    
    const handleGetUserProfileById = async (id: string): Promise<void> => {
        try {
            setIsLoading(true);
            const profile = await profileService.getById(id);

            if (!profile) throw new Error("User profile not found");
            setProfile(profile);
        } catch (error) {
            console.error("Error fetching user profile:", error);
            throw error;
        } finally {
            setIsLoading(false);
        }
    }

    const updateUserProfile = async (userId: string, payload: any): Promise<IUserProfile> => {
        try {
            setIsLoading(true);
            const updatedProfile = await profileService.update(userId, payload);
            setProfile(updatedProfile);
            return updatedProfile;
        } catch (error) {
            console.error("Error updating user profile:", error);
            throw error;
        } finally {
            setIsLoading(false);
        }
    }

    return {
        profile,
        isLoading,
        handleGetUserProfileById,
        updateUserProfile
    }
};