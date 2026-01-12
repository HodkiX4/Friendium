import { Navigate, Outlet } from "react-router-dom";
import { useAuthStore } from "../store/authStore";

function ProtectedLayout() {
    const { user } = useAuthStore();
    return user
        ? <Outlet />
        : <Navigate to="/auth/login" replace />;
}

export default ProtectedLayout