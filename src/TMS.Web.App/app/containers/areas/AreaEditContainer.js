import { connect } from 'react-redux'
import AreaEdit from '../../components/areas/AreaEdit'
import { saveArea } from '../../actions/areas/saveArea'
import { editArea } from '../../actions/areas/editArea'

const mapStateToProps = (state, ownProps) => {
    const { areaId } = ownProps.params

    const {
        entities: { areas },
        pages: { areasection }
    } = state

    let viewArea = areas[areaId]
    let areaProps = {}

    if (typeof viewArea !== 'undefined' && viewArea !== null) {
        areaProps.name = viewArea.name
        areaProps.description = viewArea.description
    }

    return {
        isLoading: areasection.isFetching,
        area: {
            areaId: areaId,
            name: areaProps.name,
            description: areaProps.description
        }
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        save: (areaInformation, callback) => dispatch(saveArea(areaInformation, callback)),
        viewArea: (areaId) => dispatch(editArea(areaId))
    }
}

const AreaEditContainer = connect(
    mapStateToProps,
    mapDispatchToProps
)(AreaEdit)

export default AreaEditContainer
