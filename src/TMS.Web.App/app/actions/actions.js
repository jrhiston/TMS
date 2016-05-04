import {ADD_ACTIVITY, ADD_AREA, REQUEST_USER_AREAS, RECEIVE_USER_AREAS} from './actiontypes'
import { get, MIME_TYPE_JSON } from '../middleware/api'

let nextActivityId = 0
export const addActivity = (title, description) => {
    return {
        type: ADD_ACTIVITY,
        id: nextActivityId++,
        title,
        description
    }
}

let nextAreaId = 0
export const addArea = (name, description) => {
    return {
        type: ADD_AREA,
        id: nextAreaId++,
        name,
        description
    }
}

function requestUserAreas() {
    return {
        type: REQUEST_USER_AREAS
    }
}

function receiveUserAreas(areas){
    return {
        type: RECEIVE_USER_AREAS,
        areas,
        receivedAt: Date.now()
    }
}

export function fetchUserAreas(){
    return function (dispatch){
        // Tell UI we are starting a request for user areas.
        dispatch(requestUserAreas())

        get('/api/Areas', MIME_TYPE_JSON, function (xhr) {
            if (xhr.status === 200){
                let parsedAreas = JSON.parse(xhr.responseText)
                let areas = convertReceivedUserAreas(parsedAreas)

                dispatch(receiveUserAreas(areas))
            }
        })
    }
}

function convertReceivedUserAreas(areas){
    return areas.map(area => {
        return {
            areaId: area.AreaId,
            name: area.Name,
            description: area.Description
        }
    })
}
