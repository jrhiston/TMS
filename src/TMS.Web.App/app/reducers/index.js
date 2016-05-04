import { entities } from './entities'
import login from './login/login'
import dataLoader from './dataLoader'
import { routerReducer as routing } from 'react-router-redux'
import { combineReducers } from 'redux'
import * as ActionTypes from '../actions/actiontypes'
import { pages } from './pages'

// Updates error message to notify about the failed fetches.
const errorMessage = (state = null, action) => {
    const { type, error } = action

    if (type === ActionTypes.RESET_ERROR_MESSAGE) {
        return null
    } else if (error) {
        return action.error
    }

    return state
}

const rootReducer = combineReducers({
    login,
    pages,
    entities,
    errorMessage,
    routing
})

export default rootReducer
