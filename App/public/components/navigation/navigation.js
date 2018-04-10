import React, {Component} from 'react';

class Navigation extends Component {
  constructor() {
    super();

    this.state = {
      directions: ''
    }

    this.getDistance = this.getDistance.bind(this);
    this.onDirectionsChange = this.onDirectionsChange.bind(this);
  }

  getDistance(event) {
    event.preventDefault();
    this.props.getDistance(this.state.directions);
  }

  onDirectionsChange(event) {
    this.setState({ directions: event.target.value });
  }

  render() {
    return (
      <div id='navigation'>
        <div className='container'>
          <div className='row'>
            <h1 className='col-sm-12'>Maps Navigation</h1>
          </div>
          {
            this.props.serviceError &&
              <div className='row'>
                <div className='col-sm-12'>
                  <div className='alert alert-danger'>There was a problem with the navigation service, please try again.</div>
                </div>
              </div>
          }
          <div className='row'>
            <div className='col-sm-12'>
              <p>This page calculates distance from a start position to an end position, after directions are followed.
                Directions are specified as either a left turn(L) or right turn (R), followed by distance.  Each direction
                is comma delimited.  For example "L2, R1, L3" to move left two spaces, then right one, the left 3.
              </p>
            </div>
          </div>

          <div className='row'>
            <div className='col-sm-12'>
              <form>
                <label htmlFor='directions'>Enter directions:</label>
                <input id='directions' type='text' value={this.state.directions} onChange={this.onDirectionsChange} />
                <input disabled={this.state.directions.trim() === ''} className='btn btn-primary btn-sm' type='submit' value='Calculate' onClick={this.getDistance} />
              </form>
            </div>
          </div>
          <div id='navigationResults'>
          {
            this.props.result && this.props.result === -1 &&
              <div className='row'>
                <div className='col-sm-12'>
                  <div className='alert alert-danger'>The input was invalid.  Please correct it and try again.</div>
                </div>
              </div>
          }
          {
            this.props.result && this.props.result !== -1 &&
              <div className='row'>
                <div className='col-sm-12'>
                  <div className='alert alert-success'>You are {this.props.result} block{this.props.result > 1 ? 's' : ''} from your destination.</div>
                </div>
              </div>
          }
          </div>
        </div>
      </div>
    );
  }
}

export default Navigation
