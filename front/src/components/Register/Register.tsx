import React, { useState } from "react";
import { TextField } from "../TextField/TextField";
import styles from "./Register.module.scss";
import { Button } from "../Button/Button";
import { loginService } from "../../services/login.service";
import { navigationService } from "../../services/navigation.service";
import { IUserWithAddress } from "../../models/User";

const { register: registerClass, form: formClass, buttons: buttonsClass } = styles;

interface IRegisterState extends IUserWithAddress {
    hasError: boolean;
}

export function Register() {
    const [state, updateState] = useState<IRegisterState>({
        userName: "",
        password: "",
        confirmedPassword: "",
        email: "",
        name: "",
        streetName: "",
        houseNumber: "",
        apartmentNumber: "",
        hasError: false
    });

    const handleRegister = async (state: IUserWithAddress) => {
        const user = await loginService.register(state);

        if (user) {
            navigationService.go("/main")
        }
    }

    const hasError = (): boolean => {
        if (!state.userName || !state.password || !state.streetName || !state.confirmedPassword || !state.houseNumber || !state.email) {
            return true;
        }

        return false;
    }

    return (
        <div className={registerClass}>
            <div className={formClass}>
                <TextField
                    label="Username"
                    value={state.userName}
                    onChange={(value) => {
                        updateState({
                            ...state,
                            userName: value,
                            hasError: hasError()
                        })
                    }}
                />
                <TextField
                    label="Name"
                    value={state.name}
                    onChange={(value) => {
                        updateState({
                            ...state,
                            name: value,
                            hasError: hasError()
                        })
                    }}
                />
                <TextField
                    label="Email"
                    value={state.email}
                    onChange={(value) => {
                        updateState({
                            ...state,
                            email: value,
                            hasError: hasError()
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
                            password: value,
                            hasError: hasError()
                        })
                    }} />
                <TextField
                    label="Confirm Password"
                    value={state.confirmedPassword}
                    type="password"
                    onChange={(value) => {
                        updateState({
                            ...state,
                            confirmedPassword: value,
                            hasError: hasError()
                        })
                    }} />
                <TextField
                    label="Street Name"
                    value={state.streetName}
                    onChange={(value) => {
                        updateState({
                            ...state,
                            streetName: value,
                            hasError: hasError()
                        })
                    }} />
                <TextField
                    label="House Number"
                    value={state.houseNumber}
                    onChange={(value) => {
                        updateState({
                            ...state,
                            houseNumber: value,
                            hasError: hasError()
                        })
                    }} />
                <TextField
                    label="Apartment Number"
                    value={state.apartmentNumber}
                    onChange={(value) => {
                        updateState({
                            ...state,
                            apartmentNumber: value,
                            hasError: hasError()
                        })
                    }} />
                <div className={buttonsClass}>
                    <Button label="Register"
                        onClick={() => handleRegister(state)} />
                </div>
                {state.hasError && <div style={{ color: "red" }}>Check fields. All are mandatory!</div>}
            </div>
        </div>
    );
}