import React, { Component, PropTypes } from 'react'
import { connect } from 'react-redux'
import { listUserAreas } from '../../actions/areas/listUserAreas'
import AreaListContainer from './AreaListContainer'
import AreaFooterContainer from './AreaFooterContainer'
import Icon from 'react-fa'
import './AreaSectionContainer.scss'
import Section from '../../components/Section'

class AreaSection extends Component {
    render () {
        return (<Section
            isLoading={this.props.isLoading}
            didInvalidate={this.props.didInvalidate}
            loadSection={this.props.getAreas}
            className="area-section">
            <AreaListContainer/>
            {/*<AreaFooterContainer />*/}
        </Section>)
    }
}

const mapStateToProps = (state) => {
    return {
        isLoading: state.pages.areasection.isFetching,
        didInvalidate: state.pages.areasection.didInvalidate
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        getAreas: () => dispatch(listUserAreas())
    }
}

const AreaSectionContainer = connect(
    mapStateToProps,
    mapDispatchToProps
)(AreaSection)

export default AreaSectionContainer
