import { CALL_API, Schemas } from '../../middleware/api'
import { REQUEST_USER_AREAS, RECEIVE_USER_AREAS, FAILED_USER_AREAS } from '../actiontypes'

function fetchUserAreas() {
    return {
        areas: 'areas',
        [CALL_API]: {
            types: [ REQUEST_USER_AREAS, RECEIVE_USER_AREAS, FAILED_USER_AREAS ],
            endpoint: '/api/Areas/',
            schema: Schemas.AREA_ARRAY,
            ajaxMethod: 'GET'
        }
    }
}

// Fetches the user's areas.
// Relies on Redux Thunk middleware.
export function listUserAreas() {
    return (dispatch, getState) => {
        return dispatch(fetchUserAreas())
    }
}
