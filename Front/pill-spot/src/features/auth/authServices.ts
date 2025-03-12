import axios from "axios";
import { ISignUpData , IloginData } from "../../components/SignUpModel/types";

// od not forget the local host at the beggining
const registerUrl = import.meta.env.VITE_REGISTER_URL;
const loginUrl = import.meta.env.VITE_LOGIN_URL

//  const FakeAPI_URL = "https://jsonplaceholder.typicode.com/users";

const register = async (userData: ISignUpData) => {
  const formData = new FormData();
  const file =  new File([], "empty.jpg", { type: "image/png" });
  formData.append('ProfilePicture', file);
  for (const key in userData) {
      formData.append(key, String(userData[key])); 
  }
  const response = await axios.post(registerUrl!, formData);
  console.log(response) ;
  if (response.data) {
    localStorage.setItem("user", JSON.stringify(response.data));
  }
  return response.data;
};

const login = async(userData:IloginData) => {
    const response = await axios.post(loginUrl!,userData,{ withCredentials: true } ) ;
    if(response.data){
      localStorage.setItem('loginData',JSON.stringify(response.data)) ;
    }
    return response.data ;
}

const authServices = {
  register,
  login,
};

export default authServices;
