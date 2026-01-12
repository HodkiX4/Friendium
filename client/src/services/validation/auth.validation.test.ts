import { describe, it, expect } from 'vitest';
import { authValidationService } from "./auth.validation";

describe('authValidationService', () => {
    it('should return erros for invalid signup payload', () => {
        const payload = {
            firstname: '',
            lastname: '',
            email: 'invalid-email',
            gender: 'Alien',
            dateOfBirth: 'not-a-date',
            password: 'abc',
            confirmPassword: 'abc'
        };

        const errors = authValidationService.validateSignup(payload as any);

        expect(errors).toBeTruthy();
        expect(errors?.Name).toBeDefined();
        expect(errors?.Email).toBeDefined();
        expect(errors?.DateOfBirth).toBeDefined();
        expect(errors?.Gender).toBeDefined();
        expect(errors?.Password).toBeDefined();
    });

    it('should return null for valid signup payload', () => {
        const payload = {
            firstname: 'Aaron',
            lastname: 'Judge',
            email: 'AaronX4@OGmail.com',
            gender: 'Male',
            dateOfBirth: '2004-01-21',
            password: 'Miske$A4',
            confirmPassword: 'Miske$A4'
        };

        const errors = authValidationService.validateSignup(payload as any);

        expect(errors).toBeNull();
    });
    
    it('should return errors for invalid login payload', () => {
        const payload = {
            email: "invalid-email",
            password: "abc"
        }

        const errors = authValidationService.validateLogin(payload as any);

        expect(errors).toBeTruthy();
        expect(errors?.Email).toBeDefined();
        expect(errors?.Password).toBeDefined();
    });

    it('should return null for valid login payload', () => {
        const payload = {
            email: "AaronX4@OGmail.com",
            password: "Miske$A4"
        }

        const errors = authValidationService.validateLogin(payload as any);

        expect(errors).toBeNull();
    });

});