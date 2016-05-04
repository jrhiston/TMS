import { AREA_REQUEST_SAVE, AREA_SAVE_COMPLETED } from './areaActionTypes'
import { post } from '../../middleware/api'
import { MIME_TYPE_JSON } from '../../middleware/mimeTypes'

export const requestSaveArea = () => {
    return {
        type: AREA_REQUEST_SAVE
    }
}

export const areaSaveCompleted = () => {
    return {
        type: AREA_SAVE_COMPLETED
    }
}

export function saveArea(newArea, cb){
    return function (dispatch){
        // Tell UI we are starting a request for user areas.
        dispatch(requestSaveArea())

        post('/api/Areas', MIME_TYPE_JSON, JSON.stringify(newArea), function (xhr) {
            if (xhr.status === 200){
                dispatch(areaSaveCompleted())

                if (typeof cb !== 'undefined' && cb !== null) {
                    cb();
                }
            }
        })
    }
}
