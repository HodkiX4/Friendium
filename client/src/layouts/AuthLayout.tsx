import { Link, Navigate, Outlet } from "react-router-dom";
import Styles from './Layout.module.scss';
import { MdOutlineArrowBack } from 'react-icons/md';
import { useAuthStore } from "../store/authStore";
function AuthLayout() {
    const { user } = useAuthStore();

    return user
        ? <Navigate to="/protected" replace /> // ide kell menni, nem login
        : (
            <div className={Styles.AuthLayout}>
                <Link to="/">
                    <button className={Styles.backBtn} >
                        <MdOutlineArrowBack/> 
                    </button>
                </Link>
                <Outlet/>
            </div>
        );
}

export default AuthLayout;