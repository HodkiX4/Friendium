import Styles from './Auth.module.scss'
import type { FormEvent } from 'react'
import { useAuth } from '../../../hooks/api/useAuth';
import { Link, useNavigate } from 'react-router-dom';
import type { ISignupPayload } from '../../../models/auth.model';

function SignupForm() {
    const { signup, isLoading, errors } = useAuth();
    const navigate = useNavigate();
    const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const formData = new FormData(e.currentTarget);
        const values = Object.fromEntries(formData) as unknown as ISignupPayload;
        
        const user = await signup(values);
        if(user) {
            navigate("/");
        }
    }
    return (
        <div className={Styles.AuthForm}>
            <h1>Friendium</h1>
            <form onSubmit={handleSubmit}>
                <div className={Styles.JoinedInputs}>
                    <div style={{ width: '100%' }}>
                        <input name="firstname" type="text" placeholder="Firstname" autoComplete='off' />
                        {errors?.Name && <div className={Styles.FieldError}>{errors.Name}</div>}
                    </div>
                    <div style={{ width: '100%' }}>
                        <input name="lastname" type="text" placeholder="Lastname" autoComplete='off' />
                    </div>
                    <span></span>
                </div>
                <div style={{ width: '100%' }}>
                    <input name="email" type="text" placeholder="Email" autoComplete='off' />
                    {errors?.Email && <div className={Styles.FieldError}>{errors.Email}</div>}
                </div>
                <div className={Styles.JoinedInputs}>
                    <input type="date" name="dateOfBirth" autoComplete='off' />
                    <select name="gender" defaultValue="Female">
                        <option value="Female">Female</option>
                        <option value="Male">Male</option>
                        <option value="Other">Other</option>
                        <option value="PreferNotToSay">Prefer not to say</option>
                    </select>
                </div>
                {errors?.DateOfBirth && <div className={Styles.FieldError}>{errors.DateOfBirth}</div>}
                {errors?.Gender && <div className={Styles.FieldError}>{errors.Gender}</div>}
                <input name="password" type="password" placeholder="Password" autoComplete='off' />
                {errors?.Password && <div className={Styles.FieldError}>{errors.Password}</div>}
                <input name="confirmPassword" type="password" placeholder="Confirm Password" autoComplete='off' />
                {errors?.confirmPassword && <div className={Styles.FieldError}>{errors.confirmPassword}</div>}
                <button type="submit" disabled={isLoading}>{isLoading ? "..." : "Submit"}</button>
            </form>
            <Link to="/auth/login">
            <button className={Styles.navBtn}>Log in to your account.</button>
            </Link>
        </div>
    )
}

export default SignupForm