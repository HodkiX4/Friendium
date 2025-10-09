import { useState } from "react";
import { Navigate, Outlet } from "react-router-dom";

function ProtectedLayout() {
    const [token, setToken] = useState<string | null>(null);
    return token == null ? <Outlet/>  : <Navigate to="/protected" replace/>;
}

export default ProtectedLayout