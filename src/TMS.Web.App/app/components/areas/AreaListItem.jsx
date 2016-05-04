import React, { Component, PropTypes } from 'react'
import Icon from 'react-fa'
import './area-list-item.scss'
import { AREA_SECTION_ROUTE, AREA_SECTION_VIEW } from '../../routing/areas'
import { Link } from 'react-router'

export default class AreaListItem extends Component {
    constructor (props) {
        super(props)

        this.onHandleDelete = this.onHandleDelete.bind(this)
    }

    onHandleDelete() {
        this.props.deleteArea(this.props.areaId)
    }

    render () {
        return (
            <div className="area-list-item">
                <div className="area-list-item-heading">
                    <Link
                        to={AREA_SECTION_VIEW + '/' + this.props.areaId}
                        title={this.props.name}>
                        {this.props.name}
                    </Link>
                    <div className="area-title-menu">
                        <Link
                            to={AREA_SECTION_ROUTE + '/' + this.props.areaId}
                            className="area-menu-icon"
                            title={"Edit " + this.props.name}>
                            <Icon name="pencil-square-o"/>
                        </Link>
                        <a onClick={this.onHandleDelete} title={"Delete " + this.props.name} className="area-menu-icon">
                            <Icon name="trash-o"/>
                        </a>
                    </div>
                </div>
                <hr/>
                <p className="area-list-item-text">
                    {this.props.description}
                </p>
            </div>
        )
    }
}

AreaListItem.propTypes = {
    areaId: PropTypes.number,
    name: PropTypes.string.isRequired,
    description: PropTypes.string.isRequired,
    deleteArea: PropTypes.func.isRequired
}
