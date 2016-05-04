import { ACTIVITY_FILTER_REQUEST, ACTIVITY_FILTER_RECEIVE } from './activityActionTypes'
import { post } from '../../middleware/api'
import { MIME_TYPE_JSON } from '../../middleware/mimeTypes'
import { ActivitiesAddress } from '../../middleware/ajaxAddresses'
import { xhrToActivityConverter } from '../../converters/activities/activityConverter'

export const requestActivityFilter = () => {
    return {
        type: ACTIVITY_FILTER_REQUEST
    }
}

export const receiveActivities = activities => {
    return {
        type: ACTIVITY_FILTER_RECEIVE,
        activities: activities
    }
}

export function filterActivities(newArea, cb) {
    return function (dispatch, getState) {
        dispatch(requestActivityFilter())

        post(ActivitiesAddress, MIME_TYPE_JSON, JSON.stringify(), function(xhr)) {
            if (xhr.status === 200) {
                let result = JSON.parse(xhr.responseText)
                let activities = result.map(xhrToActivityConverter)

                dispatch(receiveActivities(activities))
            }
        })
    }
}
