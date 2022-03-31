import { useNavigate  } from "react-router-dom";

function RoomReroute(state: string) {

    const navigate = useNavigate();

    if(state==='waitingtostart'){
        navigate("/startup")
    }
    else{
        navigate("/")
    }
}

export default RoomReroute;