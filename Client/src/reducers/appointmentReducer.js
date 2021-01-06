import * as ACTION_TYPES from "../actions/types";

const initialState = {
  appointment: {},
  list: [],
  schedule: [],
  child: [],
  error: {},
};

const appointmentReducer = (state = initialState, action) => {
  switch (action.type) {
    case ACTION_TYPES.APPOINTMENTS_FETCH_ALL:
      return { ...state, list: [...action.payload] };

    case ACTION_TYPES.APPOINTMENTS_GET_SCHEDULE:
      return { ...state, schedule: [...action.payload] };

    case ACTION_TYPES.APPOINTMENTS_FETCH_BY_CHILD:
      return { ...state, child: [...action.payload] };

    case ACTION_TYPES.APPOINTMENTS_FETCH_BY_ID:
      return { ...state, appointment: action.payload };

    case ACTION_TYPES.APPOINTMENTS_ERROR:
      return { ...state, error: action.payload };

    default:
      return state;
  }
};

export default appointmentReducer;
