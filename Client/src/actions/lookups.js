import axios from "axios";
import { url } from "../api";

export const lookup = (type, actionType, onSuccess, onError) => (dispatch) => {
  axios
    .get(`${url}lookup/${type}`)
    .then((response) => {
      dispatch({
        type: actionType,
        payload: response.data,
      });
      if (onSuccess) {
        onSuccess();
      }
    })
    .catch((error) => {
      if (onError) {
        onError();
        console.log(error);
      }
    });
};
