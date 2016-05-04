import React, { Component, PropTypes } from 'react'
import './form-text-area.scss'

export default class FormTextArea extends Component {
    constructor(props){
        super(props)

        this.onChange = this.onChange.bind(this)
    }

    componentWillMount(){
        this.setState({value: ""})
    }

    componentWillReceiveProps(nextProps) {
        this.setState({value: nextProps.defaultValue})
    }

    onChange (e) {
        this.setState({value: e.target.value})
    }

    render() {
        const { label, placeholder, id } = this.props
        return (
            <div className="form-row">
                <label
                    htmlFor={id}
                    className="form-input-label">
                    {label}
                </label>
                <textarea
                    className="form-input"
                    id={id}
                    placeholder={placeholder}
                    value={this.state.value}
                    onChange={this.onChange}/>
            </div>
        )
    }
}

FormTextArea.propTypes = {
    id: PropTypes.string.isRequired,
    label: PropTypes.string.isRequired,
    placeholder: PropTypes.string
}
