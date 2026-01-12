import { userService } from "../../services/api/user.api";
import { useUsersStore } from "../../store/userStore";
import { useAsyncHandler } from "../handler/useAsyncHandler";

export const useUsers = () => {
    const { runAsync } = useAsyncHandler();
    const { setUsers } = useUsersStore();
    const handleGetUsers = async () => {
        await runAsync(async () => {
            const users = await userService.getAll();
            setUsers(users);
        });
    }
    const handleGetUserById = async (userId: string) => {
        await runAsync(async () => {
            const user = userService.getById(userId);
            console.log(user);
            
        })
    }

    return {
        handleGetUsers,
        handleGetUserById
    }
}