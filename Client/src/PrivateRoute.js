
import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import { authentication } from './_services/authentication';

export const PrivateRoute = ({ component: Component, roles, ...rest }) => (
    <Route {...rest} render={props => {
        if (!localStorage.getItem('currentUser')) {
            // not logged in so redirect to login page with the return url
            return <Redirect to={{ pathname: '/login', state: { from: props.location } }} />
        }

        // check if route is restricted by role
        if (roles && roles.indexOf(authentication.currentRole) === -1) {
            // role not authorised so redirect to home page
            return <Redirect to={{ pathname: '/'}} />
        }

        // authorised so return component
        return <Component {...props} />
    }} />
)