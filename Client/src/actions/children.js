import axios from "axios";
import { url } from "../api";
import { toast } from "react-toastify";
import * as ACTION_TYPES from "./types";

export const fetchAll = (onSuccess, onError) => (dispatch) => {
  axios
    .get(`${url}child`)
    .then((response) => {
      dispatch({
        type: ACTION_TYPES.CHILD_FETCH_ALL,
        payload: response.data,
      });
      if (onSuccess) {
        onSuccess();
      }
    })
    .catch((error) => {
      if (onError) {
        onError();
        toast.error("Something went wrong fetching children");
      }
    });
};

export const getById = (id, onSuccess, onError) => (dispatch) => {
  axios
    .get(`${url}child/${id}`)
    .then((response) => {
      dispatch({
        type: ACTION_TYPES.CHILD_GET_BY_ID,
        payload: response.data,
      });
      if (onSuccess) {
        onSuccess();
      }
    })
    .catch((error) => {
      if (onError) {
        onError();
        toast.error("Something went wrong fetching child");
      }
    });
};

export const getByEmail = (email, onSuccess, onError) => (dispatch) => {
  axios
    .get(`${url}child/email/${email}`)
    .then((response) => {
      dispatch({
        type: ACTION_TYPES.CHILD_GET_BY_EMAIL,
        payload: response.data,
      });
      if (onSuccess) {
        onSuccess();
      }
      axios
        .get(`${url}appointments/child/${response.data.id}`)
        .then((result) => {
          dispatch({
            type: ACTION_TYPES.APPOINTMENTS_FETCH_BY_CHILD,
            payload: result.data,
          });
          if (onSuccess) {
            onSuccess();
          }
        })
        .catch((error) => {
          if (onError) {
            onError();
            toast.error("Something went wrong loading appointments");
          }
        })
    })
    .catch((error) => {
      if (onError) {
        onError();
        toast.error("Something went wrong fetching child");
      }
    });
};

export const find = (param, onSuccess, onError) => (dispatch) => {
  axios
    .get(`${url}child/${param}`)
    .then((response) => {
      dispatch({
        type: ACTION_TYPES.CHILD_FIND,
        payload: response.data,
      });
      if (onSuccess) {
        onSuccess();
      }
    })
    .catch((error) => {
      if (onError) {
        onError();
        toast.error("Something went wrong fetching child");
      }
    });
};

export const register = (data, onSuccess, onError) => (dispatch) => {
  axios
    .post(`${url}child/register`, data)
    .then((response) => {
      dispatch({
        type: ACTION_TYPES.CHILD_REGISTER,
        payload: response.data,
      });
      onSuccess && onSuccess();
      toast.success("Child Registered Successfully!");
    })
    .catch((error) => {
      dispatch({
        type: ACTION_TYPES.APPOINTMENTS_ERROR,
        payload: "Something went wrong",
      });
      onError();
      if (
        error.response === undefined ||
        error.response.data.apierror.message === null ||
        error.response.data.apierror.message === ""
      ) {
        toast.error("Something went wrong");
      } else {
        toast.error(error);
        //toast.error(error.response.data.apierror.message);
      }
    });
};
