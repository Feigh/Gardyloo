import React, { useState, useEffect, EventHandler } from 'react';

import TagList from './TagList'
import SettingsSelect from './SettingsSelect'
import SettingsActionButtons from './SettingsActionButtons'
import {IRoom, IRoomSettings, ITag, ITagExtend} from './Interfaces'

export interface ISettings {
    roomGoal : number;
    roomPlayers: number;
    roomTimeLimit:number
    ChangePlayer(e:React.ChangeEvent<HTMLInputElement>) : any;
    ChangeGoal(e:React.ChangeEvent<HTMLInputElement>) : any;
    FinishRoom() : any;
  }
// ska hämta och ha koll på settings
function Settings(setting: ISettings) {

    const [taglist, setTaglist] = useState<ITagExtend[]>([]);

    const SaveSettings = (e:React.MouseEvent<HTMLButtonElement>) => {
        console.log("Not implemented");
    }
    const LoadSettings = (e:React.MouseEvent<HTMLButtonElement>) => {
        console.log("Not implemented");
    }


    useEffect(() => {
    }, []);

    return (
    <div className="container">
        <div>
            <h3 className="my-4">Setup Room</h3>
            <TagList taglist={taglist} setEvent={x => setTaglist(x)}/>
            <div className="row mt-4 lowerarea">
                <SettingsSelect GoalPoint={setting.roomGoal} MaxPlayers={setting.roomPlayers} TimeLimit={setting.roomTimeLimit}
                    PlayerChange={x => setting.ChangePlayer(x)}
                    PointChange={x => setting.ChangeGoal(x)}
                />
                <SettingsActionButtons startGame={() => setting.FinishRoom()} loadSetting={LoadSettings} saveSetting={SaveSettings}/>           
            </div>
        </div>
    </div>
    );
}

export default Settings;