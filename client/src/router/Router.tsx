import { lazy, Suspense } from 'react'
import { BrowserRouter, Route, Routes } from 'react-router-dom'

const WelcomePage = lazy(() => import('../pages/Welcome/WelcomePage'))
const LoginPage = lazy(() => import('../pages/Auth/LoginPage'))
const SignUpPage = lazy(() => import('../pages/Auth/SignUpPage'))
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
          <Route path="/" element={<AuthLayout/>}>
          <Route index element={<WelcomePage/>}/>
            <Route path="login" element={<LoginPage/>} />
            <Route path="signup" element={<SignUpPage/>} />
          </Route>
          <Route path="protected" element={<ProtectedLayout/>}>
            <Route index element={<HomePage/>} />
            <Route path="chat" element={<ChatsPage/>}>
              <Route path=":chatId" element={<ChatDetailPage/>} />
            </Route>
            <Route path="profile" element={<ProfilePage/>} />
            <Route path="search" element={<SearchPage/>} />
            <Route path="settings" element={<SettingsPage/>} />
          </Route>
        </Routes>
      </Suspense>
    </BrowserRouter>
  )
}

export default Router