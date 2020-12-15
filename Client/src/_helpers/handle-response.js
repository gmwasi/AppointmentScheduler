import store from '../store';
import * as ACTION_TYPES from "../actions/types";

const { dispatch } = store;

export function handleResponse(response) {
    return response.text().then(text => {
        const data = text && JSON.parse(text);
        if (!response.ok) {
            dispatch({
                type: ACTION_TYPES.AUTHENTICATION_ERROR,
                payload: "Error Authenticating"
            });
            const error = (data && data.message) || response.statusText;
            return Promise.reject(error);
        }
        return data;
    });
}