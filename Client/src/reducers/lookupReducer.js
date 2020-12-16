import * as ACTION_TYPES from "../actions/types";

const initialState = {
  appointmentStatuses: [],
  counties: [],
  facilityLevels: [],
  genders: [],
  maritalStatuses: [],
  relationships: [],
  roles: [],
  error: {},
};

const lookupReducer = (state = initialState, action) => {
  switch (action.type) {
    case ACTION_TYPES.LOOKUP_APPOINTMENT_STATUS:
      return { ...state, appointmentStatuses: [...action.payload] };

    case ACTION_TYPES.LOOKUP_COUNTY:
      return { ...state, counties: [...action.payload] };

    case ACTION_TYPES.LOOKUP_FACILITY_LEVEL:
      return { ...state, facilityLevels: action.payload };

    case ACTION_TYPES.LOOKUP_GENDER:
      return { ...state, genders: [...action.payload] };

    case ACTION_TYPES.LOOKUP_MARITAL_STATUS:
      return { ...state, maritalStatuses: [...action.payload] };

    case ACTION_TYPES.LOOKUP_RELATIONSHIP:
      return { ...state, relationships: [...action.payload]};

    case ACTION_TYPES.LOOKUP_ROLE:
      return { ...state, roles: [...action.payload] };

    case ACTION_TYPES.LOOKUP_ERROR:
      return { ...state, error: action.payload };

    default:
      return state;
  }
};

export default lookupReducer;
