import React, { Component, PropTypes } from 'react'
import DropDownItem from './DropDownItem'

export default class DropDownList extends Component {
    render() {
        const {dropDownLabel, items} = this.props
        return (
            <div className="drop-down-list">
                <label>{dropDownLabel}</label>
                <select className="form-control">
                    {
                        items.map(item => 
                          <DropDownItem id={item.id} name={item.name}/>  
                        )
                    }
                </select>
            </div>
        )
    }
}

DropDownList.propTypes = {
    items: PropTypes.arrayOf(PropTypes.shape({
        id: PropTypes.number.isRequired,
        name: PropTypes.string.isRequired
    }).isRequired).isRequired,
    dropDownLabel: PropTypes.string.isRequired
}