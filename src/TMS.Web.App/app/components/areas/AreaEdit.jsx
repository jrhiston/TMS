import React, { Component, PropTypes } from 'react'
import './area-create.scss'
import { browserHistory } from 'react-router'
import { AREA_SECTION_ROUTE } from '../../routing/areas'
import Icon from 'react-fa'
import FormInput from '../Forms/FormInput'
import FormTextArea from '../Forms/FormTextArea'

function loadData(props) {
    const { area } = props

    props.viewArea(area.areaId)
}

export default class AreaEdit extends Component {
    constructor(props) {
        super(props)

        this.handleOnSubmit = this.handleOnSubmit.bind(this)
    }

    componentWillMount() {
        const { area } = this.props
        if (typeof area !== 'undefined'
             && area !== null
             && typeof area.areaId !== 'undefined'
             && area.areaId !== null) {
            loadData(this.props)
        }
    }

    handleOnSubmit(e) {
        e.preventDefault()
        this.props.save(this.getFormData(), () => {
            browserHistory.push(AREA_SECTION_ROUTE)
        })
    }

    getFormData() {
        return {
            areaId: this.props.params.areaId,
            name: this.refs.areaNameRef.state.value,
            description: this.refs.areaDescriptionRef.state.value
        }
    }

    render () {
        const { area } = this.props

        return (
            <div className="area-create">
                <form className="form">
                    <FormInput
                        id="areaName"
                        label="Area Name"
                        placeholder="Area Name"
                        type="text"
                        defaultValue={area.name}
                        ref="areaNameRef" />

                    <FormTextArea
                        id="inputDescription"
                        placeholder="Description"
                        label="Description"
                        defaultValue={area.description}
                        ref="areaDescriptionRef" />

                    <div className="form-row">
                        <button
                            type="submit"
                            className="btn btn-default"
                            onClick={this.handleOnSubmit}>Save
                        </button>
                    </div>
                </form>
            </div>
        )
    }
}

AreaEdit.propTypes = {
    save: PropTypes.func.isRequired,
    viewArea: PropTypes.func.isRequired,
    isLoading: PropTypes.bool.isRequired,
    area: PropTypes.shape({
        id: PropTypes.number,
        title: PropTypes.string,
        description: PropTypes.string
    }).isRequired
}
