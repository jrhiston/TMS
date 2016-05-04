import React from 'react'
import { connect } from 'react-redux'
import { browserHistory } from 'react-router'

export function requireAuthentication(Component) {

    class AuthComponent extends React.Component {

        componentWillMount() {
            if (!this.props.loggedIn) {
                browserHistory.push('/TMS/Login')
            }
        }

        render() {
            // render the component that requires auth (passed to this wrapper)
            return (
                <Component  {...this.props} />
            )
        }
    }

    const mapStateToProps =
        (state) => ({
            loggedIn: state.login.loggedIn
        });

    return connect(mapStateToProps)(AuthComponent);

}