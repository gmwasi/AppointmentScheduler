import * as ACTION_TYPES from "../actions/types";

const initialState = {
  list: [],
  registered: {},
  user: {},
  error: {},
};

const userReducer = (state = initialState, action) => {
  switch (action.type) {
    case ACTION_TYPES.GET_USERS:
      return { ...state, list: [...action.payload] };

    case ACTION_TYPES.GET_USER_BY_ID:
      return { ...state, user: action.payload };

    case ACTION_TYPES.REGISTER:
      return { ...state, registered: action.payload };

    default:
      return state;
  }
};

export default userReducer;
