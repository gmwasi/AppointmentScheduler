import { createStore, compose, applyMiddleware } from 'redux'
import thunk from 'redux-thunk'
import rootReducer from './reducers'

const middleware = [thunk]

const initialState = {}

const store = window.__REDUX_DEVTOOLS_EXTENSION__
  ? createStore(
      rootReducer,
      initialState,
      compose(
        applyMiddleware(...middleware),
        window.__REDUX_DEVTOOLS_EXTENSION__()
      )
    )
  : createStore(
      rootReducer,
      initialState,
      compose(applyMiddleware(...middleware))
    )

export default store
