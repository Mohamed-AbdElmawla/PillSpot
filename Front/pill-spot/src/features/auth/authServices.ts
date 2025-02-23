import axios from "axios";
import { ISignUpData } from "../../components/SignUpModel/types";

// od not forget the local host at the beggining
const API_URL = "https://localhost:7298/api/authentication";
//  const FakeAPI_URL = "https://jsonplaceholder.typicode.com/users";

const register = async (userData: ISignUpData) => {


  
  const formData = new FormData();
  const file =  new File([], "empty.jpg", { type: "image/png" });
  formData.append('ProfilePicture', file);
  for (const key in userData) {
      formData.append(key, String(userData[key])); 
  }
  const response = await axios.post(API_URL, formData);
  console.log(response) ;
  if (!response.data) {
    localStorage.setItem("user", JSON.stringify(response.data));
  }
  return response.data;
};

const authServices = {
  register,
};

export default authServices;
