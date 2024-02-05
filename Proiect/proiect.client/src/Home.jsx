import './App.css';

function App() {



    const redirectToLogin = () => {
        window.location.href = '/login';
    };

    const redirectToUtil = () => {
        window.location.href = '/utility';
    };

    const redirectToRegistration = () => {
        window.location.href = '/registration';
    };

    return (
            <div>
            <h1>League Draft Helper</h1>
            <img className="gif-image" src="https://media.tenor.com/YAZMcNlr9AkAAAAM/league-of-legends-poro.gif" alt="Gif Image" />

                <h2> :D </h2>
                <button onClick={redirectToLogin}>Login</button>
                <button onClick={redirectToRegistration}>Registration</button>
                <button onClick={redirectToUtil}>Map</button>
            </div>

    );

}

export default App;