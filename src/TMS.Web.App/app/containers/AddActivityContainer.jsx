import { connect } from 'react-redux'
import AddActivity from '../components/AddActivity'
import { addActivity } from '../actions/actions'

const mapStateToProps = (state) => {
    return {
        defaultActivityTitleValue: "New activity",
        defaultActivityDescriptionValue: "New activity description",
        existingAreas: state.userAreas.areas
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        onChange: (title, description) => {
            dispatch(addActivity(title, description))
        }
    }
}

const AddActivityContainer = connect(
    mapStateToProps,
    mapDispatchToProps
)(AddActivity)

export default AddActivityContainer