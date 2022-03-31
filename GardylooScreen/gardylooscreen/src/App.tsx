import React, { useState, useEffect } from 'react';
import ReactDOM from "react-dom";
import SettingsMain from './component/SettingsMain'
import StartUp from './component/StartUp'
import RoomReroute  from './component/RoomReroute'
import logo from './logo.svg';
import 'bootstrap/dist/css/bootstrap.css';
import './App.css';
import { BrowserRouter, Routes, Route} from "react-router-dom";
import { CookiesProvider } from "react-cookie";
import * as signalR from "@microsoft/signalr";

function App() {
  
  const [ connection, setConnection ] = useState<signalR.HubConnection>();

  useEffect(() => {
      const hubConnection = new signalR.HubConnectionBuilder().withUrl("https://localhost:44327/statehub").build();
      setConnection(hubConnection);
  }, []);

  const getRoomState = (room :string) =>{// bör ta in en string med rum id, så när settings har skapat ett rum då anropas getstate
    console.log("GetState " + room);
    if (connection) { 
    connection.invoke("GetState", room).catch(function (err) { // här så gör klienten ett anrop
        console.error(err.toString());
    });
    }
}

  useEffect(() => {

    if (connection) {
        connection.start()
            .then(result => {
                console.log('Connected!');  
                // här vill jag anropa getstate där jag vill få veta ny state varje gång den ändras
                connection.on('GetRoomState', message => { // här säger man att man lyssnar på connection på kanalen getroomstate, server skickar data till denna
                    console.log("Received message"+ message);
                    RoomReroute(message)
                });
            })
            .catch(e => console.log('Connection failed: ', e));
    }


}, [connection]);

  return (
    <CookiesProvider>
    <div className="App">
      <header className="App-header">
      <BrowserRouter>
        <Routes>
            <Route path="/" element={<SettingsMain  sendMessage={(x) => getRoomState(x)}/>}/> 
            <Route path="/startup" element={<StartUp />}/>
        </Routes>
      </BrowserRouter>
      </header>
    </div>
    </CookiesProvider>
  );
}

export default App;
