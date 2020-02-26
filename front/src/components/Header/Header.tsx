import React, { useState } from "react";

import styles from "./Header.module.scss";
import { IUserWithAddress } from "../../models/User";
import { loginService } from "../../services/login.service";

const { header: headerClass, anti: antiClass, profileInfo: profileInfoClass } = styles;

interface IHeaderProps {
    onClick: () => void
    user: IUserWithAddress;
}

interface IHeaderState {
    name: string | undefined;
}

export function Header(props: IHeaderProps) {
    return (<header className={headerClass}>
        <span className={antiClass}>Anti</span>
        <span>Social App</span>

        {props.user?.name && <div className={profileInfoClass}>
            <span>{props.user.name}</span>
            <a onClick={props.onClick}>Sign Out</a>
        </div>}
    </header>)
}