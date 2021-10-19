import React, { useState } from 'react'
import { Route, Switch, NavLink} from "react-router-dom"
import './App.css'
import HomePage from './Components/HomePage'
import Groups from './Components/Groups'
import Campers from './Components/Campers'
import NavBar from './Components/Navbar'
import Profile from './Components/Profile'
import LandingPage from './Components/LandingPage'
import ProtectedRoute from './auth/ProtectedRoute'

function App() {

  return (
    <div className="App">
      {
        location.pathname !== '/' && <NavBar />
      }
      <Switch>
        <Route exact path="/" component={LandingPage} />
        <ProtectedRoute exact path="/home" component={HomePage} />
        <ProtectedRoute exact path="/groups" component={Groups} />
        <ProtectedRoute exact path="/campers" component={Campers} />
        <ProtectedRoute exact path="/profile" component={Profile} />
      </Switch>
    </div>
  )
}

export default App