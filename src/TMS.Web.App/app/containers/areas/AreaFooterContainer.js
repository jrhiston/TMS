import { connect } from 'react-redux'
import AreaFooter from '../../components/areas/AreaFooter'
import { browserHistory } from 'react-router'
import { AREA_SECTION_CREATE } from '../../routing/areas'

const mapStateToProps = (state) => {
    return {
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        createArea: function () {
            browserHistory.push(AREA_SECTION_CREATE)
        }
    }
}

const AreaFooterContainer = connect(
    mapStateToProps,
    mapDispatchToProps
)(AreaFooter)

export default AreaFooterContainer
