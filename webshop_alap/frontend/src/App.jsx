import Header from "./components/Header";
import {BrowserRouter as Router,Routes,Route,Navigate} from 'react-router-dom';
import Main from "./components/Main";
import Vevok from "./components/Vevok";
import UjVevo from "./components/UjVevo";
import Menu from "./components/Menu";

function App() {
  

  return (
   <Router>
    <Header szoveg={"Webshop"}/>
    <Menu/>
    <Routes>
     <Route path="/" element={<Main />}/>
     <Route path="/vevok" element={<Vevok />}/>
     <Route path="/ujvevo" element={<UjVevo/>}/>
     <Route path="*" element={<Navigate to={'/'}/>}/>
    </Routes>
   </Router>
  )
}

export default App
