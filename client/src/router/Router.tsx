import { lazy, Suspense } from 'react'
import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom'

const WelcomePage = lazy(() => import('../pages/Welcome/WelcomePage'))
const LoginPage = lazy(() => import('../pages/Auth/LoginPage'))
const SignUpPage = lazy(() => import('../pages/Auth/SignUpPage'))
const OnboardingPage = lazy(() => import('../pages/Onboarding/OnboardingPage'))
const HomePage = lazy(() => import('../pages/Home/HomePage'))
const ChatsPage = lazy(() => import('../pages/Chat/ChatsPage'))
const ChatDetailPage = lazy(() => import('../pages/Chat/ChatDetailPage'))
const ProfilePage = lazy(() => import('../pages/Profile/ProfilePage'))
const SearchPage = lazy(() => import('../pages/Search/SearchPage'))
const SettingsPage = lazy(() => import('../pages/Settings/SettingsPage'))
const AuthLayout = lazy(() => import('../layouts/AuthLayout'))
const ProtectedLayout = lazy(() => import('../layouts/ProtectedLayout'))

function Router() {
  return (
    <BrowserRouter>
      <Suspense fallback={<div>Loading...</div>}>
        <Routes>
          {/*Auth Routes*/}
          <Route path='auth' element={<AuthLayout/>}>
            <Route index element={<WelcomePage/>}/>
            <Route path='login' element={<LoginPage/>} />
            <Route path='signup' element={<SignUpPage/>} />
          </Route>
          {/*Protected Routes*/}
          <Route path='protected' element={<ProtectedLayout/>}>
            <Route path='onboarding' element={<OnboardingPage/>} />
            <Route path='home' element={<HomePage/>} />
            <Route path='chat' element={<ChatsPage/>} />
            <Route path='chat/:chatId' element={<ChatDetailPage/>} />
            {/* Profile can be viewed for the session user or another user by id */}
            <Route path='profile' element={<ProfilePage/>} />
            <Route path='profile/:userId' element={<ProfilePage/>} />
            <Route path='search' element={<SearchPage/>} />
            <Route path='settings' element={<SettingsPage/>} />
          </Route>
          {/*Redirect unknown routes to home*/}
          <Route path='*' element={<Navigate  to='/protected/home' replace />} />
        </Routes>
      </Suspense>
    </BrowserRouter>
  )
}

export default Router