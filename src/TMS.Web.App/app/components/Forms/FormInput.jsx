import React, { Component, PropTypes } from 'react'
import './form-input.scss'

export default class FormInput extends Component {
    constructor(props){
        super(props)

        this.onChange = this.onChange.bind(this)
    }

    componentWillMount() {
        this.setState({value: ""})
    }

    componentWillReceiveProps(nextProps) {
        this.setState({value: nextProps.defaultValue})
    }

    onChange (e) {
        this.setState({value: e.target.value})
    }

    render() {
        const { label, placeholder, type, id } = this.props
        return (
            <div className="form-row">
                <label
                    htmlFor={id}
                    className="form-input-label">
                    {label}
                </label>
                <input
                    type={type}
                    className="form-input"
                    ref={id + "Ref"}
                    id={id}
                    placeholder={placeholder}
                    value={this.state.value}
                    onChange={this.onChange}/>
            </div>
        )
    }
}

FormInput.propTypes = {
    id: PropTypes.string.isRequired,
    label: PropTypes.string.isRequired,
    placeholder: PropTypes.string,
    type: PropTypes.string.isRequired,
    defaultValue: PropTypes.string
}
