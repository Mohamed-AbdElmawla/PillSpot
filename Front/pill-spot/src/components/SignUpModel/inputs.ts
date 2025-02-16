import { InputData } from "./types";


export const inputArr : InputData[] = [
    { 
        placeHolder : "User Name" , 
        type : "text" , 
        icon : "username.svg",
        name : "username"
    },
    {
        title : "Email" , 
        placeHolder : "Email" , 
        type : "text" , 
        icon : "email.svg",
        name : "email"
    },
    {
        placeHolder : "Phone Number" , 
        type : "text" , 
        icon : "phone.svg",
        name : "phoneNumber"
    },
    {
        placeHolder : "Password" , 
        type : "password" , 
        icon : "pass.svg",
        name : "password"
    },
    {
        placeHolder : "Confirm Password" , 
        type : "password" , 
        icon : "confirmpass.svg",
        name : "confirmpassword"
    },
    {
        placeHolder : "Age" , 
        type : "text" , 
        icon : "age.svg",
        name : "age"
    },
    {
        placeHolder : "Account Image" , 
        type : "accImage" , 
        icon : "accImage.svg",
        name : "accImage"
    },
    {
        type : "date" , 
        icon : "birth.svg",
        name : "birth",
        placeHolder : "",
    },

]