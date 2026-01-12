import { profileService } from "../../services/api/userProfile.api";
import { useAsyncHandler } from "../handler/useAsyncHandler";

export const useUserProfile = () => {
    const { runAsync } = useAsyncHandler();
    const handleGetUserProfiles = async () => {
        await runAsync(async () => {
            const profiles = await profileService.getAll();
            console.log(profiles);
        });
    }

    const handleUpdateUserProfile = async (userId: string, payload: any) => {
        await runAsync(async () => {
            const updatedProfile = await profileService.update(userId, payload);
            console.log(updatedProfile);
        });
    }

    return {
        handleGetUserProfiles,
        handleUpdateUserProfile
    }
};