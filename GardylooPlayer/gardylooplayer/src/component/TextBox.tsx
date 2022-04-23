import React, { useState, useEffect, SetStateAction } from 'react';

interface ITextBox {
    Id:string;
    Title: string;
    Value: string;
    Change(e:React.ChangeEvent<HTMLInputElement>) :any;
    //Change: (value: string) => {};
}

function TextBox(prop: ITextBox) {
    return (
    <div className="row">
        <label htmlFor={prop.Id}>{prop.Title}</label>
        <input id={prop.Id} className="form-control" onChange={prop.Change} type="text" value={prop.Value}  />
</div>  );
}

export default TextBox;