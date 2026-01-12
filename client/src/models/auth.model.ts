import type { Gender } from "../types/gender.type";

interface ILoginPayload {
    email: string;
    password: string;
}

interface ISignupPayload {
    firstname: string;
    lastname: string;
    email: string;
    gender: Gender;
    dateOfBirth: string;
    password: string;
    confirmPassword: string;
}

export type { ILoginPayload, ISignupPayload }