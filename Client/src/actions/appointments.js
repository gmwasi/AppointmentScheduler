import axios from "axios";
import { url } from "../api";
import { toast } from "react-toastify";
import * as ACTION_TYPES from "./types";

export const fetchAllAppointments = (onSuccess, onError) => (dispatch) => {
  axios
    .get(`${url}appointments`)
    .then((response) => {
      dispatch({
        type: ACTION_TYPES.APPOINTMENTS_FETCH_ALL,
        payload: response.data,
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
    });
};

export const fetchAppointmentsByChild = (childId, onSuccess, onError) => (dispatch) => {
  axios
    .get(`${url}appointments/child/${childId}`)
    .then((response) => {
      dispatch({
        type: ACTION_TYPES.APPOINTMENTS_FETCH_BY_CHILD,
        payload: response.data,
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
    });
};

export const getAppointmentSchedule = (dob, onSuccess, onError) => (
  dispatch,
) => {
  axios
    .get(`${url}appointments/schedule/${dob}`)
    .then((response) => {
      dispatch({
        type: ACTION_TYPES.APPOINTMENTS_GET_SCHEDULE,
        payload: response.data,
      });
      toast.success("Appointments Loaded!");
      if (onSuccess) {
        onSuccess();
      }
    })
    .then(() => {
      if (onSuccess) {
        onSuccess();
      }
    })
    .catch((error) => {
      if (onError) {
        onError();
        toast.error("Something went wrong loading appointments");
      }
    });
};

export const saveAppointments = (data, onSuccess, onError) => (dispatch) => {
  axios
    .post(`${url}appointments/`, data)
    .then((response) => {
      dispatch({
        type: ACTION_TYPES.APPOINTMENTS_CREATE,
        payload: response.data,
      });
      onSuccess && onSuccess();
      toast.success("Appointments Created Successfully!");
    })
    .catch((error) => {
      dispatch({
        type: ACTION_TYPES.APPOINTMENTS_ERROR,
        payload: "Something went wrong",
      });
      onError();
      if (
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

export const updateAppointmentDate = (id, date, onSuccess, onError) => (
  dispatch,
) => {
  axios
    .put(`${url}appointments/date/${id}/${date}`)
    .then((response) => {
      dispatch({
        type: ACTION_TYPES.APPOINTMENTS_UPDATE_DATE,
        payload: response.data,
      });
      toast.success("Appointment Date updated Successfully");
      if (onSuccess) {
        onSuccess();
      }
    })
    .catch((error) => {
      if (onError) {
        onError();
        toast.error("Something went wrong updating");
      }
    });
};

export const updateAppointmentStatus = (id, status, onSuccess, onError) => (
  dispatch,
) => {
  axios
    .put(`${url}appointments/date/${id}/${status}`)
    .then((response) => {
      dispatch({
        type: ACTION_TYPES.APPOINTMENTS_UPDATE_STATUS,
        payload: response.data,
      });
      toast.success("Appointment Status updated Successfully");
      if (onSuccess) {
        onSuccess();
      }
    })
    .catch((error) => {
      if (onError) {
        onError();
        toast.error("Something went wrong updating");
      }
    });
};
