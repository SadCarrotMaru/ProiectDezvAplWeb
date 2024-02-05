import LoginForm from './components/LoginForm'; 
import Home from './Home';
import Utility from './components/Utility';
import RegistrationForm from './components/RegistrationForm'; 
import {
    BrowserRouter as Router,
    Routes,
    Route,
    Navigate,
} from "react-router-dom";
import './App.css';

function App() {

    return (

        <Router>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/login" element={<LoginForm />} />
                <Route path="/utility" element={<Utility />} />
                <Route path="/registration" element={<RegistrationForm />} />
                <Route path="*" element={<Navigate to="/" />} />
            </Routes>
        </Router>

    );
    
}

export default App;