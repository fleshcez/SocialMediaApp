import React, { useEffect, useState, ChangeEvent } from "react";
import styles from "./TextField.module.scss";

const { field: fieldClass } = styles;

export interface ITextFieldProps {
    value: string;
    label: string;
    type?: "password" | "text";
    onChange: (val: string) => void;
}

export function TextField(props: ITextFieldProps) {
    // const [value, setValue] = useState(props.value);

    // const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
    //     const val = event.target.value;

    //     setValue(val);
    //     props.onChange(val);
    // };

    return (
        <div className={fieldClass}>
            <label>
                {props.label}
            </label>
            <input
                type={props.type || "text"}
                value={props.value}
                onChange={(event: ChangeEvent<HTMLInputElement>)=> {
                    props.onChange(event.target.value)
                }} />
        </div>
    )
}