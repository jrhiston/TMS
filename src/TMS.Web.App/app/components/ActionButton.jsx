import React, { Component, PropTypes } from 'react'

export default class ActionButton extends Component {
    constructor(props) {
        super(props)

        this.onHandleButtonClick = this.onHandleButtonClick.bind(this)
    }

    onHandleButtonClick(e) {
        this.props.handleButtonClick(e)
    }

    render () {
        return (
            <button onClick={this.onHandleButtonClick}>{this.props.text}</button>
        )
    }
}

ActionButton.propTypes = {
    text: PropTypes.string.isRequired,
    handleButtonClick: PropTypes.func.isRequired
}
