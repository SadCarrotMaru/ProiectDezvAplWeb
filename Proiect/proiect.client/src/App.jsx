import { useEffect, useState } from 'react';
import LoginForm from './components/LoginForm'; // Adjust the path accordingly
import RegistrationForm from './components/RegistrationForm'; // Adjust the path accordingly
import {
    BrowserRouter as Router,
    Routes,
    Route,
    Navigate,
} from "react-router-dom";
import './App.css';

function App() {

    <Router>
        <Routes>
            <Route
                exact
                path="/"
                element={<App />}
            />

            <Route
                path="/login"
                element={<LoginForm />}
            />

            <Route
                path="/registration"
                element={<RegistrationForm />}
            />

            {/* If any route mismatches the upper 
          route endpoints then, redirect triggers 
          and redirects app to home component with to="/" */}
            {/* <Redirect to="/" /> */}
            <Route
                path="*"
                element={<Navigate to="/" />}
            />
        </Routes>
    </Router>

    const [forecasts, setForecasts] = useState();

    useEffect(() => {
        populateWeatherData();
    }, []);

    const contents = forecasts === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Temp. (C)</th>
                    <th>Temp. (F)</th>
                    <th>Summary</th>
                </tr>
            </thead>
            <tbody>
                {forecasts.map(forecast =>
                    <tr key={forecast.date}>
                        <td>{forecast.date}</td>
                        <td>{forecast.temperatureC}</td>
                        <td>{forecast.temperatureF}</td>
                        <td>{forecast.summary}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    const redirectToLogin = () => {
        window.location.href = '/login';
    };

    const redirectToRegistration = () => {
        window.location.href = '/registration';
    };


    return (
        <div>
            <h1 id="tabelLabel">Weather forecast</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}

            <h2> Login aici poate intr-o zi?</h2>
            <button onClick={redirectToLogin}>Login</button>
            <button onClick={redirectToRegistration}>Registration</button>
        </div>

    );
    
    async function populateWeatherData() {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        setForecasts(data);

    }
}

export default App;