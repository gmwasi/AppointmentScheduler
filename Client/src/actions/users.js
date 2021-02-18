import axios from "axios";
import { url } from "../api";
import { toast } from "react-toastify";
import * as ACTION_TYPES from "./types";

export const fetchAll = (onSuccess, onError) => (dispatch) => {
  axios
    .get(`${url}users`)
    .then((response) => {
      dispatch({
        type: ACTION_TYPES.GET_USERS,
        payload: response.data,
      });
      if (onSuccess) {
        onSuccess();
      }
    })
    .catch((error) => {
      if (onError) {
        onError();
        toast.error("Something went wrong fetching users");
      }
    });
};

export const getById = (id, onSuccess, onError) => (dispatch) => {
  axios
    .get(`${url}users/${id}`)
    .then((response) => {
      dispatch({
        type: ACTION_TYPES.GET_USER_BY_ID,
        payload: response.data,
      });
      if (onSuccess) {
        onSuccess();
      }
    })
    .catch((error) => {
      if (onError) {
        onError();
        toast.error("Something went wrong fetching user");
      }
    });
};

export const register = (data, onSuccess, onError) => (dispatch) => {
    axios
      .post(`${url}authentication/register`, data)
      .then((response) => {
        dispatch({
          type: ACTION_TYPES.REGISTER,
          payload: response.data,
        });
        onSuccess && onSuccess();
        toast.success("User Registered Successfully!");
      })
      .catch((error) => {
        dispatch({
          type: ACTION_TYPES.USERS_ERROR,
          payload: "Something went wrong",
        });
        onError();
        if (
          error.response === undefined
        ) {
          toast.error("Something went wrong");
        } else {
          toast.error(error);
          //toast.error(error.response.data.apierror.message);
        }
      });
  };

