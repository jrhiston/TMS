import dataLoader from './dataLoader'
import * as ActionTypes from '../actions/actiontypes'
import { combineReducers } from 'redux'

export const pages = combineReducers({
    areasection: dataLoader({
        types: [
            ActionTypes.REQUEST_USER_AREAS,
            ActionTypes.RECEIVE_USER_AREAS,
            ActionTypes.FAILED_USER_AREAS
        ],
        invalidateTypes: [
            ActionTypes.AREA_RECEIVED_DELETED
        ]
    }),
    areaview: dataLoader({
        types: [
            ActionTypes.AREA_REQUEST_GET,
            ActionTypes.AREA_RECEIVED_GET,
            ActionTypes.AREA_RECEIVE_FAILED
        ],
        invalidateTypes: []
    })
})
