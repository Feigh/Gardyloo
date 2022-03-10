import React from 'react';
import ReactDOM from "react-dom";
import { BrowserRouter, Routes, Route} from "react-router-dom";
import logo from './logo.svg';
import 'bootstrap/dist/css/bootstrap.css';
import './App.css';
import StartUp from './component/StartUp'
import Settings from './component/Settings'
import { CookiesProvider } from "react-cookie";

function App() {
  return (
    <CookiesProvider>
    <div className="App">
      <header className="App-header">
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Settings />}/>
          <Route path="/startup" element={<StartUp />}/>
        </Routes>
      </BrowserRouter>
      </header>
    </div>
    </CookiesProvider>
  );
}

export default App;
