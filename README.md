# Overview
This is a solution for the iTrellis Maps Navigation coding exercise.  It provides a single page where directions can be entered, such as "R5, L5, R5, R3", and a distance is calculated.  The project is comprised of a C# WebApi with a React front-end, and Node is used to host the application.

## Prerequisites
Node and Visual Studio are required to be installed to compile and run the application.

## Installation Instructions
1. Open command prompt to the App directory in the root of the project.
2. Install gulp globally with the command "npm install gulp -g".
3. Run "npm install".
4. Run "gulp".  
5. Run "node app" to start the Node server.
6. Open the solution in the WebApi folder in Visual Studio, and run it.  This will open a webpage and display a simple status message.
7. Open browser to http://localhost:3000.

The default url for the WebApi solution is "localhost:60999".  If this changes for any reason, the React and Node applications will also have to be updated to point to the new url.  The files that need updated are App/config.js and App/public/utils/server_routes.
