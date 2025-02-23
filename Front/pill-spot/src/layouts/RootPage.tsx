import { Toaster } from 'sonner'
import {  Outlet } from 'react-router-dom'
import { useSelector } from 'react-redux'
import { RootState } from '../app/store'


const RootPage = () => {
 
  const colors = useSelector((state:RootState)=>state.toastSlice.richColors) ;
  return (
    <div>
      <Toaster position="top-right" richColors={colors}  expand={false} />
      <Outlet/>
    </div>
  )
}

export default RootPage
