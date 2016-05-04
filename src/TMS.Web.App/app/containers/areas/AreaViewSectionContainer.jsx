import React, { Component, PropTypes } from 'react'
import { connect } from 'react-redux'
import { getArea } from '../../actions/areas/getArea'
import AreaViewContainer from './AreaViewContainer'
//import './AreaSectionContainer.scss'
import Section from '../../components/Section'

class AreaViewSection extends Component {
    render () {
        return (<Section
            isLoading={this.props.isLoading}
            didInvalidate={this.props.didInvalidate}
            loadSection={this.props.getArea}
            loadSectionParam={this.params.areaId}
            className="area-view-section">
            <AreaViewContainer />
        </Section>)
    }
}

const mapStateToProps = (state) => {
    return {
        isLoading: state.pages.areaview.isFetching,
        didInvalidate: state.pages.areaview.didInvalidate
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        getArea: (areaId) => dispatch(getArea(areaId))
    }
}

const AreaViewSectionContainer = connect(
    mapStateToProps,
    mapDispatchToProps
)(AreaViewSection)

export default AreaViewSectionContainer
