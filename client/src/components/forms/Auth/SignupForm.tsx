import Styles from './Auth.module.scss'
import type { FormEvent } from 'react'
import { useAuth } from '../../../hooks/api/useAuth';
import { Link, useNavigate } from 'react-router-dom';
import type { ISignupPayload } from '../../../models/auth.model';
import { MdOutlineArrowBack } from 'react-icons/md';

function SignupForm() {
    const { signup, isLoading, errors } = useAuth();
    const navigate = useNavigate();
    const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const formData = new FormData(e.currentTarget);
        const values = Object.fromEntries(formData) as unknown as ISignupPayload;

        const user = await signup(values);
        if (user) {
            navigate("/protected/onboarding");
        }
    }
    return (
        <>
            <Link to="/auth">
                <button className={Styles.backBtn} >
                    <MdOutlineArrowBack />
                </button>
            </Link>

            <div className={Styles.authForm}>
                <h1>Create Account</h1>
                <span>Join our community and start making friends</span>
                <form onSubmit={handleSubmit}>
                    <div className={Styles.joinedInputs}>
                        <div style={{ width: '100%' }}>
                            <input name="firstname" type="text" placeholder="Firstname" autoComplete='off' />
                            {errors?.Name && <div className={Styles.fieldError}>{errors.Name}</div>}
                        </div>
                        <div style={{ width: '100%' }}>
                            <input name="lastname" type="text" placeholder="Lastname" autoComplete='off' />
                        </div>
                    </div>
                    <div style={{ width: '100%' }}>
                        <input name="email" type="text" placeholder="Email" autoComplete='off' />
                        {errors?.Email && <div className={Styles.fieldError}>{errors.Email}</div>}
                    </div>
                    <div className={Styles.joinedInputs}>
                        <div style={{ width: '100%' }}>
                            <input type="date" name="dateOfBirth" autoComplete='off' />
                            {errors?.DateOfBirth && <div className={Styles.fieldError}>{errors.DateOfBirth}</div>}
                        </div>
                        <div style={{ width: '100%' }}>
                            <select name="gender" defaultValue="Female">
                                <option value="Female">Female</option>
                                <option value="Male">Male</option>
                                <option value="Other">Other</option>
                                <option value="PreferNotToSay">Prefer not to say</option>
                            </select>
                            {errors?.Gender && <div className={Styles.fieldError}>{errors.Gender}</div>}
                        </div>
                    </div>
                    <div style={{ width: '100%' }}>
                        <input name="password" type="password" placeholder="Password" autoComplete='off' />
                        {errors?.Password && <div className={Styles.fieldError}>{errors.Password}</div>}
                    </div>
                    <div style={{ width: '100%' }}>
                        <input name="confirmPassword" type="password" placeholder="Confirm Password" autoComplete='off' />
                        {errors?.confirmPassword && <div className={Styles.fieldError}>{errors.confirmPassword}</div>}
                    </div>
                    <button type="submit" disabled={isLoading}>{isLoading ? "..." : "Create Account"}</button>
                </form>
                <Link to="/auth/login">
                    <button className={Styles.navBtn}>Log in to your account.</button>
                </Link>
            </div>
        </>
    )
}

export default SignupForm