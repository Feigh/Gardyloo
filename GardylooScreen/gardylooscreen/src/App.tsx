import React, { useState, useEffect } from 'react';
import ReactDOM from "react-dom";
import { BrowserRouter, Routes, Route} from "react-router-dom";
import logo from './logo.svg';
import 'bootstrap/dist/css/bootstrap.css';
import './App.css';
import { useNavigate  } from "react-router-dom";
import StartUp from './component/StartUp'
import Settings from './component/Settings'
import { CookiesProvider } from "react-cookie";
import { useCookies } from "react-cookie";
import axios from 'axios';
import {IRoom, IRoomSettings, ITag, ITagExtend} from './component/Interfaces'

function App() {

  const [cookies, setCookie] = useCookies(['room']);
  const [roomItem, setRoomItem] = useState<IRoom>({id:"", Name:"", GameStatus:"", PlayerList:[], Settings:{id:"", GoalPoint:0, MaxPlayers:0, TimeLimit:0, ExcludedTags:[], MinPlayers:0, SelectedTags:[]} });

  const getNewRoom = async (): Promise<String> => {
    const respons = await axios.get('https://localhost:44327/api/gameroom')
    return respons.data.Name;
  }

  const getRoom = async(name : string): Promise<IRoom> => {
    console.log("get room data " + name)
    const respons = await axios.get('https://localhost:44327/api/gameroom/room', {
        params: {
            room: name
        }})
    console.log(respons.data);
    return respons.data
  }

  const StartRoom = () => {
    console.log("get start data ")
    //const data = {}
    axios.post('https://localhost:44327/api/gameroom', roomItem).
      then(res => console.log("posted"))

  }

  const CreateCookie = async () => {
    getNewRoom().then(room => setCookie('room', room, { path: '/', sameSite:true }))  
  }

  const GetRoom = async () : Promise<IRoom> =>{
    let cookie = await getRoom(cookies.room)
    return cookie
  }

  useEffect(() => {
            // om cookie är tom skapa ett nytt rum
          if(cookies.room === undefined){
              CreateCookie();
              GetRoom().then(item => setRoomItem(item));
          } 
          else{

            getRoom(cookies.room).then(item => {
              if(item!==null){
                setRoomItem(item)
              }
              else{
                CreateCookie();
              }
            });
          }
    
  }, []);

  return (
    <CookiesProvider>
    <div className="App">
      <header className="App-header">
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Settings roomGoal={roomItem===null ? 0: roomItem.Settings.GoalPoint} roomPlayers={roomItem===null ? 0: roomItem.Settings.MaxPlayers} roomTimeLimit={roomItem===null ? 0: roomItem.Settings.TimeLimit} 
                                    ChangeGoal={(e:React.ChangeEvent<HTMLInputElement>) => { setRoomItem(prevState => ({...prevState, Settings:{...prevState.Settings, GoalPoint: parseInt(e.target.value)}})) }}
                                    ChangePlayer={(e:React.ChangeEvent<HTMLInputElement>) => { setRoomItem(prevState => ({...prevState, Settings:{...prevState.Settings, MaxPlayers: parseInt(e.target.value)}}))}}
                                    FinishRoom={StartRoom}
                                    />}/> 
          <Route path="/startup" element={<StartUp />}/>
        </Routes>
      </BrowserRouter>
      </header>
    </div>
    </CookiesProvider>
  );
}

export default App;
