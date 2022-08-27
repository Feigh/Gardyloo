import React, { useState, useEffect } from 'react';
import {IPlayerInfo, IPlayer} from './Interfaces'


export function PlayerList(state:IPlayerInfo) {

    return (           
         <ul className='text-center'>
            { state.playerList.map(pl => <li><h4 id={pl.playerID} >{pl.playerName}</h4></li> )}
        </ul>);
}