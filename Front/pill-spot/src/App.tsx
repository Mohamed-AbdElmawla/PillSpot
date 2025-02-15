import './App.css'
import Router from './Router'
import { I18nextProvider } from "react-i18next";
import i18n from "./translation";


function App() {


  return (
    <>

     <I18nextProvider i18n={i18n}>
        <Router/>

     </I18nextProvider>


    </>
  )
}

export default App
