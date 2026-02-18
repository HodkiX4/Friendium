import { Navigate, Outlet } from "react-router-dom";
import Styles from './Layout.module.scss';
import { useAuthStore } from "../store/authStore";
function AuthLayout() {
    const { user } = useAuthStore();
    
    return user
        ? <Navigate to="/protected/home" replace />
        : (
            <div className={Styles.authLayout}>
                <Outlet/>
            </div>
        );
}

export default AuthLayout;