import { Toaster } from 'sonner'
import {  Outlet } from 'react-router-dom'
import { useSelector } from 'react-redux'
import { RootState } from '../app/store'
// import HomePageMain from '../pages/HomePage'
// import RegPharmacy from '../pages/RegisterPharmacy'
// import SelectLocationMap from '../pages/RegisterPharmacy/SecondPage'
// import Map from '../pages/RegisterPharmacy/SecondPage'


const RootPage = () => {
 
  const colors = useSelector((state:RootState)=>state.toastSlice.richColors) ;
  return (
    <div id="hellowhome">
      <Toaster position="top-right" richColors={colors}  expand={false} />
      {/* <HomePageMain/> */}
      {/* <RegPharmacy/> */}
      {/* <Map/> */}
      <Outlet/>
    </div>
  )
}

export default RootPage
