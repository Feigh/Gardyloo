import React from 'react';
import ReactDOM from "react-dom";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import logo from './logo.svg';
import 'bootstrap/dist/css/bootstrap.css';
import './App.css';
import AwaitStart from './component/AwaitStart'

function App() {
  return (
    <div className="App">
      <header className="App-header">
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<AwaitStart />}/>
        </Routes>
      </BrowserRouter>
      </header>
    </div>
  );
}

export default App;
