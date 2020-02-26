import { createBrowserHistory } from "history";


export const appHistory = createBrowserHistory();

export class NavigationService {
    public go(url: string) {
        appHistory.push(url)
    }
}

export const navigationService = new NavigationService();
