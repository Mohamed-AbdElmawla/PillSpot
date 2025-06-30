// import axios from "axios";
import { ISignUpData, IloginData } from "../../components/SignUpModel/types";
import axiosInstance from "../axiosInstance";

// import { labelGrid } from "react-day-picker";

// od not forget the local host at the beggining
// const registerUrl = import.meta.env.VITE_REGISTER_URL;
// const loginUrl = import.meta.env.VITE_LOGIN_URL;

//  const FakeAPI_URL = "https://jsonplaceholder.typicode.com/users";

const register = async (userData: ISignUpData | FormData) => {
  console.log(userData) ;

  // const formData = new FormData();
  // const file = new File([], "empty.jpg", { type: "image/png" });
  // formData.append("ProfilePicture", file);

  // // const userFile = input.files[0];

  // // if (userFile) {
  // //   const fileName = userFile.name;
  // //   const fileType = userFile.type;

  // //   // You can now append it directly to FormData
  // //   const formData = new FormData();
  // //   formData.append("ProfilePicture", userFile, fileName);

  // //   // Optional: show info
  // //   console.log("Uploading file:", fileName, "Type:", fileType);
  // // }



  // for (const key in userData) {
  //   formData.append(key, String(userData[key]));
  // }
  const response = await axiosInstance.post("api/authentication", userData);
  console.log(response);
  if (response.data) {
    localStorage.setItem("user", JSON.stringify(response.data));
  }
  return response.data;
};

const login = async (userData: IloginData) => {
  // const response = await axios.post(loginUrl!, userData, {
  //   withCredentials: true,
  // });
  console.log(userData)
  const response = await axiosInstance.post("api/authentication/login",userData) ;
  if (response.data) return userData.userName;
};

const logout = async()=>{
  console.log("iam in s erve") ;
  const response = await axiosInstance.post(
    "api/authentication/logout" , {

      withCredentials: true,
    }
  );
  return response.data ;
}

const deleteAccount = async (userName:string)=> {
  const response = await axiosInstance.delete(`api/users/${userName}`,{withCredentials:true});
  return response.data ;
}

const authServices = {
  register,
  login,
  logout,
  deleteAccount, 
};

export default authServices;
