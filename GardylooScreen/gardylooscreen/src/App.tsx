import React, { useState, useEffect, useCallback } from 'react';
import ReactDOM from "react-dom";
import SettingsMain from './component/SettingsMain'
import PlayerWaitingRoom from './component/PlayerWaitingRoom'
import RoomReroute  from './component/RoomReroute'
import logo from './logo.svg';
import 'bootstrap/dist/css/bootstrap.css';
import './App.css';
import './custom.css';
import { BrowserRouter, Routes, Route} from "react-router-dom";
import { CookiesProvider } from "react-cookie";
import * as signalR from "@microsoft/signalr";
import { useCookies } from "react-cookie";
import axios from 'axios';
import {IPlayer, IRoom} from './component/Interfaces'
import { useNavigate  } from "react-router-dom";

function App() {
  
  const [ connection, setConnection ] = useState<signalR.HubConnection>();
  const [cookies, setCookie] = useCookies(['room']);
  const [playerlist, setPlayerList] = useState<IPlayer[]>([]);
  const naviate = useNavigate();

  const getNewRoom = async (): Promise<string> => {
    const respons = await axios.get('https://localhost:44327/api/gameroom')
    return respons.data.Name;
  }

  const CreateCookie = async () => {
    getNewRoom().then(room => {
      setCookie('room', room, { path: '/', sameSite:true });
      });
    }  

  const getRoom = async(name : string): Promise<IRoom> => {
    const respons = await axios.get('https://localhost:44327/api/gameroom/room', {
        params: {
            room: name
        }})
    console.log(respons.data);
    return respons.data
  }

  useEffect(() => {
      const hubConnection = new signalR.HubConnectionBuilder().withUrl("https://localhost:44327/statehub").build();
      setConnection(hubConnection);

      if(cookies.room === undefined){
        CreateCookie();
      } 
      else{
        getRoom(cookies.room).then(item => {
          if(item===null || item===undefined){
            CreateCookie();
          }
        }).catch (error => {
          CreateCookie();
        })
      }
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
                getRoomState(cookies.room)
                connection.on('GetRoomState', message => { // här säger man att man lyssnar på connection på kanalen getroomstate, server skickar data till denna
                    console.log("Received message"+ message);
                    RoomReroute(message, naviate);
                });
            })
            .catch(e => console.log('Connection failed: ', e));
    }


}, [connection]);

  return (
    <CookiesProvider>
    <div className="App">
      <header className="App-header">
        <Routes>
            <Route path="/" element={<SettingsMain roomName={cookies.room}/>}/> 
            <Route path="/startup" element={<PlayerWaitingRoom playerList={playerlist} />}/>
        </Routes>
      </header>
    </div>
    </CookiesProvider>
  );
}

export default App;
