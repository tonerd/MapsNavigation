import fetch from 'isomorphic-fetch';

export default {
  post : (url, body) => {
    return fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(body)
    });
  }
}
