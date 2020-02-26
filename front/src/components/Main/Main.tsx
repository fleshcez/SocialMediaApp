import React, { useEffect, useState } from "react";

import styles from "./Main.module.scss";
import { Post } from "../Post/Post";
import { IPost } from "../../models/Post";
import { NewPost } from "../Post/NewPost";
import { postService } from "../../services/post.service";
import { IUser } from "../../models/User";
import { INewPost } from "../../models/NewPost";
import moment from 'moment';

const { main: mainClass } = styles;

interface IMainState {
    posts: IPost[];
}

interface IMainProps {
    user: IUser;
}

export function Main(props: IMainProps) {
    const [state, updateState] = useState<IMainState>({
        posts: []
    });

    useEffect(() => {
        postService.getUserPosts().then(newPosts => {
            updateState({ posts: newPosts })
        });
    }, []);
    var x= moment;
    var handleSubmit = async (newPost: INewPost) => {
        await postService.submitPost({
            id: 0,
            title: newPost.title,
            textContent: newPost.text,
            userName: props.user?.name,
            userUserName: props.user?.userName,
            timeStamp: String(moment().format("YYYY-MM-DD[T]HH:mm:ss"))
        }, props.user);

        const updatedPosts = await postService.getUserPosts();
        updateState({posts: updatedPosts});
    }

    return (
        <div className={mainClass}>
            <NewPost onSubmit={(p) => handleSubmit(p)} />
            {
                state.posts.map(p => {
                    return (<Post key={p.id} post={p}/>)
                })
            }
        </div>
    );
}