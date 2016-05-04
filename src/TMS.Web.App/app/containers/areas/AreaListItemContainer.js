import { connect } from 'react-redux'
import AreaListItem from '../../components/areas/AreaListItem'
import { deleteArea } from '../../actions/areas/deleteArea'
import { listUserAreas } from '../../actions/areas/listUserAreas'

const mapStateToProps = (state) => {
    return {
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        deleteArea: (areaId) => dispatch(deleteArea(areaId))
    }
}

const AreaListItemContainer = connect(
    mapStateToProps,
    mapDispatchToProps
)(AreaListItem)

export default AreaListItemContainer
