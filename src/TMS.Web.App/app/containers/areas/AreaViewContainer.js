import { connect } from 'react-redux'
import AreaView from '../../components/areas/AreaView'
import { browserHistory } from 'react-router'
import * as Routing from '../../routing/areas'

const areaActions = [
    {
        text: "Add Activity",
        handleButtonClick: () => {}
    }
]

const mapStateToProps = (state) => {
    const {
        pages: { areaview },
        entities: { areas }
    } = state

    const idToFind = areaview.ids[0]
    const areaToView = areas.find(elem => elem.areaId == idToFind)

    return {
        name: areaToView.name,
        description: areaToView.description,
        activities: areaToView.activities,
        actions: areaActions
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
    }
}

const AreaViewContainer = connect(
    mapStateToProps,
    mapDispatchToProps
)(AreaView)

export default AreaViewContainer
