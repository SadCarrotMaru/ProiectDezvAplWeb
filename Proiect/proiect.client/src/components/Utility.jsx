import championIcon1 from '../assets/braum.png';  
import championIcon2 from '../assets/tk.png';  
import './styles.css'; 


const App = () => {  // Practic fiecare imagine ar trebui sa ii poti sa ii dai drag & drop deasupra hartii ca sa pui un campion pe un anumit rol. ( vor fi 10 maxim roluri, 5 in fiec echipa, tabelul selectedchamps, nu am mai implementat)
    return (
        <div className="app-container">
            
            <img className="huge-image" src="https://i.redd.it/t5c9r23c1fzb1.png" alt="Huge Image" />

            {}
            <div className="circle-container">
                <div className="circle">
                    <img src={championIcon1} alt="Champion Icon 1" />
                </div>
                {}

                <div className="circle">
                    <img src={championIcon2} alt="Champion Icon 2" />
                </div>
            </div>

            <img className="gif-image" src="https://media.tenor.com/PARGIXCTGDIAAAAM/poro-lol.gif" alt="Gif Image" />
        </div>
    );
};

export default App;
