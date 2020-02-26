import React from "react";
import { IPost } from "../../models/Post";
import styles from "./Post.module.scss";
import moment from 'moment';

const {
    post: postClass,
    identity: identityClass,
    title: titleClass,
    user: userClass,
    date: dateClass,
    content: contentClass
} = styles;

export function Post(props: {post :IPost}) {
    const { title, userName, userUserName, textContent, timeStamp } = props.post;
    const formattedTime = moment(timeStamp).fromNow();

    return (
        <div className={postClass}>
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