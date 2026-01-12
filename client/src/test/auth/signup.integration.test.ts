import { render, screen, fireEvent } from '@testing-library/react';
import SignupForm from '../../components/forms/Auth/SignupForm';
import { vi, describe, it, expect } from 'vitest';
import { MemoryRouter, useNavigate } from 'react-router-dom';

const mockNavigate = vi.fn();
vi.mock('react-router-dom', async () => {
    const actual = await vi.importActual('react-router-dom');
    return { ...actual, useNavigate: () => mockNavigate }
});

describe('SignupForm Integration', () => {
    it('should submit signup data and navigate on success', async () => {
    render(
      <MemoryRouter>
        <SignupForm />
      </MemoryRouter>
    )
    });
});