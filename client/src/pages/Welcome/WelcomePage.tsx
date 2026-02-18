import { Link } from 'react-router-dom';
import Styles from './Welcome.module.scss';
import { FaHeart, FaUserFriends } from 'react-icons/fa';
import { FaMessage } from 'react-icons/fa6';

function WelcomePage() {
  return (
    <div className={Styles.container}>
        <header>
            <span className={Styles.icon}>
                <FaUserFriends/>
            </span>
            <h1>Friendium</h1>
            <p>Friendium is a friendly social platform designed to help you meet new people, make friends, and build genuine connections.</p>
        </header>
        <main>
            <div className={`${Styles.card} ${Styles.find}`}>
                <span className={Styles.icon}>
                    <FaUserFriends/>
                </span>
                <span className={Styles.cardTitle}>Find friends</span>
                <p>Discover people with similar interests and hobbies</p>
            </div>
            <div className={`${Styles.card} ${Styles.build}`}>
                <span className={Styles.icon}>
                    <FaHeart/>
                </span>
                <span className={Styles.cardTitle}>Build Connections</span>
                <p>Send friend requests and grow your network</p>
            </div>
            <div className={`${Styles.card} ${Styles.chat}`}>
                <span className={Styles.icon}>
                    <FaMessage/>
                </span>
                <span className={Styles.cardTitle}>Chat in Real-Time</span>
                <p>Have conversations with your friends instantly</p>
            </div>
        </main>
        <footer>
            <Link to="/auth/login">
                <button>Login</button>
            </Link>
            <Link to="/auth/signup">
                <button>Sign Up</button>
            </Link>
        </footer>
    </div>
  )
}

export default WelcomePage;