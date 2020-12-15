import { combineReducers } from 'redux'
import appointmentReducer from './appointmentReducer'
import lookupReducer from './lookupReducer'
import childReducer from './childReducer'

export default combineReducers({
    appointments: appointmentReducer,
    lookups: lookupReducer,
    children: childReducer,
  })