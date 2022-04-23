import React, { useState, useEffect, useCallback } from 'react';
import ReactDOM from "react-dom";
import Login from "./component/Login"
import { BrowserRouter, Routes, Route} from "react-router-dom";
import './App.css';
import 'bootstrap/dist/css/bootstrap.css';

function App() {
  return (
        <Routes>
            <Route path="/" element={<Login/>}/> 
        </Routes>
  );
}

export default App;
