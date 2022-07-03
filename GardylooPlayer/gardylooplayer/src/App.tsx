import React, { useState, useEffect, useCallback } from 'react';
import ReactDOM from "react-dom";
import Login, {IPlayerAdd} from "./component/Login"
import { BrowserRouter, Routes, Route} from "react-router-dom";
import './App.css';
import 'bootstrap/dist/css/bootstrap.css';

function App() {

  const [player, setPlayer] = useState<IPlayerAdd>({id:"",Name:"", Room:""});

  return (
        <Routes>
            <Route path="/" element={<Login Name={player.Name} Room={player.Room} id={player.id} />}/> 
        </Routes>
  );
}

export default App;
 