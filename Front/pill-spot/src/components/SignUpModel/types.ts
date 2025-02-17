export interface Iprops{
    buttonText : string ; 
}

export interface InputData{
    title? : string ; 
    name : string ; 
    placeHolder : string ; 
    icon : string ;
    type : string ; 
}

export interface ISignUpData {
    [key: string]: string;
    firstName : string ; 
    lastName : string ; 
    userName : string ; 
    email : string ; 
    phoneNumber : string ; 
    password : string ; 
    confirmPassword : string ; 
    age : string ; 
    accountImage : string ; 
    birthDate : string ; 
    gender : string ; 
}