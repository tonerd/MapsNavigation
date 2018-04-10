import * as types from '../constants/action_types'

export default function sitters(state = { result: null }, action) {
  switch (action.type) {
    case types.NAVIGATION_GET_DISTANCE:
      return Object.assign({}, state, {
        result: action.distance.result,
        serviceError: false
      });
    case types.NAVIGATION_SERVICE_ERROR:
      return Object.assign({}, state, {
        serviceError: true
      });
    default:
      return state;
  }
}
