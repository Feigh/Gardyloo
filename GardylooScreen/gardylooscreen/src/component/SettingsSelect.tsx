import React, { useState, useEffect } from 'react';
import TextBox from './TextBox'

interface ISettingsSelection {
    GoalPoint?: number;
    MaxPlayers?: number;
    TimeLimit?: number;
    PlayerChange(e:React.ChangeEvent<HTMLInputElement>) : any;
    PointChange(e:React.ChangeEvent<HTMLInputElement>): any;
}

function SettingsSelect(settings : ISettingsSelection) {
    return (
        <div className="col">
        <div id="settinglist" className=" mx-3 h-100 ">
        <h4>Settings</h4>
            <div className="mx-3 border-4 rounded-3">
                <div className="col-4">
                    <TextBox Title='Players' Value={settings.MaxPlayers ? settings.MaxPlayers.toString() : ""} Change={settings.PlayerChange} />
                    <TextBox Title='Victory Points' Value={settings.GoalPoint ? settings.GoalPoint.toString() : ""} Change={settings.PointChange} />
                </div>
            </div>
        </div>
    </div> );
}

export default SettingsSelect;