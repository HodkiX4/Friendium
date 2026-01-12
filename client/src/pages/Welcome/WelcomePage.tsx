import { Link } from 'react-router-dom';
import Styles from './Welcome.module.scss';

function WelcomePage() {
  return (
    <div className={Styles.container}>
        <header>
            <h1>Friendium</h1>
        </header>
        <main>
            <section className={Styles.welcome}>

            <h4>Welcome to Friendium</h4>
            <h6>Here to help you find, real connections</h6>
            </section>

            <section className={Styles.introduction}>
            <p>Friendium is a friendly social platform designed to help you meet new people, make friends, and build genuine connections. Whether you're new in town or just looking for someone who shares your interests, Friendium makes it easy to discover and connect. Start your journey toward new friendships today!</p>
            </section>
            <section className={Styles.screenshots}>
                {/*<img src="" alt="" />*/}
            </section>
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

export default WelcomePage