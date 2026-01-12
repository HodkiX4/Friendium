import { setupServer } from 'msw/node';
import { http, HttpResponse } from 'msw';
import type { ILoginPayload, ISignupPayload } from '../models/auth.model';

export const server = setupServer(
    http.post<ISignupPayload>('/api/auth/register', async ({ request }) => {
        const body = await request.json() as ISignupPayload;
        if(body.email === 'AaronX4@OGmail.com') {
            return HttpResponse.json({ message: 'Email alreay registered'})
        }
        return HttpResponse.json({
            id: '123',
            firstname: body.firstname,
            email: body.email
        });
    }),

    http.post<ILoginPayload>('/api/auth/login', async ({ request }) => {
        const body = await request.json() as ILoginPayload;
        if(body.password !== 'Valid123!') {
            return HttpResponse.json({ message: 'Invalid credentials'}, { status: 401 });
        }
        return HttpResponse.json({
            id: '123',
            firstname: 'Aaron',
            email: body.email
        });
    })

);