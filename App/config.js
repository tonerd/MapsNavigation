module.exports = {
  contentSecurityPolicy: {
    connectSrc: ['http://localhost:60999'],
    defaultSrc: ["'self'"],
    scriptSrc: ["'self'"],
    styleSrc: ["'self'"],
    imgSrc: ["'self'"]
  }
}
