import { useState } from 'react';

const LoginForm = () => {
    const [formData, setFormData] = useState({
        userName: '',
        password: '',
    });
    const [loading, setLoading] = useState(false);

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        console.log(formData);

        try {
            const response = await fetch('http://localhost:7058/Users/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(formData),
            });

            if (response.ok) {
                // Assuming your API returns some kind of success message or token
                const data = await response.json();
                console.log('Login successful:', data);

                // Redirect to the home page after successful login
                history.push('/home');
            } else {
                console.log('Login failed');
                // Handle login failure, you can show an error message or handle it as needed
            }
        } catch (error) {
            console.error('Error during login:', error);
            // Handle network errors or other issues
        } finally {
            setLoading(false);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
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
