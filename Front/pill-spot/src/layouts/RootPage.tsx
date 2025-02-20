import React from 'react'
import { NavLink, Outlet } from 'react-router-dom'

const RootPage = () => {
  return (
    <div>

      <div className="flex gap-10">
        <NavLink to="result" className="btn" > Result Paga </NavLink>
        <NavLink to="landing"  className="btn"> langing Paga </NavLink>
      </div>
      <hr />
      <hr />
      <Outlet/>
    </div>
  )
}

export default RootPage
