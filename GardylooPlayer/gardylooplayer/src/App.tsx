import React, { useState, useEffect, useCallback } from 'react';
import ReactDOM from "react-dom";
import Login from "./component/Login"
import {IPlayerData} from "./component/Interfaces"
import { BrowserRouter, Routes, Route} from "react-router-dom";
import './App.css';
import 'bootstrap/dist/css/bootstrap.css';

function App() {

  const [player, setPlayer] = useState<IPlayerData>({id:"",Name:"", Room:""});

  return (
        <Routes>
            <Route path="/" element={<Login Name={player.Name} Room={player.Room} id={player.id} setPlayer={setPlayer} setRoom={() => {}} />}/> 
        </Routes>
  );
}

export default App;
 