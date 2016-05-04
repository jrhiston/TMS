import React, { Component, PropTypes } from 'react'
import { Link } from 'react-router'
import './LoginForm.scss'

export default class LoginForm extends Component {
    constructor(props){
        super(props)

        this.handleLoginClick = this.handleLoginClick.bind(this)
    }

    getUsernameInputValue() {
        return this.refs.userNameInput.value
    }

    getPasswordInputValue() {
        return this.refs.passwordInput.value
    }

    handleLoginClick(){
        this.props.login(
            this.getUsernameInputValue(),
            this.getPasswordInputValue(),
            this.props.redirectUrl
        )
    }

    render() {
        return (
            <div className="login-form">
                <h1 className="login-form--heading">TMS Login</h1>

                <div className="login-form--body">
                    <div className="login-form--row">
                        <label data-for="userNameInput" className="form-label">Username</label>
                        <input
                        type="text"
                            id="userNameInput"
                            placeholder="Username"
                            className="form-control"
                            ref="userNameInput"/>
                    </div>
                    <div className="login-form--row">
                        <label data-for="passwordInput" className="form-label">Password</label>
                        <input
                            type="password"
                            id="passwordInput"
                            placeholder="Password"
                            className="form-control"
                            ref="passwordInput"/>
                    </div>
                </div>
                <div className="login-form--submit">
                    <button className="btn btn-primary" onClick={this.handleLoginClick}>Login</button>
                </div>
            </div>
        )
    }
}

LoginForm.propTypes = {
    login: PropTypes.func.isRequired,
    redirectUrl: PropTypes.string.isRequired
}
