
import { Dispatch , SetStateAction } from "react";
import { SignUpData } from "../../components/SignUpModel/types";

export interface Iprops {
    name : string ; 
    placeHolder : string ;
    type : string ; 
    title? : string ; 
    icon : string ; 
    setSignUpData : Dispatch<SetStateAction<SignUpData>> ;

}