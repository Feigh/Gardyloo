import React, { useState, useEffect } from 'react';

function SettingsActionButtons() {
    return ( <div className="col">
    <div id="inputarea" className="row mx-3 h-100">   
        <div className="col align-self-end">          
        <button className="btn btn-primary">Load Saved Settings</button>
        </div>
        <div className="col align-self-end"> 
        <button className="btn btn-primary">Save Settings</button>
        </div>
        <div className="col align-self-end">
        <button id="start" className="btn btn-primary btn-lg align-self-end">Start Game</button>
        </div>
    </div>
</div> );
}

export default SettingsActionButtons;