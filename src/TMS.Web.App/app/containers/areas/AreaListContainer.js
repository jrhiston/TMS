import { connect } from 'react-redux'
import AreaList from '../../components/areas/AreaList'
import { browserHistory } from 'react-router'
import * as Routing from '../../routing/areas'

const areaActions = [
    {
        text: "Add Area",
        handleButtonClick: () => browserHistory.push(Routing.AREA_SECTION_CREATE)
    }
]

const mapStateToProps = (state) => {
    const {
        pages: { areasection },
        entities: { areas }
    } = state

    const areasToShow = areasection.ids.map(id => areas[id])

    return {
        areas: areasToShow,
        actions: areaActions
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
    }
}

const AreaListContainer = connect(
    mapStateToProps,
    mapDispatchToProps
)(AreaList)

export default AreaListContainer
