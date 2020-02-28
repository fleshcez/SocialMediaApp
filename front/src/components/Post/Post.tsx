import React from "react";
import { IPost } from "../../models/Post";
import styles from "./Post.module.scss";
import moment from 'moment';
import { IUser } from "../../models/User";

const {
    post: postClass,
    identity: identityClass,
    title: titleClass,
    user: userClass,
    date: dateClass,
    content: contentClass,
    delete: deleteClass
} = styles;

interface IPostProps {
    post: IPost;
    user: IUser;
    onDelete: (psot: IPost) => void;
}

export function Post(props: IPostProps) {
    const { title, userName, userUserName, textContent, timeStamp } = props.post;
    const formattedTime = moment(timeStamp).fromNow();


    return (
        <div className={postClass}>
            {props.user?.userName === userUserName &&
                <button
                    className={deleteClass}
                    onClick={() => props.onDelete(props.post)}>x</button>}
            <div className={identityClass}>
                <div className={userClass}>{userName}</div>
                <div className={dateClass}>{formattedTime}</div>
            </div>
            <div className={titleClass}>
                {title}
            </div>
            <p className={contentClass}>
                {textContent}
            </p>
        </div>
    );
}