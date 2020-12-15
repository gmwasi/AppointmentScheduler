import axios from "axios";
import { authentication } from '../_services/authentication';
import { authHeader } from './auth-header';
import store from '../store';
import * as ACTION_TYPES from "../actions/types";

const { dispatch } = store;

// Add authentication headers to requests
axios.interceptors.request.use(function (config) {
    const authenticationHeader = authHeader();
    if(authenticationHeader) {
        config.headers = authenticationHeader;
    } else {
        console.log('There is not token yet...'); 
    }
    return config;
});

// Check if token is still valid
axios.interceptors.response.use(function (response) {
    return response;
  }, function (error) {
      // TODO: Brian Update 403(Forbiden) once roles is completed 
    if (error.response.status === 401 || error.response.status === 403) {
        // auto logout if 401 Unauthorized or 403 Forbidden response returned from api
        authentication.logout();
        dispatch({
            type: ACTION_TYPES.UNAUTHORISED_ERROR,
            payload: error.response.status
        });
        window.location.reload(true);
    }  
    return Promise.reject(error);
  })