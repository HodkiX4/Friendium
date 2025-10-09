import { useState } from "react"
import { Navigate, Outlet } from "react-router-dom";

function AuthLayout() {
    const [token, setToken] = useState<string | null>(null);
    return token ? <Outlet/> : <Navigate to="/auth/login" replace/>;
}

export default AuthLayout