import React, { useState } from "react";
import { TextField } from "../TextField/TextField";
import styles from "./Login.module.scss";
import { Button } from "../Button/Button";
import { loginService } from "../../services/login.service";
import { navigationService } from "../../services/navigation.service";

const { form: formClass, login: loginClass, buttons: buttonsClass } = styles;

interface ILoginState {
    userName: string;
    password: string;
    hasError: boolean;
}

export function Login(props: {}) {
    const [state, updateState] = useState<ILoginState>({
        userName: "",
        password: "",
        hasError: false
    });

    const handleLogin = async () => {
        const user = await loginService.login(
            state.userName,
            state.password
        );

        updateState({
            ...state,
            hasError: Boolean(!user)
        })

        if (user) {
            navigationService.go("/")
        }
    }

    return (
        <div className={loginClass}>
            <div className={formClass}>
                <TextField
                    label="Username"
                    value={state.userName}
                    onChange={(value) => {
                        updateState({
                            ...state,
                            userName: value
                        })
                    }}
                />
                <TextField
                    label="Password"
                    value={state.password}
                    type="password"
                    onChange={(value) => {
                        updateState({
                            ...state,
                            password: value
                        })
                    }} />
                <div className={buttonsClass}>
                    <Button label="Login"
                        onClick={handleLogin} />
                    <Button label="Register"
                        type="secondary"
                        onClick={()=>{navigationService.go("/register")}}/>
                </div>
                {
                    state.hasError &&
                        <div style={{ color: "red", margin: "0"}}>Invalid user or password</div>
                }
            </div>
        </div>
    );
}