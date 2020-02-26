export interface Config {
    apiUrl: string;
}

const env = {
    dev: {
        apiUrl: "https://localhost:44329"
    }
};

export function getAppConfig(): Config {
    return env.dev;
}