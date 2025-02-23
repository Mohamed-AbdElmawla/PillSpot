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
    FirstName: string;
    LastName: string;
    UserName: string;
    Email: string;
    PhoneNumber: string;
    Password: string;
    ConfirmPassword: string;
    DateOfBirth: string;
    Gender: string;
    ProfilePicture:string ;
  }

export interface IloginData{
    userName : string ; 
    password : string ;
}  

export interface IState {
    user : ISignUpData | null | string ; 
    isError : boolean ; 
    isSuccess : boolean ;
    isLoading : boolean ; 
    message : string ; 
}
