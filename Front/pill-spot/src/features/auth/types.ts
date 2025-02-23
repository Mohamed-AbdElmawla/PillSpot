import { ISignUpData } from "../../components/SignUpModel/types";

export interface IinitialState{
    user : ISignUpData | null | string ; 
    isError : boolean ; 
    isSuccess : boolean ;
    isLoading : boolean ; 
    message : string ; 
}