import { useNavigate  } from "react-router-dom";

function RoomReroute(state: string, navigate : any) {

    console.log("stuff")
    
    try {
        console.log("boop")
    
        if(state==='waitingtostart'){
            // if windows current site is not /startup then do navigate
            navigate("/startup",0)
        }
        else{
            navigate("/",0)
        }  
    } catch (error) {
        console.log(error)
    }

}

export default RoomReroute;