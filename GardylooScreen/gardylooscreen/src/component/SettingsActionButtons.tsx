import React, { useState, useEffect } from 'react';

export interface ISettingsAction {
    startGame(e:React.MouseEvent<HTMLButtonElement>) : any;
    saveSetting(e:React.MouseEvent<HTMLButtonElement>) : any;
    loadSetting(e:React.MouseEvent<HTMLButtonElement>) : any;
}

function SettingsActionButtons(event:ISettingsAction) {
    return ( <div className="col">
    <div id="inputarea" className="row mx-3 h-100">   
        <div className="col align-self-end">          
        <button className="btn btn-primary" onClick={event.loadSetting}>Load Saved Settings</button>
        </div>
        <div className="col align-self-end"> 
        <button className="btn btn-primary" onClick={event.saveSetting}>Save Settings</button>
        </div>
        <div className="col align-self-end">
        <button id="start" className="btn btn-primary btn-lg align-self-end" onClick={event.startGame} >Start Game</button>
        </div>
    </div>
</div> );
}

export default SettingsActionButtons;