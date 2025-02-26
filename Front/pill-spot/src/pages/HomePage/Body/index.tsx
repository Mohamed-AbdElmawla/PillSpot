import React from 'react'
import SecondHeader from './TopHeader'
import Advs from './Advs'
import Products from './Products'
import PharmacyWithUs from './Pharmacies'
import DoctorsCons from './Doctors'

const MainBody = () => {
  return (
    <div className='container' >
      <SecondHeader/>
      <Advs/>
      <Products/>
      <PharmacyWithUs/>
      <DoctorsCons/>
    </div>
  )
}

export default MainBody
