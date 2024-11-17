import { useNavigate } from 'react-router-dom';

const Home = () => {
    const navigate = useNavigate();

    const handleLoginClick = () => {
        navigate('/login');
    };

    return (
        <div>
            <h1>Welcome!</h1>
            <p>
                This application allows execute lab works 1, 2 and 3. Please, log in or sign up to
                start.
            </p>
            <button className="btn btn-primary mt-3" onClick={handleLoginClick}>
                Log in now
            </button>
        </div>
    );
};

export default Home;