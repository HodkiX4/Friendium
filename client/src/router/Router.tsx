import { BrowserRouter, Route, Routes } from 'react-router-dom'
import AuthLayout from '../layouts/AuthLayout'
import ProtectedLayout from '../layouts/ProtectedLayout'
import LoginPage from '../pages/Auth/LoginPage'
import SignUpPage from '../pages/Auth/SignUpPage'
import ChatDetailPage from '../pages/Chat/ChatDetailPage'
import ChatsPage from '../pages/Chat/ChatsPage'
import HomePage from '../pages/Home/HomePage'
import ProfilePage from '../pages/Profile/ProfilePage'
import SearchPage from '../pages/Search/SearchPage'
import SettingsPage from '../pages/Settings/SettingsPage'

function Router() {
  return (
    <BrowserRouter>
        <Routes>
          <Route path="/auth" element={<AuthLayout/>}>
            <Route path="/login" element={<LoginPage/>} />
            <Route path="/signup" element={<SignUpPage/>} />
          </Route>
          <Route path="/protected" element={<ProtectedLayout/>}>
            <Route index element={<HomePage/>} />
            <Route path="/chat" element={<ChatsPage/>}>
              <Route path=":chatId" element={<ChatDetailPage/>} />
            </Route>
            <Route path="/profile" element={<ProfilePage/>} />
            <Route path="/search" element={<SearchPage/>} />
            <Route path="/settings" element={<SettingsPage/>} />
          </Route>
        </Routes>
    </BrowserRouter>
  )
}

export default Router