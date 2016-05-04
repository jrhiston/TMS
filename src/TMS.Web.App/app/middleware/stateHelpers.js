export function getPreviousUrl(state) {
    let locationState = state.routing.locationBeforeTransitions.state
    
    if (locationState)
        return locationState.nextPathname
        
    return null
}