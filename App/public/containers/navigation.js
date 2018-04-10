import { connect } from 'react-redux'
import { getDistance } from '../actions/navigation'
import Navigation from '../components/navigation/navigation'

const mapStateToProps = state => {
  return {
    result: state.navigation.result,
    serviceError: state.navigation.serviceError
  }
}

const mapDispatchToProps = dispatch => {
  return {
    getDistance: (directions) => dispatch(getDistance(directions))
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(Navigation);
