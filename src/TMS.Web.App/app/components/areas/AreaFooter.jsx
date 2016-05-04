import React, { Component, PropTypes } from 'react'

export default class AreaFooter extends Component {
    constructor(props){
        super(props)

        this.createArea = this.createArea.bind(this)
    }

    createArea() {
        this.props.createArea()
    }

    render () {
        return (
            <div className="areas-footer">
                {/*<button type="button" className="btn btn-primary" onClick={this.createArea}>Create Area</button>*/}
            </div>
        )
    }
}

AreaFooter.propTypes = {
    createArea: PropTypes.func.isRequired
}
