import { createSlice, PayloadAction } from "@reduxjs/toolkit"


interface IInitialStase {
    richColors  : boolean , 
    loginState  : number , 
    signUpState : number ,
}

const initialState : IInitialStase = {
    richColors : false ,
    loginState : 0 , 
    signUpState: 0 
}


export const toastSlice = createSlice({
    name :'toastSlice' , 
    initialState,
    reducers:{
        setColor : (state) =>{
            state.richColors = true ;
        },
        clearColor : (state)=>{
            state.richColors = false ;
        },
        setLoginState : (state,action:PayloadAction<boolean>)=>{
            if(action) state.loginState = 1 ; 
            else state.loginState = 2 ;
        },
        setSignupState : (state,action:PayloadAction<boolean>)=>{
            if(action) state.signUpState = 1 ; 
            else state.signUpState = 2 ;
        }, 
        resetToast : (state)=>{
            state.loginState = 0 ; 
            state.signUpState = 0 ;
        }
        
    }
}) ;

export const {setColor,clearColor,setLoginState,setSignupState,resetToast} = toastSlice.actions ;
export default toastSlice.reducer ;