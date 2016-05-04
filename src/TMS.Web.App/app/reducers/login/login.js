import { REQUEST_LOGIN, RECEIVE_LOGIN } from '../../actions/actiontypes'

function login(state = {
    username: null,
    loggedIn: false,
    receivedAt: null
}, action) {
    switch (action.type){
    case REQUEST_LOGIN:
        return Object.assign({}, state, {
            username: null,
            loggedIn: false,
            receivedAt: null
        })
    case RECEIVE_LOGIN:
        return Object.assign({}, state, {
            username: action.username,
            loggedIn: true,
            receivedAt: action.receivedAt
        })
    default:
        return state
    }
}

export default login

