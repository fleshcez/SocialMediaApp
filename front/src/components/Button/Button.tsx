import React from "react";
import styles from "./Button.module.scss";

const { primary: primaryClass, secondary: secondaryClass } = styles;

interface IButtonProps {
    label: string;
    type?: "primary" | "secondary";
    padding?: string;
    fontSize?: string;

    onClick: () => void;
}

export function Button(props: IButtonProps) {
    const buttonTypeClass = !props.type ? primaryClass : (props.type === "secondary" ? secondaryClass : primaryClass);
    const paddingStyle = props.padding ? props.padding: "5px 10px";
    const fontSizeStyle = props.fontSize ? props.fontSize : "16px";

    return (
        <button
            className={
                buttonTypeClass
            }
            style = {{padding: paddingStyle, fontSize: fontSizeStyle}}
            onClick={props.onClick} >
            {props.label}
        </button >
    )
}