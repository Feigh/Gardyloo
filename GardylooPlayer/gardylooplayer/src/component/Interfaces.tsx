export interface IRoom {
    id: string;
    Name: string;
    GameStatus:string;
    PlayerList:[];
}

export interface IPlayerData {
    id: string;
    Name: string;
    Room:string;
}