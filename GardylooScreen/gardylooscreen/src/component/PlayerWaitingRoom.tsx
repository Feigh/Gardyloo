import React, { useState, useEffect } from 'react';
import * as signalR from "@microsoft/signalr";

function PlayerWaitingRoom() {
    return (
        <div className='container'>
        <div className='row mt-5'>
            <h2 className='row justify-content-center'>Waiting for Players</h2>
            <h3 className='row justify-content-center'>Room Code: AAAA</h3>
            <div className='row mt-5 justify-content-center'>
                <ul className='text-center'>
                    <li><h4>Bob</h4></li>
                    <li><h4>Alice</h4></li>
                </ul>
            </div>
        </div>
    </div>
    );
}

export default PlayerWaitingRoom;