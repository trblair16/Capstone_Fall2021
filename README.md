# Score Tracker for Camp Clot Not

[Checkout the App](https://hbdatracking.azurewebsites.net)

[Visit Our Website](https://tessa-hudson.github.io/Capstone_Fall2021/)

## Motivation

Camp Clot Not is a camp hosted by HBDA that allows children ranging from 6-18 years old who suffer from various bleeding disorders to enjoy a camp experience they normally would not be able to enjoy.

During the camp, counselors hold activities for the children and keep track of scores over the week to announce at the end of the camp what the teams earned, while also maintaining the correct amount of supervision for the kids needs and safety.
With an application to assist them, we hope we can allow these counselors an easy and intuitive way to keep track of scoring so they can focus on the needs and enjoyment of the children at the camp.​

## Core Features

- An easy-to-read leaderboard for each event
- A secure login system for camp counselors and administrators
- Full add/update/delete functionality for Attendees, Groups, and Events availiable to administators
- Point addition and subtraction available to authorized users
- Point tracking for groups of attendees
- Restricted views based on user roles

## Workflow/Standards

### Projects/Sprints and Issues

- Each feature, bug, or suggestion will be listed as an issue
- Issues will then be added to cards in the sprint (project) that they will be addressed in
- The cards should automatically update when a branch has been linked to that issue, when a pull request has been submitted for review, and when the request has been reviewed and successfully merged
- Note cards will be added to each Sprint for non-code related things such as design tasks
- Once a sprint is over, any incomplete items should be added to the next sprint and given first priority

### Branches and Pull Requests

- All code must be written on a branch, **_Not on_** `main`
- Team members should create branches based on issues in the current sprint and assign the corresponding issue to themselves
- Branch names for each team member follow the format `firstname/issuename`
- Before merging a branch into main, a pull request should be made and reviewed by at least 2 other team members

### Requirements for Dev Environment

- python3
- yarn

### Starting the Servers

- To start the backend server, run the startup script by entering ./startBackendDev.sh

  - You may need to give the script permission to run by entering the command chmod +x startBackendDev.sh

- To start the front end run the startup script by entering ./startReactDev.sh
  - This script may also need permission to run

These scripts contain secrets and important enviroment variables needed for the servers to run. Contact Tyler Blair (trblair@crimson.ua.edu) to recieve a copy of the scripts.

### Testing and Documentation

- Documentation for the API can be found on the [project site](https://tessa-hudson.github.io/Capstone_Fall2021/api/)
