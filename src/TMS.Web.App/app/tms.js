import 'babel-polyfill'

import React from 'react'
import { render } from 'react-dom'
import { syncHistoryWithStore } from 'react-router-redux'
import './styles/global.scss'
import configureStore from './store/configureStore'
import Root from './containers/Root'
import { browserHistory } from 'react-router'
import { userHasValidAuthToken } from './middleware/api'
import { receiveLogin } from './actions/login/login'

// Configure the store
const store = configureStore()
// Sync the browser history with the store.
const history = syncHistoryWithStore(browserHistory, store)

// Update whether the user is logged in.
updateUserLogin()

render(
  <Root store={store} history={history} />,
  document.getElementById('content')
)

// This will update the user login state based on if they have a valid oauth token.
function updateUserLogin() {
    let result = userHasValidAuthToken()
    if (result) {
        store.dispatch(receiveLogin(result.userName))
    }
}
