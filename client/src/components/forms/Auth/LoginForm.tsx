import Styles from './Auth.module.scss';
import type { FormEvent } from "react";
import type { ILoginPayload } from "../../../models/auth.model";
import { useAuth } from "../../../hooks/api/useAuth";
import { Link, useNavigate } from "react-router-dom";
function LoginForm() {
    const { login, isLoading, errors } = useAuth();
    const navigate = useNavigate();
    const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const formData = new FormData(e.currentTarget);
        const values = Object.fromEntries(formData) as unknown as ILoginPayload;
        const user = await login(values);
        if(user) {
            navigate("/");
        }
    }
    return (
        <div className={Styles.AuthForm}>
            <h1>Friendium</h1>
            <form onSubmit={handleSubmit}>
                <input name="email" type="text" placeholder="Email" />
                {errors?.Email && <div className={Styles.FieldError}>{errors.Email}</div>}
                <input name="password" type="password" placeholder="Password" autoComplete='off'/>
                {errors?.Password && <div className={Styles.FieldError}>{errors.Password}</div>}
                <button type="submit" disabled={isLoading}>{isLoading ? "..." : "Log In"}</button>
            </form>
            <Link to="/auth/signup">
                <button className={Styles.navBtn}>Create an Account</button>
            </Link>
        </div>
    )
}

export default LoginForm