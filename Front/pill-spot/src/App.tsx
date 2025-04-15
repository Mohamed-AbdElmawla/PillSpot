import './App.css'
import Router from './Router'
import { I18nextProvider } from "react-i18next";
import i18n from "./translation";
import setupInterceptors from './app/globalLogout';
import { useEffect } from 'react';
// import { Toaster } /from 'sonner'/;


function App() {
  useEffect(() => {
    setupInterceptors(); // Pass logout function
  }, []);
  return (
    <>
     <I18nextProvider i18n={i18n}>
        <Router/>
     </I18nextProvider>


    </>
  )

 
}

export default App
