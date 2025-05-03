import axios from 'axios';
 import  authServices  from '../features/auth/authServices'; 

const axiosInstance = axios.create({
  baseURL: 'https://api.example.com',
  withCredentials: true, 
});


axiosInstance.interceptors.response.use(
  (response) => response,
  async (error) => {
    if (error.response?.status === 401) {
      console.warn('Token expired! Logging out...');
      console.log('Token expired! Logging out...');
      authServices.logout(); // instead of logout , make it refresh
    }
    return Promise.reject(error);
  }
);

export default axiosInstance;
