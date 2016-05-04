import React, { Component, PropTypes } from 'react'
import ActionButton from './ActionButton'

export default class ActionBar extends Component {
    render () {
        return (
            <div>
                {
                    this.props.actions.map(action => <ActionButton
                        key={action.text}
                        text={action.text}
                        handleButtonClick={action.handleButtonClick}/>)
                }
            </div>
        )
    }
}

ActionBar.propTypes = {
    actions: PropTypes.arrayOf(PropTypes.shape({
        text: PropTypes.string.isRequired,
        handleButtonClick: PropTypes.func.isRequired
    }).isRequired).isRequired
}
