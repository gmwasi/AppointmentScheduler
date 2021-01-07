import { BehaviorSubject } from 'rxjs';
import jwt_decode from "jwt-decode";
import { url } from "../api";
import { handleResponse } from '../_helpers';
import store from '../store';
import * as ACTION_TYPES from "../actions/types";

const { dispatch } = store;
const currentUserSubject = new BehaviorSubject(JSON.parse(localStorage.getItem('currentUser')));

const currentRole = JSON.parse(localStorage.getItem('currentUser')) ? jwt_decode(JSON.parse(localStorage.getItem('currentUser')).token)['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] : '';
const currentUsername =  JSON.parse(localStorage.getItem('currentUser')) ? jwt_decode(JSON.parse(localStorage.getItem('currentUser')).token)['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'] : '';
export const authentication = {
    login,
    logout,
    currentUser: currentUserSubject.asObservable(),
    get currentUserValue () { return currentUserSubject.value },
    currentRole: currentRole,
    currentUsername: currentUsername,
};

function login(username, password, remember) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, password, remember })
    };

    return fetch(`${url}authentication/login`, requestOptions)
        .then(handleResponse)
        .then(user => {
            dispatch({
                type: ACTION_TYPES.AUTHENTICATION,
                payload: "Authenticated"
            });
            // store user details and jwt token in local storage to keep user logged in between page refreshes
            localStorage.setItem('currentUser', JSON.stringify(user));
            currentUserSubject.next(user);
            return user;
        });
}

function logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    currentUserSubject.next(null);
}