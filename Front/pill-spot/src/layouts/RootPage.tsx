import React from 'react'
import { Outlet } from 'react-router-dom'

const RootPage = () => {
  return (
    <div>
      <Outlet/>
    </div>
  )
}

export default RootPage
