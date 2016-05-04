import merge from 'lodash/merge'
import union from 'lodash/union'
import { intersection } from 'lodash'

export default function dataLoader({ types, invalidateTypes }) {
    if (!Array.isArray(types) || types.length !== 3) {
        throw new Error('Expected types to be an array of three elements.')
    }

    if (!Array.isArray(invalidateTypes)) {
        throw new Error('Expected invalidate types to be an array.')
    }

    if (!types.every(t => typeof t === 'string')) {
        throw new Error('Expected types to be strings')
    }

    const [ requestType, successType, failureType ] = types

    return function updateDataLoading(state = {
        isFetching: true,
        didInvalidate: true
    }, action) {
        if (invalidateTypes.some((current) => action.type === current)) {
            return merge({}, state, {
                isFetching: false,
                didInvalidate: true
            })
        }

        switch (action.type) {
            case requestType:
                return merge({}, state, {
                    isFetching: true,
                    didInvalidate: true
                })
            case successType:
                return merge({}, state, {
                    isFetching: false,
                    ids: Object.assign(action.response.result),
                    didInvalidate: false
                })
            case failureType:
                return merge({}, state, {
                    isFetching: false,
                    didInvalidate: false
                })
            default:
                return state
        }
    }
}
