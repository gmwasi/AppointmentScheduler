import * as ACTION_TYPES from "../actions/types";

const initialState = {
  list: [],
  searchList: [],
  child: {},
  registered: {},
  error: {},
};

const childReducer = (state = initialState, action) => {
  switch (action.type) {
    case ACTION_TYPES.CHILD_FETCH_ALL:
      return { ...state, list: [...action.payload] };

    case ACTION_TYPES.CHILD_FIND:
      return { ...state, searchList: [...action.payload] };

    case ACTION_TYPES.CHILD_GET_BY_ID:
      return { ...state, child: action.payload };

    case ACTION_TYPES.CHILD_REGISTER:
      return { ...state, registered: action.payload };

    case ACTION_TYPES.CHILD_ERROR:
      return { ...state, error: action.payload };

    default:
      return state;
  }
};

export default childReducer;
