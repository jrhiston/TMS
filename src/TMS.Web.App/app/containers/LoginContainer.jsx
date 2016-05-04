import { connect } from 'react-redux'
import Login from '../components/Login/Login'
import { login } from '../actions/login/login'
import { getPreviousUrl } from '../middleware/stateHelpers'

const mapStateToProps = (state) => {
    return {
        loggedIn: state.login.loggedIn,
        redirectUrl: getPreviousUrl(state) || ''
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        login: (username, password, redirectUrl) => {
            dispatch(login(username, password, redirectUrl))
        }
    }
}

const LoginContainer = connect(
    mapStateToProps,
    mapDispatchToProps
)(Login)

export default LoginContainer