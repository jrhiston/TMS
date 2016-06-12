import { browserHistory } from 'react-router'
import * as MimeTypes from './mimeTypes'
import 'isomorphic-fetch'
import { normalize, Schema, arrayOf } from 'normalizr'
import { camelizeKeys } from 'humps'

const OK = 200
const TOKEN_ENDPOINT = '/Token'

export function login(username, password, callback){
    let loginData = `grant_type=password&client_id=Test&username=${username}&password=${password}`

    postWithoutAuthCheck(TOKEN_ENDPOINT,
    MimeTypes.MIME_TYPE_URLENCODED,
    loginData,
    function(xhr){
        if (xhr.status === OK) {
            let response = JSON.parse(xhr.responseText)
            sessionStorage.setItem('AuthToken', JSON.stringify(response))
        }

        callback(xhr)
    })
}

export function getToken() {
    var authorizationUrl = 'http://authserv.local/connect/authorize'
    var client_id = 'tmsclient_oauth'
    var redirect_uri = 'http://www.tms.local/TMS'
    var response_type = 'token'
    var scope = 'tmsapi'
    var state = Date.now() + "" + Math.random()

    localStorage["state"] = state;

    var url =
        authorizationUrl + "?" +
        "client_id=" + encodeURI(client_id) + "&" +
        "redirect_uri=" + encodeURI(redirect_uri) + "&" +
        "response_type=" + encodeURI(response_type) + "&" +
        "scope=" + encodeURI(scope) + "&" +
        "state=" + encodeURI(state);
    window.location = url;
}

export function userHasValidAuthToken(){
    let authToken = sessionStorage.getItem('AuthToken')

    if (typeof authToken === 'undefined' || authToken === null){
        return null
    } else {
        var parsedAuthToken = JSON.parse(authToken)
        var result = Date.parse(parsedAuthToken['.expires']) > Date.now()

        if (!result) {
            sessionStorage.removeItem('AuthToken')
            return null
        }

        return parsedAuthToken
    }
}

export function getJSON(url, callback) {
    get(url, MIME_TYPE_JSON, callback)
}

export function get(url, mimeType, callback){
    var result = userHasValidAuthToken()
    if (typeof result === 'undefined' || result === null) {
        browserHistory.push('/TMS/Login')
        return
    }

    let xhr = new XMLHttpRequest()
    xhr.open('GET', encodeURI(url))
    xhr.setRequestHeader('Content-Type', mimeType)
    xhr.setRequestHeader('Authorization', 'Bearer ' + result.access_token)
    xhr.onload = function() {
        if (xhr.status === 401) {
            browserHistory.push('/TMS/Login')
        } else {
            callback(xhr)
        }
    }
    xhr.send()
}

export function post(url, mimeType, data, callback) {
    var result = userHasValidAuthToken()
    if (typeof result === 'undefined' || result === null) {
        browserHistory.push('/TMS/Login')
        return
    }

    let xhr = new XMLHttpRequest()
    xhr.open('POST', encodeURI(url))
    xhr.setRequestHeader('Content-Type', mimeType)
    xhr.setRequestHeader('Authorization', 'Bearer ' + result.access_token)
    xhr.onload = function () {
        if (xhr.status === 401) {
            browserHistory.push('/TMS/Login')
        } else {
            callback(xhr)
        }
    }
    xhr.send(data)
}

export function remove(url, mimeType, data, callback) {
    var result = userHasValidAuthToken();
    if (typeof result === 'undefined' || result === null) {
        browserHistory.push('/TMS/Login')
        return
    }

    let xhr = new XMLHttpRequest();
    xhr.open('DELETE', encodeURI(url))
    xhr.setRequestHeader('Content-Type', mimeType)
    xhr.setRequestHeader('Authorization', 'Bearer ' + result.access_token)
    xhr.onload = function () {
        if (xhr.status === 401) {
            browserHistory.push('/TMS/Login')
        } else {
            callback(xhr)
        }
    }
    xhr.send(data)
}

function postWithoutAuthCheck(url, mimeType, data, callback){
    let xhr = new XMLHttpRequest()
    xhr.open('POST', encodeURI(url))
    xhr.setRequestHeader('Content-Type', mimeType)
    xhr.onload = function () {
        callback(xhr)
    }
    xhr.send(data)
}

const areaSchema = new Schema('areas', {
    idAttribute: 'areaId'
});

const activitySchema = new Schema('activities', {
    idAttribute: 'activityId'
})

activitySchema.define({
    owner: areaSchema
})

export const Schemas = {
    AREA: areaSchema,
    AREA_ARRAY: arrayOf(areaSchema),
    ACTIVITIES: activitySchema,
    ACTIVITIES_ARRAY: arrayOf(activitySchema)
}

// Fetches an API response and normalizes the result JSON according to schema.
// This makes every API response have the same shape, regardless of how nested it was.
function callApi(endpoint, schema, ajaxMethod) {
    if (typeof ajaxMethod !== 'string') {
        throw new Error('Please provide a method verb to call the API e.g. GET, DELETE, POST')
    }

    var result = userHasValidAuthToken()
    if (typeof result === 'undefined' || result === null) {
        browserHistory.push('/TMS/Login')
        return
    }

    const fullUrl = endpoint

    var apiCall = fetch(fullUrl, {
        method: ajaxMethod,
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + result.access_token
        }
    })

    if (ajaxMethod !== 'DELETE'){
        return apiCall.then(response => {
            return response.json().then(json => ({ json, response }))
        }).then(({ json, response }) => {
              if (!response.ok) {
                  return Promise.reject(json)
              }

              const camelizedJson = camelizeKeys(json)

              let normalised = normalize(camelizedJson, schema)

              return Object.assign({},
                  normalised
              )
        })
    }

    return apiCall
}

export const CALL_API = Symbol('Call API')

export default store => next => action => {
    const callAPI = action[CALL_API]
    if (typeof callAPI === 'undefined') {
        return next(action)
    }

    let { endpoint } = callAPI
    const { schema, types, ajaxMethod } = callAPI

    if (typeof endpoint === 'function') {
        endpoint = endpoint(store.getState())
    }

    if (typeof endpoint !== 'string'){
        throw new Error('Sepcify a string endpoint URL.')
    }

    if (typeof ajaxMethod !== 'string') {
        throw new Error('Please specify an ajax method when calling the API')
    }

    if (!schema) {
        throw new Error('Specify one of the exported Schemas.')
    }

    if (!Array.isArray(types) || types.length !== 3) {
        throw new Error('Expected an array of three action types')
    }

    if (!types.every(type => typeof type === 'string')) {
        throw new Error('Expected action types to be strings.')
    }

    function actionWith(data) {
        const finalAction = Object.assign({}, action, data)
        delete finalAction[CALL_API]
        return finalAction
    }

    const [ requestType, successType, failureType ] = types
    next(actionWith({ type: requestType }))

    let task = callApi(endpoint, schema, ajaxMethod)
    if (task) {
        task.then(
            response => next(actionWith({
                response,
                type: successType
            })),
            error => next(actionWith({
                type: failureType,
                error: error.message || 'Something bad happened'
            }))
        )
    }
}
