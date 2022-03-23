import React, { useState, useEffect } from 'react';
import {ITag, ITagExtend} from './Interfaces'

function TagBox(item:ITagExtend) {

    const ChangeButtonState = () : string => {
        if(item.active===false){
            return "btn m-2 tag-item inactive"
        }
        return "btn m-2 tag-item active"
    }

    return (      
        <button id={item.id} className={ChangeButtonState()} onClick={() => {if(item.ToggleButton) item.ToggleButton(item.id)}} >{item.Text}</button>
    );
}

export default TagBox;