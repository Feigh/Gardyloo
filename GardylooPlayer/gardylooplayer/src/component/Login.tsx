import React, { useState, useEffect } from 'react';
import TextBox from './TextBox'
import axios from 'axios';

export interface IPlayerAdd {
    id: string;
    Name: string;
    Room:string;
}

function Login() {

    const [player, setPlayer] = useState<IPlayerAdd>();

    const StartRoom = () => {
        axios.post('https://localhost:44327/api/player', player)
          .then(res => console.log("PlayerAdded") )
          .catch(err => console.log(err))
    
      }


    return (  
        <div className="container">
        <div className="row mt-5">
            <h2 className="row justify-content-center">Gardyloo</h2>
            <div className="row mt-5 justify-content-center">
                <div className="row">
                    <TextBox Id="pln" Title='Player Name:' Value="stuff" Change={()=>{}} />
                </div>
                <div className="row">
                    <TextBox Id="ron" Title='Room Name:' Value="stuff" Change={()=>{}} />
                </div>
                <div className="row">
                    <button id="start" className="btn btn-primary btn-lg mt-4">Join Game</button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Login;