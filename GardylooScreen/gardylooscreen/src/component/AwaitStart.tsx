import React, { useState, useEffect } from 'react';
import * as signalR from "@microsoft/signalr";
import 'bootstrap/dist/css/bootstrap.css';
import '../custom.css'

export interface IPlayerHub {
    HubConnect: signalR.HubConnection;
  }

function AwaitStart() {

    const [ connection, setConnection ] = useState<signalR.HubConnection>();

    useEffect(() => {
        const hubConnection = new signalR.HubConnectionBuilder().withUrl("https://localhost:44327/playerhub").build();
        setConnection(hubConnection);
    }, []);

    const sendMessage = async () => {

        if (connection) {
            try {
                await connection.send('GetPlayerState', null);
            }
            catch(e) {
                console.log(e);
            }
        }
        else {
            alert('No connection to server yet.');
        }
    }

    useEffect(() => {

        if (connection) {
            connection.start()
                .then(result => {
                    console.log('Connected!');  
                    connection.on('ReceiveMessage', message => {
                        console.log("Received message"+ message);
                    });
                })
                .catch(e => console.log('Connection failed: ', e));
        }

    }, [connection]);

    const SendMessage = () =>{
        if (connection) {
        connection.invoke("SendMessage", "boop").catch(function (err) {
            return console.error(err.toString());
        });
        }
    }

    return (
        <div className='container'>
        <div className='row mt-5'>
            <h2 className='row justify-content-center'>Waiting for Players</h2>
            <h3 className='row justify-content-center'>Room Code: AAAA</h3>
            <div className='row mt-5 justify-content-center'>
                <ul className='text-center'>
                    <li><h4>Bob</h4></li>
                    <li><h4>Alice</h4></li>
                </ul>
                <button onClick={SendMessage}></button>
            </div>
        </div>
    </div>
    );
}

export default AwaitStart;