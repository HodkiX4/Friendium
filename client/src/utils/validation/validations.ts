import type { Gender } from "../../types/gender.type";

export const validateName = (name: string) => {
    const trimmedName = name?.trim();
    if(!trimmedName) {
        return "Name is required";
    } else if(!/^[A-Za-zÀ-ÖØ-öø-ÿ' -]{2,50}$/.test(trimmedName)) {
        return "Please enter a valid name";
    }
    return null;
}
export const validateEmail = (email: string) => {
    const trimmedEmail = email?.trim();
    if(!trimmedEmail) {
        return "Email is required";
    } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(trimmedEmail)) {
        return "Please enter a valid email";
    }
    return null;
}

export const validateGender = (gender: Gender) => {
    const allowedGenders = ["Male", "Female", "Other", "PreferNotToSay"] as const;
    
    if(!allowedGenders.includes(gender)){
        return "Invalid value given as gender";
    }
    return null;
}

export const validateDate = (dateOfBirth: string) => {
    const givenDate = new Date(dateOfBirth);
    if (isNaN(givenDate.getTime())) {
        return "Invalid date";
    }

    const currentDate = new Date();
    let age = currentDate.getFullYear() - givenDate.getFullYear();
    const month = currentDate.getMonth() - givenDate.getMonth();
    if (month < 0 || (month === 0 && currentDate.getDate() < givenDate.getDate())) {
        age--;
    }

    if (age < 0) {
        return "Invalid date";
    }

    return age < 18
        ? "You must be 18+ to use this app"
        : null;
}

export const validatePassword = (password: string) => {
    const trimmedPassword = password?.trim();
    if (!trimmedPassword) {
        return "Password is required";
    } else if (password.length < 8) {
        return "Password must be at least 8 characters long";
    } else if (!/^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).+$/.test(password)) {
        return "Password must contain at least one uppercase letter, one number, and one special character";
    }
    return null;
};

