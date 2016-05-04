import React, { Component, PropTypes } from 'react'
import { connect } from 'react-redux'
import { addActivity } from '../../actions/actions'
import { Link } from 'react-router'
import './NavigationBar.scss'
import Icon from 'react-fa'
import { AREA_SECTION_ROUTE } from '../../routing/areas'

class NavigationBar extends Component {
    constructor(props){
        super (props)

        this.handleLogout = this.handleLogout.bind(this)
    }

    handleLogout() {
        this.props.logout()
    }

    render () {
        return (
            <div className="navigation-bar">
                <h1 className="navigation-bar-title">TMS</h1>
                <ul role="nav" className="navigation-bar-list">
                    <li className="navigation-bar-list-item"><a href='#'><Icon name="sign-out"/></a></li>
                    <li className="navigation-bar-list-item"><Link to={AREA_SECTION_ROUTE} title="Areas"><Icon name="book"/></Link></li>
                    <li className="navigation-bar-list-item"><Link to="/TMS/UserGroups" title="User Groups"><Icon name="users"/></Link></li>
                    <li className="navigation-bar-list-item"><Link to="/TMS/Tags" title="Tags"><Icon name="tag"/></Link></li>
                    <li className="navigation-bar-list-item"><Link to="/TMS/Reports" title="Reports"><Icon name="bar-chart"/></Link></li>
                </ul>
            </div>
        )
    }
}

NavigationBar.propTypes = {
    logout: PropTypes.func.isRequired
}

const mapStateToProps = (state) => {
    return {

    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        logout: () => {

        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(NavigationBar)
