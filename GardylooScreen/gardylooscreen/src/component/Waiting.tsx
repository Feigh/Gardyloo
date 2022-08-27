import React, { useState, useEffect } from 'react';
import {PlayerList} from './PlayerList'
import {IPlayer, IPlayerInfo} from './Interfaces'
import axios from 'axios';

function WaitingPlayers(players : IPlayerInfo) {

    return ( <div className='container'>
    <div className='row mt-5'>
        <h2 className='row justify-content-center'>Waiting for Players</h2>
        <h3 className='row justify-content-center'>Room Code: AAAA</h3>
        <div className='row mt-5 justify-content-center'>
            <PlayerList playerList={players.playerList}/>
        </div>
    </div>
</div> );
}

export default WaitingPlayers;