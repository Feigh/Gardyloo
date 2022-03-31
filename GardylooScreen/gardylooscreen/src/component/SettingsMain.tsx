import React, { useState, useEffect, EventHandler } from 'react';
import { useNavigate  } from "react-router-dom";
import Settings from './Settings'
import { useCookies } from "react-cookie";
import axios from 'axios';
import {IRoom, IRoomSettings, ITag, ITagExtend, IEvent} from './Interfaces'

function SettingsMain(ws : IEvent) {

    const [cookies, setCookie] = useCookies(['room']);
    const [roomItem, setRoomItem] = useState<IRoom>({id:"", Name:"", GameStatus:"", PlayerList:[], Settings:{id:"", GoalPoint:0, MaxPlayers:0, TimeLimit:0, ExcludedTags:[], MinPlayers:0, SelectedTags:[]} });
  
    const getNewRoom = async (): Promise<string> => {
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
      console.log(roomItem);
      //const data = {}
      axios.post('https://localhost:44327/api/gameroom', roomItem)
        .then(res => console.log("posted"))
  
    }
  
    const CreateCookie = async () => {
      getNewRoom().then(room => {
        setCookie('room', room, { path: '/', sameSite:true });
        getRoom(room).then(item => {setRoomItem(item); ws.sendMessage(item.Name)
        });
      })  
    }
  
    const GetRoom = async () : Promise<IRoom> =>{
      let cookie = await getRoom(cookies.room)
      return cookie
    }
  
    useEffect(() => {
              // om cookie är tom skapa ett nytt rum
            if(cookies.room === undefined){
                CreateCookie();
            } 
            else{
              getRoom(cookies.room).then(item => {
                console.log("get room")
                if(item===null || item===undefined){
                  CreateCookie();
                }
                else{
                  setRoomItem(item)
                  ws.sendMessage(item.Name)
                }
              }).catch (error => {
                CreateCookie();
              })
            }
      
    }, []);

    return (
    <Settings roomGoal={roomItem===null ? 0: roomItem.Settings.GoalPoint} roomPlayers={roomItem===null ? 0: roomItem.Settings.MaxPlayers} roomTimeLimit={roomItem===null ? 0: roomItem.Settings.TimeLimit} 
        ChangeGoal={(e:React.ChangeEvent<HTMLInputElement>) => { setRoomItem(prevState => ({...prevState, Settings:{...prevState.Settings, GoalPoint: parseInt(e.target.value)}})) }}
        ChangePlayer={(e:React.ChangeEvent<HTMLInputElement>) => { setRoomItem(prevState => ({...prevState, Settings:{...prevState.Settings, MaxPlayers: parseInt(e.target.value)}}))}}
        FinishRoom={StartRoom}
        />  );
}

export default SettingsMain;