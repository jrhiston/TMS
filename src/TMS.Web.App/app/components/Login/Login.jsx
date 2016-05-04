import './Login.scss'
import React, { Component, PropTypes } from 'react'
import LoginForm from './LoginForm'

export default class Login extends Component {
    render() {
        return (
            <div className='container'>
                <LoginForm login={this.props.login} redirectUrl={this.props.redirectUrl}/>
            </div>
        )
    }
}

Login.propTypes = {
    login: PropTypes.func.isRequired,
    redirectUrl: PropTypes.string.isRequired
}
