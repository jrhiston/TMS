import React, { Component, PropTypes } from 'react'
import DropDownList from './DropDownList'

export default class AddActivity extends Component {
    constructor(props){
        super(props)
        
        this.handleGoClick = this.handleGoClick.bind(this)
        this.handleKeyUp = this.handleKeyUp.bind(this)
    }
    
    getActivityTitleInputValue() {
        return this.refs.activityTitleInput.value
    }
    
    getActivityDescriptionInputValue() {
        return this.refs.activityDescriptionInput.value
    }
    
    handleKeyUp(e) {
        if (e.keyCode === 13) {
            this.handleGoClick();
        }
    }
    
    handleGoClick(){
        this.props.onChange(
            this.getActivityTitleInputValue(),
            this.getActivityDescriptionInputValue()
        )
    }
    
    render() {
        const {defaultActivityTitleValue, defaultActivityDescriptionValue, existingAreas} = this.props
        
        var dropDownAreas = existingAreas.map(area => ({
            id: area.areaId, 
            name: area.name
        }))
        
        return (
            <div className="panel panel-primary">
                <div className="panel-heading">
                    Add a new activity
                </div>
                <div className="panel-body">
                    <DropDownList dropDownLabel="Select area" items={dropDownAreas}/>
                    <div className="form-group">
                        <label data-for="activityTitleInput">Title</label>
                        <input 
                            id="activityTitleInput" 
                            placeholder="Title"
                            className="form-control" 
                            ref="activityTitleInput"
                            defaultValue={defaultActivityTitleValue}/>
                    </div>
                    <div className="form-group">
                        <label data-for="activityDescriptionInput">Description</label>
                        <input
                            id="activityDescriptionInput"
                            placeholder="Description"
                            className="form-control"
                            ref="activityDescriptionInput"
                            defaultValue={defaultActivityDescriptionValue}/>
                    </div>
                    
                    <p className="help-block">All fields are mandatory</p>
                    <button className="btn btn-primary" onClick={this.handleGoClick}>Add Activity</button>
                </div>
            </div>
        )
    }
}

AddActivity.propTypes = {
    defaultActivityTitleValue: PropTypes.string.isRequired,
    defaultActivityDescriptionValue: PropTypes.string.isRequired,
    existingAreas: PropTypes.arrayOf(PropTypes.shape({
        areaId: PropTypes.number.isRequired,
        name: PropTypes.string.isRequired,
        description: PropTypes.string.isRequired
    }).isRequired).isRequired,
    onChange: PropTypes.func.isRequired
}