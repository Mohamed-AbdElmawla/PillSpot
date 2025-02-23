import React from 'react'
import MedicineDetails from './DetailsCard'
import ResultTable from './ResultTable'

const ResultPageDetails = () => {
  return (
    <>
    <div className='flex flex-col gap-5 mt-10'>
      <MedicineDetails/>
     
      <ResultTable/>

    </div>
    </>
  )
}

export default ResultPageDetails
