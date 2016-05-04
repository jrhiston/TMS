import React, { Component, PropTypes } from 'react'
import { connect } from 'react-redux'
import Footer from '../components/footer/Footer'
import Header from '../components/header/Header'
import NavigationBar from './Navigation/NavigationBar'
import { Link } from 'react-router'
import './App.scss'
import '../styles/global.scss'

var Breadcrumbs = require('react-breadcrumbs')

class App extends Component {
    constructor(props) {
        super (props)
    }

    render () {
        return (
            <div className="app--container">
                {/*<Header/>*/}
                <div className="app--navigation-bar">
                    <NavigationBar />
                </div>
                {/*<div className="app--breadcrumbs">
                    <Breadcrumbs routes={this.props.routes} params={this.props.params}/>
                </div>*/}
                <div className="app--main-content">
                    <div className="app--children">
                        {this.props.children}
                    </div>
                </div>
                <Footer/>
            </div>
        )
    }
}

const mapStateToProps = (state) => {
    return {
        loggedIn: state.login.loggedIn
    }
}

const AppContainer = connect(mapStateToProps, {})(App)

export default AppContainer
