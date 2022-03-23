export interface IRoomSettings {
    id: string;
    GoalPoint: number;
    MaxPlayers: number;
    MinPlayers: number;
    TimeLimit: number;
    SelectedTags:[];
    ExcludedTags:[];
}

export interface IRoom {
    id: string;
    Name: string;
    GameStatus:string;
    Settings: IRoomSettings;
    PlayerList:[];
}

export interface ITag {
    Text: string;
    id: string;
}

export interface ITagExtend extends ITag {
    active?: boolean;
    ToggleButton?(id:string) : any;
}

export interface ITagState {
    taglist: ITagExtend[];
    setEvent(list:ITagExtend[]) : any;
}

