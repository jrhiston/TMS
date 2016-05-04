import { AREA_REQUEST_GET, AREA_RECEIVED_GET, AREA_RECEIVE_FAILED } from './areaActionTypes'
import { AreasAddress } from '../../middleware/ajaxAddresses'
import xhrToAreaConverter from '../../converters/areas/areaConverter'
import * as api from '../../middleware/api'
import { CALL_API, Schemas } from '../../middleware/api'

function fetchArea(areaId) {
    return {
        areaId: areaId,
        [CALL_API]: {
            types: [ AREA_REQUEST_GET, AREA_RECEIVED_GET, AREA_RECEIVE_FAILED ],
            endpoint: `/api/Areas/${areaId}`,
            schema: Schemas.AREA_ARRAY,
            ajaxMethod: 'GET'
        }
    }
}

// Fetches the user's areas.
// Relies on Redux Thunk middleware.
export function getArea(areaId) {
    return (dispatch, getState) => {
        return dispatch(fetchArea(areaId))
    }
}

//
// const requestGetArea = (areaId) => {
//     return {
//         type: AREA_REQUEST_GET,
//         id: areaId
//     }
// }
//
// const receivedGetArea = (area) => {
//     return {
//         type: AREA_RECEIVED_GET,
//         area: area
//     }
// }
//
// export function getArea(areaId) {
//     return function (dispatch) {
//         // Tell UI we are starting a request.
//         dispatch(requestGetArea(areaId))
//
//         api.getJSON(AreasAddress + areaId, function (xhr) {
//             if (xhr.status === 200) {
//                 let area = xhrToAreaConverter(xhr)
//
//                 dispatch(receivedGetArea(area))
//             }
//         })
//     }
// }
