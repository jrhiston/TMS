import React, { Component, PropTypes } from 'react'
import Icon from 'react-fa'
import './Section.scss'

export default class Section extends Component {
    constructor (props){
        super (props)
    }

    componentWillMount() {
        this.props.loadSection(this.props.loadSectionParam)
    }

    componentWillReceiveProps(nextProps) {
        if (nextProps.didInvalidate && !nextProps.isLoading)
            this.props.loadSection()
    }

    render () {
        const {
            isLoading
        } = this.props
        return isLoading ? (<div className="loading"> <Icon className="loading-icon" spin name="cog"/> </div>) :
        (
            <div className="section-container">
                {this.props.children}
            </div>
        )
    }
}

Section.propTypes = {
    isLoading: PropTypes.bool.isRequired,
    didInvalidate: PropTypes.bool.isRequired,
    loadSection: PropTypes.func.isRequired,
    loadSectionParam: PropTypes.string.isRequired
}
