import { combineReducers } from 'redux'
import appointmentReducer from './appointmentReducer'
import lookupReducer from './lookupReducer'
import childReducer from './childReducer'
import userReducer from './userReducer'

export default combineReducers({
    appointments: appointmentReducer,
    lookups: lookupReducer,
    children: childReducer,
    users: userReducer,
  })