import React from 'react'
import { Route } from 'react-router'
import { requireAuthentication } from '../containers/RequireAuthentication'
import AppContainer from '../containers/App'
import LoginContainer from '../containers/LoginContainer'
import * as areaSection from '../exports/areaSection'

export default (
    <Route path="/TMS" name="Home" component={requireAuthentication(AppContainer)}>
        <Route path="Areas" name="Areas" component={requireAuthentication(areaSection.AreaSectionContainer)}/>
        <Route path="Areas/Create" name="Create Area" component={requireAuthentication(areaSection.AreaEditContainer)} />
        <Route path="Areas/:areaId" component={requireAuthentication(areaSection.AreaEditContainer)}/>
        <Route path="Areas/View/:areaId" component={requireAuthentication(areaSection.AreaViewSectionContainer)}/>
        <Route path="Login" component={LoginContainer}/>
    </Route>
)
