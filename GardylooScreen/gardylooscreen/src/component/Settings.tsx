import React, { useState, useEffect, EventHandler } from 'react';
import { useNavigate  } from "react-router-dom";
import { useCookies } from "react-cookie";
import axios from 'axios';
import TagList from './TagList'
import SettingsSelect from './SettingsSelect'
import SettingsActionButtons from './SettingsActionButtons'
import {IRoom, IRoomSettings} from './Interfaces'
import { Console } from 'console';


function Settings() {

    const [cookies, setCookie] = useCookies(['room']);
    const [room, setRoom] = useState<IRoom>();
    const [settings, setSettings] = useState<IRoomSettings>();

    let navigate = useNavigate();

    const getNewRoom = async (): Promise<String> => {
        console.log("create room")
        const respons = await axios.get('https://localhost:44327/api/gameroom')
        return respons.data.Name;
    }

    const getRoom = async(name : string): Promise<IRoom> => {
        console.log("get room data " + name)
        const respons = await axios.get('https://localhost:44327/api/gameroom/room', {
            params: {
                room: name
            }})
        return respons.data
    }

    const CreateCookie = async () => {
        var room = await getNewRoom()
        setCookie('room', room, { path: '/', sameSite:true });
    }

    const GetRoom = async () : Promise<IRoom> =>{
        let cookie = await getRoom(cookies.room)
        return cookie
    }

    const Redirect = async () =>{
        GetRoom().then(item => {
            if(item){ // return true, value check status else create new room
                // If you have a cookie check if tha room is active. if it is navigate to game
                if(item.GameStatus !== 'gamesetup')
                {
                    navigate('/startup')
                }
                setRoom(item);
                setSettings(item.Settings);
                // All is good stay att setup
            }
            else{
                setCookie('room', getNewRoom(), { path: '/', sameSite:true });
            }
            console.log(room)
        })

    }

    useEffect(() => {
        // If there is no room cookie call server for a new room
        if(cookies.room === undefined){
            CreateCookie()
            GetRoom();
            console.log("Laddade om datan");
        } 
        else{
            // check if room exist in server else create new cookie
            Redirect();
        }
        
    }, []);

    const changePlayer = (e:React.ChangeEvent<HTMLInputElement>) => { setSettings(prevState => {return {...prevState, MaxPlayers: parseInt(e.target.value)}})}

    return (
    <div className="container">
        <div>
            <h3 className="my-4">Setup Room</h3>
            <TagList/>
            <div className="row mt-4 lowerarea">
                <SettingsSelect GoalPoint={settings?.GoalPoint} MaxPlayers={settings?.MaxPlayers} TimeLimit={settings?.TimeLimit}
                    PlayerChange={(e:React.ChangeEvent<HTMLInputElement>) => { setSettings(prevState => {return {...prevState, MaxPlayers: parseInt(e.target.value)}})}}
                    PointChange={(e:React.ChangeEvent<HTMLInputElement>) => { setSettings(prevState => {return {...prevState, GoalPoint: parseInt(e.target.value)}})}}
                />
                <SettingsActionButtons/>           
            </div>
        </div>
    </div>
    );
}

export default Settings;