import * as ActionTypes from '../actiontypes'
import { CALL_API, Schemas } from '../../middleware/api'

function fetchArea(areaId) {
    return {
        [CALL_API]: {
            types: [ ActionTypes.AREA_REQUEST_DELETE, ActionTypes.AREA_RECEIVED_DELETED, ActionTypes.FAILED_AREA_DELETE ],
            endpoint: `/api/Areas/${areaId}`,
            schema: Schemas.AREA_ARRAY,
            ajaxMethod: 'DELETE',
        }
    }
}

// Fetches the user's areas.
// Relies on Redux Thunk middleware.
export function deleteArea(areaId) {
    return (dispatch, getState) => {
        return dispatch(fetchArea(areaId))
    }
}
