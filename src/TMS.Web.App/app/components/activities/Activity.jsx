import React, { Component, PropTypes } from 'react'

export default class Activity extends Component {
    render() {
        const {title, description} = this.props
        return (
            <div className="activity">
                <div>{ title }</div>
                <div>{ description }</div>
            </div>
        )
    }
}

Activity.propTypes = {
    id: PropTypes.number.isRequired,
    title: PropTypes.string.isRequired,
    description: PropTypes.string.isRequired
}
