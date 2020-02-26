import { IPost } from "../models/Post";

import { loginService } from "./login.service";
import { getAppConfig } from "../app.config";
import Axios from "axios";
import { IUser } from "../models/User";

export class PostService {
    public async getUserPosts(): Promise<IPost[]> {
        const user = loginService.tryRestorePayload();
        const appConfig = getAppConfig();
        const url = `${appConfig.apiUrl}/posts/${user?.userName}`;

        try {
            const request = await Axios.get(url);
            return request.data;
        }
        catch(err) {
            return Promise.resolve([]);
        }
    }

    public async submitPost(post: IPost, user: IUser): Promise<void> {
        const appConfig = getAppConfig();
        const url = `${appConfig.apiUrl}/posts`;

        try {
            const request = await Axios.post(url, {
                ...post,
                userName: user.name,
                userUserName: user.userName
            });
        }
        catch(err) {
            
        }
    }
}

export const postService = new PostService();