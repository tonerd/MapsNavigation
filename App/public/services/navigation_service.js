import Fetch from '../utils/fetch';
import ServerRoutes from '../utils/server_routes';

export default {
  getDistance(directions) {
    return Fetch.post(ServerRoutes.navigation.getDistance, { directions: directions });
  }
}
