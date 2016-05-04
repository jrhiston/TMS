import { AREA_REQUEST_EDIT, AREA_RECEIVED_EDIT, FAILED_AREA_EDIT } from '../actiontypes'
import { AreasAddress } from '../../middleware/ajaxAddresses'
import { MIME_TYPE_JSON } from '../../middleware/mimeTypes'
import xhrToAreaConverter from '../../converters/areas/areaConverter'
import { browserHistory } from 'react-router'
import * as api from '../../middleware/api'
import * as areaRouting from '../../routing/areas'
import { CALL_API, Schemas } from '../../middleware/api'

function fetchArea(areaId) {
    return {
        [CALL_API]: {
            types: [ AREA_REQUEST_EDIT, AREA_RECEIVED_EDIT, FAILED_AREA_EDIT ],
            endpoint: `/api/Areas/${areaId}`,
            schema: Schemas.AREA_ARRAY,
            ajaxMethod: 'GET'
        }
    }
}

// Fetches the user's areas.
// Relies on Redux Thunk middleware.
export function editArea(areaId) {
    return (dispatch, getState) => {
        return dispatch(fetchArea(areaId))
    }
}
