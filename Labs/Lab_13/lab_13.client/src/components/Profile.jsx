import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import './Profile.css';
import { useAuth } from '../AuthContext';

const Profile = () => {
    const [profile, setProfile] = useState(null);
    const navigate = useNavigate();
    const { logout } = useAuth();

    useEffect(() => {
        const storedProfile = localStorage.getItem('userProfile');
        if (storedProfile) {
            setProfile(JSON.parse(storedProfile));
        } else {
            navigate('/login');
        }
    }, [navigate]);

    const handleLogout = async () => {
        try {
            await axios.post('/api/account/logout');
            logout();
            navigate('/');
        } catch (error) {
            console.error('Logout error:', error);
            alert('Logout failed: ' + (error.response?.data?.Error || error.message));
        }
    };

    if (!profile) {
        return <p>Loading profile...</p>;
    }

    return (
        <div className="profile-container">
            <div className="profile-header"></div>

            <div className="profile-info">
                <h2>{profile.fullName}`s Profile</h2>
                <div className="profile-details">
                    <img src="..\..\public\images\Group 1.png" alt="Profile Image" className="profile-img" />
                    <div className="user-info">
                        <p className="info-item">
                            <img src="..\..\public\img\FullName.svg" /> <span>{profile.fullName}</span>
                        </p>
                        <p className="info-item">
                            <img src="..\..\public\img\Phone.svg" /> <span>{profile.userName}</span>
                        </p>
                        <p className="info-item">
                            <img src="..\..\public\img\UserName.svg" /> <span>{profile.email}</span>
                        </p>
                        <p className="info-item">
                            <img src="..\..\public\img\Email.svg" /><span>{profile.phone}</span>
                        </p>
                    </div>
                </div>
                <button onClick={handleLogout} className="btn btn-primary btn-logout mt-4">
                    Logout
                </button>
            </div>
        </div>
    );
};

export default Profile;