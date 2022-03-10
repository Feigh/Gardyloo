import React, { useState, useEffect } from 'react';

function TagList() {
    return (
        <div className="row">
        <div className="col">
            <h4 className="my-3">Tags</h4>
            <div  id="taglist" className="mx-3 p-3 border border-4 rounded-3">
                <button className="btn m-2 tag-item active">Music </button>
                <button className="btn m-2 tag-item active">Movies</button>
                <button className="btn m-2 tag-item active">Bad Movies</button>
                <button className="btn m-2 tag-item active">Neel Breen</button>
                <button className="btn m-2 tag-item active">Super Mario</button>
                <button className="btn m-2 tag-item active">General</button>
                <button className="btn m-2 tag-item active">Nature</button>
                <button className="btn m-2 tag-item active">Video Games</button>
                <button className="btn m-2 tag-item active">Streamers</button>
                <button className="btn m-2 tag-item active">Memes General</button>
                <button className="btn m-2 tag-item active">Animals</button>
                <button className="btn m-2 tag-item active">Music Bad</button>
                <button className="btn m-2 tag-item inactive">Weapons</button>
                <button className="btn m-2 tag-item inactive">NSFW</button>
            </div>
        </div>
    </div> );
}

export default TagList;