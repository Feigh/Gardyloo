import React, { useState, useEffect } from 'react';
import {ITag, ITagExtend,ITagState} from './Interfaces'
import axios from 'axios';
import TagBox from './TagBox';

// Jag vill ha en lista med alla taggar som finns
// varje tag har en action där den togglas.
// parent har en lista med alla valda taggar
// när spara eller starta klickas så skickas ett anrop hit där den får en lista med taggar
// tag list gör api anropen
// men 
function TagList(state:ITagState) {

    useEffect(() => {

        getTags().then(item => {

            let newItem : ITagExtend[] = [...item ]
            newItem.map(x => x.active=true)
            state.setEvent(newItem) // lägg in en tagextendarray här så gör den riktiga seten i parent
        })
    }, []);

    const getTags= async (): Promise<ITag[]> => {
        const respons = await axios.get('https://localhost:44327/api/GameTag')
        return respons.data;
    }

    const toggleTag = (id: string) =>{
        let updlist = state.taglist.map(x => { if(x.id===id) x.active = !x.active; return x; })
        state.setEvent(updlist)
    }

    return (
        <div className="row">
        <div className="col">
            <h4 className="my-3">Tags</h4>
            <div  id="taglist" className="mx-3 p-3 border border-4 rounded-3">
                { state.taglist.map(tag => <TagBox id={tag.id} Text={tag.Text} active={tag.active} ToggleButton={toggleTag} /> )}
            </div>
        </div>
    </div> );
}

export default TagList;