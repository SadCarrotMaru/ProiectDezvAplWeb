import { useState } from 'react';

const LoginForm = () => {
    const [formData, setFormData] = useState({
        userName: '',
        password: '',
    });
    const [loading, setLoading] = useState(false);
    const [loginFailed, setLoginFailed] = useState(false);

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        setLoginFailed(false); 

        try {
            const response = await fetch('users/login', {    //https://localhost:7058/Users/login
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(formData),
            });

            if (response.ok) {
                const data = await response.json();
                console.log('Login successful:', data);
                history.push('/home');
            } else {
                console.log('Login failed');
                setLoginFailed(true); 
            }
        } catch (error) {
            console.error('Error during login:', error);
        } finally {
            setLoading(false);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            {loginFailed && (
                <div>
                    <p>Login failed, please try again.</p>
                    <img src="https://media.tenor.com/5JoCWjXyrXcAAAAM/poro-stare.gif" alt="Failure GIF" />
                </div>
            )}

            <label>
                Username:
                <input
                    type="text"
                    name="userName"
                    value={formData.userName}
                    onChange={handleChange}
                />
            </label>
            <br />
            <label>
                Password:
                <input
                    type="password"
                    name="password"
                    value={formData.password}
                    onChange={handleChange}
                />
            </label>
            <br />
            <button type="submit" disabled={loading}>
                {loading ? 'Logging in...' : 'Login'}
            </button>

        </form>
    );
};

export default LoginForm;
