import { getAppConfig, Config } from "../app.config";
import axios from "axios";
import { IUserWithAddress } from "../models/User";

export interface User {
    id?: number;
    address?: string;
    avatar?: string;
    name: string;
    mail: string;
    role: string;
}

type  Listener = (u: IUserWithAddress) => void

export class LoginService {
    public user?: IUserWithAddress;
    private _listeners: Listener[] = [];

    public async login(
        userName: string,
        password: string
    ): Promise<IUserWithAddress | undefined> {
        const appConfig: Config = getAppConfig();
        const url = `${appConfig.apiUrl}/auth/login`;

        try {
            const request = await axios.post(url, {
                userName,
                password
            });

            this.user = request.data;

            if (this.user) {
                sessionStorage.setItem("user", JSON.stringify(this.user));
            }

            this._listeners.forEach(l => this.user && l(this.user));
        } catch (err) {
            return Promise.resolve(undefined);
        }

        return Promise.resolve(this.user);
    }

    public tryRestorePayload() {
        const payload = sessionStorage.getItem("user");
        this.user = payload && JSON.parse(payload);
        return this.user;
    }

    public async register(newUser: IUserWithAddress) {
        const appConfig: Config = getAppConfig();
        const url = `${appConfig.apiUrl}/auth/login/register`;

        try {
            this.user = await axios.post(url, newUser);

            if (this.user) {
                sessionStorage.setItem("user", JSON.stringify(this.user));
            }
        } catch (err) {
            return Promise.resolve(undefined);
        }

        return Promise.resolve(this.user);
    }

    public signOut() {
        this.user = undefined;
        this._listeners.forEach(l => l(this.user!));
        sessionStorage.clear();
    }

    public observeUserChange(observer: Listener) {
        this._listeners.push(observer);
    }
}

export const loginService = new LoginService();
