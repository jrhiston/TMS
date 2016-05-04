import React, { Component, PropTypes } from 'react'

export default class DropDownItem extends Component {
    render() {
        const {id, name} = this.props
        return (
            <option value={id} className="drop-down-list-item">
                {name}
            </option>
        )
    }
}

DropDownItem.propTypes = {
    id: PropTypes.number.isRequired,
    name: PropTypes.string.isRequired
}