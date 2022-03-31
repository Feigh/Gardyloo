import React, { useState, useEffect } from 'react';
import * as signalR from "@microsoft/signalr";

function RoomState() {

    const [ connection, setConnection ] = useState<signalR.HubConnection>();

    useEffect(() => {
        const hubConnection = new signalR.HubConnectionBuilder().withUrl("https://localhost:44327/statehub").build();
        setConnection(hubConnection);
    }, []);

    const sendMessage = () =>{
        console.log('GeState');  
        if (connection) {
        connection.invoke("GetState", "boop").catch(function (err) {
            return console.error(err.toString());
        });
        }
    }

    useEffect(() => {

        if (connection) {
            connection.start()
                .then(result => {
                    console.log('Connected!');  
                    connection.on('GetRoomState', message => {
                        console.log("Received message"+ message);
                    });
                })
                .catch(e => console.log('Connection failed: ', e));
        }


    }, [connection]);

    return ( <div></div> );
}

export default RoomState;