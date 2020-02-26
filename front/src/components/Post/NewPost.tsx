import React, { useState } from "react";
import styles from "./NewPost.module.scss";
import { Button } from "../Button/Button";
import { INewPost } from "../../models/NewPost";

const { newPost: newPostClass, title: titleClass, content: contentClass } = styles;

interface INewPostState extends INewPost {
}

interface INewPostProps {
    onSubmit: (p: INewPostState) => void;
}

export function NewPost(props: INewPostProps) {
    const [state, setState] = useState<INewPostState>({
        title: "",
        text: ""
    });

    return (
        <div className={newPostClass}>
            <div className={titleClass}>
                <input
                    placeholder="title"
                    value={state.title}
                    onChange={(event) => {
                        setState({ ...state, title: event.target.value })
                    }} />
                <Button
                    label="Post"
                    fontSize="14px"
                    padding="2px 10px"
                    onClick={() => {
                        var s = { ...state };
                        setState({ ...state, title: "", text: "" });
                        props.onSubmit(s);
                    }} />
            </div>
            <div className={contentClass}>
                <textarea
                    value={state.text}
                    placeholder="Type something interesting..."
                    onChange={(event) => {
                        setState({ ...state, text: event.target.value })
                    }} />
            </div>
        </div>
    )
}