import * as types from '../constants/action_types';
import NavigationService from '../services/navigation_service';

export const getDistance = (distance) => {
  return dispatch => {
    NavigationService.getDistance(distance)
      .then(response => {
        if (response.ok) {
          return response.json();
        }
        throw true;
      })
      .then(distance => dispatch({ type: types.NAVIGATION_GET_DISTANCE, distance }))
      .catch(() => dispatch({ type: types.NAVIGATION_SERVICE_ERROR }));
  };
}
