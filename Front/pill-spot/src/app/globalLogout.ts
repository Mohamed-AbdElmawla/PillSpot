import axios from 'axios';
import authServices from '../features/auth/authServices';
let counter : number = 0 ; 
const setupInterceptors = () => {
  axios.interceptors.response.use(
    (response) => response,
    async (error) => {
      if (error.response?.status === 401) {  
        console.log('Token expired! Logging out...');
        console.log(counter);
        if(counter===0){
            authServices.logout() ; //it will be refresh instead of logout 
            console.log("loggin out");
        }
        counter++;
      }
      return Promise.reject(error);
    }
  );
};

export default setupInterceptors;
