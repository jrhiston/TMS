import React, { Component, PropTypes } from 'react'
import './Page.scss'
import ActionBar from './ActionBar'

export default class Page extends Component {
    render () {
        return (
            <div className="page-container">
                <div className="page-header">
                    <h2 className="page-title">{this.props.title}</h2>
                </div>
                <div className="page-actions">
                    <ActionBar actions={this.props.actions} />
                </div>
                <div className="page-body">
                    {this.props.children}
                </div>
            </div>
        )
    }
}

Page.propTypes = {
    title: PropTypes.string.isRequired,
    actions: PropTypes.arrayOf(PropTypes.shape({
        text: PropTypes.string.isRequired,
        handleButtonClick: PropTypes.func.isRequired
    }).isRequired).isRequired
}
