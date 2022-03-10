import React, { useState, useEffect, SetStateAction } from 'react';

interface ITextBox {
    Title: string;
    Value: string;
    Change(e:React.ChangeEvent<HTMLInputElement>) :any;
    //Change: (value: string) => {};
}

function TextBox(prop: ITextBox) {
    return (
    <div className="row">
    <label htmlFor="vct">{prop.Title}</label>
    <input id="vct" className="form-control" onChange={prop.Change} type="text" value={prop.Value} />
</div>  );
}

export default TextBox;