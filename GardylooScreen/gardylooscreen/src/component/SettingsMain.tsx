import React, { useState, useEffect, EventHandler } from 'react';
import { useNavigate  } from "react-router-dom";
import Settings from './Settings'

import axios from 'axios';
import {IRoom, IRoomSettings, ITag, ITagExtend, IEvent, IAppData} from './Interfaces'

function SettingsMain(app : IAppData) {

    const [roomItem, setRoomItem] = useState<IRoom>({id:"", Name:"", GameStatus:"", PlayerList:[], Settings:{id:"", GoalPoint:0, MaxPlayers:0, TimeLimit:0, ExcludedTags:[], MinPlayers:0, SelectedTags:[]} });
  
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
  
    useEffect(() => {

      getRoom(app.roomName).then(items => setRoomItem(items))
      
    }, []);

    return (
    <Settings roomGoal={roomItem===null ? 0: roomItem.Settings.GoalPoint} roomPlayers={roomItem===null ? 0: roomItem.Settings.MaxPlayers} roomTimeLimit={roomItem===null ? 0: roomItem.Settings.TimeLimit} 
        ChangeGoal={(e:React.ChangeEvent<HTMLInputElement>) => { setRoomItem(prevState => ({...prevState, Settings:{...prevState.Settings, GoalPoint: parseInt(e.target.value)}})) }}
        ChangePlayer={(e:React.ChangeEvent<HTMLInputElement>) => { setRoomItem(prevState => ({...prevState, Settings:{...prevState.Settings, MaxPlayers: parseInt(e.target.value)}}))}}
        FinishRoom={StartRoom}
        />  );
}

export default SettingsMain;