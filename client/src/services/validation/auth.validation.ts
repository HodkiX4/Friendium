import type { ILoginPayload, ISignupPayload } from "../../models/auth.model";
import { validateDate, validateEmail, validateGender, validateName, validatePassword } from "../../utils/validation/validations";

export const authValidationService = {
    validateLogin: (payload: ILoginPayload) => {
        const {
            email,
            password
        } = payload;

        const errors: Record<string, string> = {};
        
        const emailError = validateEmail(email);
        if(emailError) {
            errors.Email = emailError;
        }

        const passwordError = validatePassword(password);
        if(passwordError) {
            errors.Password = passwordError;
        }

        return Object.keys(errors).length ? errors : null;
    },
    validateSignup: (payload: ISignupPayload) => {
        const {
            firstname,
            lastname,
            email,
            gender,
            dateOfBirth,
            password,
            confirmPassword
        } = payload;
        
        const errors: Record<string, string> = {};

        const nameError = validateName(`${firstname} ${lastname}`);
        if(nameError) {
            errors.Name = nameError;
        }

        const emailError = validateEmail(email);
        if(emailError) {
            errors.Email = emailError;
        }

        const genderError = validateGender(gender);
        if(genderError) {
            errors.Gender = genderError;
        }

        const dateError = validateDate(dateOfBirth);
        if(dateError) {
            errors.DateOfBirth = dateError;
        }

        const passwordError = validatePassword(password);
        if(passwordError) {
            errors.Password = passwordError;
        }

        if(password != confirmPassword) {
            errors.confirmPassword = "Passwords don't match";
        }

        return Object.keys(errors).length ? errors : null;
    }

}