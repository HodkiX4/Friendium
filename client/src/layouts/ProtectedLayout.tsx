import { Navigate, Outlet, useLocation } from "react-router-dom";
import { useAuthStore } from "../store/authStore";
import HeaderComponent from "../components/Header/HeaderComponent";
import FooterComponent from "../components/Footer/FooterComponent";
import Styles from './Layout.module.scss';

function ProtectedLayout() {
    const location = useLocation();
    const isOnboarding = location.pathname == "/protected/onboarding";
    
    const { user } = useAuthStore();
    return user
        ?
        <div className={Styles.protectedLayout}>
            {
                !isOnboarding &&
                <HeaderComponent />
            }
            <main className={Styles.mainContent}>
                <Outlet />
            </main>
            <FooterComponent />     
        </div>
        : <Navigate to="/auth/login" replace />;
}

export default ProtectedLayout