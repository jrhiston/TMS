import React, { Component, PropTypes } from 'react'
import Activity from './Activity'

export default class ActivityList extends Component {
    render() {
        return (
            <div className="activityList">
                {
                    this.props.activities.map(activity =>
                        <Activity
                            key={activity.id}
                            id={activity.id}
                            title={activity.title}
                            description={activity.description} />
                    )
                }
            </div>
        )
    }
}

ActivityList.propTypes = {
    activities: PropTypes.arrayOf(PropTypes.shape({
        id: PropTypes.number.isRequired,
        title: PropTypes.string.isRequired,
        description: PropTypes.string.isRequired
    }).isRequired).isRequired
}
