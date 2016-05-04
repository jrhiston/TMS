import React, { Component, PropTypes } from 'react'
//import ActivityList from './ActivityList'

export default class AreaView extends Component {
    render () {
        return (
            <Page title={this.props.name} actions={this.props.actions}>
                <div className="area-view-body">
                    <p>{this.props.description}</p>
                    <div className="area-view-activities">
                        {/*<ActivityList activities={this.props.activities} />*/}
                    </div>
                </div>
            </Page>
        )
    }
}

AreaView.propTypes = {
    name: PropTypes.string.isRequired,
    description: PropTypes.string.isRequired,
    activities:  PropTypes.arrayOf(PropTypes.shape({
        id: PropTypes.number.isRequired,
        title: PropTypes.string.isRequired,
        description: PropTypes.string.isRequired
    }).isRequired).isRequired,
    actions: PropTypes.arrayOf(PropTypes.shape({
        text: PropTypes.string.isRequired,
        handleButtonClick: PropTypes.func.isRequired
    }).isRequired).isRequired,
}
