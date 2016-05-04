import React, { Component, PropTypes } from 'react'
import AreaListItemContainer from '../../containers/areas/AreaListItemContainer'
import Page from '../Page'

export default class AreaList extends Component {
    render () {
        return (
            <Page title="Areas" actions={this.props.actions}>
                {
                    this.props.areas.map(area => {
                        if (area && area !== null) {
                            return <AreaListItemContainer
                                key={area.areaId}
                                areaId={area.areaId}
                                name={area.name}
                                description={area.description}/>
                        }
                    })
                }
            </Page>
        )
    }
}

AreaList.propTypes = {
    actions: PropTypes.arrayOf(PropTypes.shape({
        text: PropTypes.string.isRequired,
        handleButtonClick: PropTypes.func.isRequired
    }).isRequired).isRequired,
    areas: PropTypes.arrayOf(PropTypes.shape({
        areaId: PropTypes.number.isRequired,
        name: PropTypes.string.isRequired,
        description: PropTypes.string.isRequired
    }).isRequired).isRequired
}
