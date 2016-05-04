import { merge } from 'lodash'

export const entities = (state = { areas: {} }, action) => {
    if (action.response && action.response.entities) {
        return Object.assign({}, state, action.response.entities)
    }

    return state
}
