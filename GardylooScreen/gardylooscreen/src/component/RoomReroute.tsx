import React from 'react';

const RoomReroute = (state: string) => {

    console.log(state);
    try{

        if(state==='waitingtostart'){
            //window.location.replace("/startup")
        }
        else{
            //window.location.replace("/")
        }
    }
    catch(err){
        console.log(err)
    }
}

export default RoomReroute;

