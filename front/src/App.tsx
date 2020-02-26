import React, { useEffect, useState } from 'react';

import './App.scss';
import style from './App.module.scss';
import { loginService } from './services/login.service';
import { Router, Switch, Route, Link, Redirect } from 'react-router-dom';
import { appHistory, navigationService } from './services/navigation.service';
import { Login } from './components/Login/Login';
import { Register } from './components/Register/Register';
import { Main } from './components/Main/Main';
import { Header } from './components/Header/Header';
import { IUserWithAddress } from './models/User';
import { GuarderRoute } from './components/GuardedRoute';

var { app: appClass,
  content: contentClass } = style;

export function useAuthorization() {
  const [activeUser, setActiveUser] = useState<IUserWithAddress>();

  useEffect(() => {
    const activeUser = loginService.tryRestorePayload();
    setActiveUser({...activeUser} as any);
    loginService.observeUserChange(setActiveUser);
  }, []);

  return {
    isAuthorized: !!activeUser,
    user: activeUser
  }
}

export function App() {
  const { isAuthorized, user } = useAuthorization();

  const handleSignOut = () => {
    loginService.signOut();
    navigationService.go("/login");
  }

  return (
    <div className={appClass}>
      <Header user={user!} onClick={handleSignOut} />
      <div className={contentClass}>
        <Router history={appHistory}>
          <Switch>
            <Route path={"/register"}>
              <Register></Register>
            </Route>
            <Route path={"/login"}>
              <GuarderRoute
                debugString={`path: '/login',user`}
                canNavigate={() => !isAuthorized}
                onSuccess={() => <Login />}
                onFail={() => <Redirect to={"/"} />}
              />
            </Route>
            <Route path={"/"}>
              <GuarderRoute
                debugString={`path: '/',user:${user}`}
                canNavigate={() => isAuthorized}
                onSuccess={() => <Main user={user!} />}
                onFail={() => <Redirect to={"/login"} />}
              />
            </Route>
          </Switch>
        </Router>
      </div>
    </div >
  )
}

