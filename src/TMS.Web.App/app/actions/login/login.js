import { REQUEST_LOGIN, RECEIVE_LOGIN, FAILED_LOGIN } from '../actiontypes'
import { login as apiLogin }  from '../../middleware/api'
import { browserHistory } from 'react-router'

export function login(username, password, redirectUrl = '') {
    return function (dispatch) {
        const OK = 200
        
        // Tell UI we are starting a request for user areas.
        dispatch(requestLogin())
        
        apiLogin(username, password, function (xhr) {
            if (xhr.status === OK) {
                dispatch(receiveLogin(username))

                redirectToUrl(redirectUrl)
            } else {
                dispatch(failedLogin(username))
            }
        })
    }
}

function requestLogin() {
    return {
        type: REQUEST_LOGIN
    }
}

export function receiveLogin(username) {
    return {
        type: RECEIVE_LOGIN,
        username,
        receivedAt: Date.now()
    }
}

function failedLogin(username) {
    return {
        type: FAILED_LOGIN,
        username
    }
}

function redirectToUrl(redirectUrl) {
    let url = '/TMS'
    
    if (typeof redirectUrl !== 'undefined' && redirectUrl !== null && redirectUrl !== '') {
        url = redirectUrl
    }
    
    browserHistory.push(url)
}