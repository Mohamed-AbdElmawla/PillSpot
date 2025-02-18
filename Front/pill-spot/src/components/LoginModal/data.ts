import { IcomponentData, IlgoinData } from "./types";

export const emptyLoginData : IlgoinData = {

    userName: "" , 
    password: "" 
}


export const defaultErrorMsgs : IlgoinData = {
    userName : "" ,
    password : ""
}


export const inputArr : IcomponentData[] = [
    { 
        placeHolder : "User Name" , 
        type : "text" , 
        icon : "username.svg",
        name : "userName"
    },
    {
        placeHolder : "Password" , 
        type : "password" , 
        icon : "pass.svg",
        name : "password"
    },
    

]