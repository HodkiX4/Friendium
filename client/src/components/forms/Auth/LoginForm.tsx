import Styles from "./Auth.module.scss";
import type { FormEvent } from "react";
import type { ILoginPayload } from "../../../models/auth.model";
import { useAuth } from "../../../hooks/api/useAuth";
import { Link, useNavigate } from "react-router-dom";
import { MdOutlineArrowBack } from "react-icons/md";
function LoginForm() {
  const { login, isLoading, errors } = useAuth();
  const navigate = useNavigate();
  const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const formData = new FormData(e.currentTarget);
    const values = Object.fromEntries(formData) as unknown as ILoginPayload;
    const user = await login(values);
    if (user) {
      navigate("/home");
    }
  };
  return (
    <>
      <Link to="/auth">
        <button className={Styles.backBtn}>
          <MdOutlineArrowBack />
        </button>
      </Link>

      <div className={Styles.authForm}>
        <h3>Welcome Back</h3>
        <span>Login to your account to continue</span>
        <form onSubmit={handleSubmit}>
          <div style={{ width: "100%" }}>
            <input name="email" type="text" placeholder="johm@example.com" />
            {errors?.Email && (
              <div className={Styles.fieldError}>{errors.Email}</div>
            )}
          </div>
          <div style={{ width: "100%" }}>
            <input
              name="password"
              type="password"
              placeholder="Password"
              autoComplete="off"
            />
            {errors?.Password && (
              <div className={Styles.fieldError}>{errors.Password}</div>
            )}
          </div>
          <button type="submit" disabled={isLoading}>
            {isLoading ? "..." : "Login"}
          </button>
        </form>
        <Link to="/auth/signup">
          <button className={Styles.navBtn}>Create an Account</button>
        </Link>
      </div>
    </>
  );
}

export default LoginForm;
