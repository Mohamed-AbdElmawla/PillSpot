import { createSlice } from "@reduxjs/toolkit"


interface IInitialStase {
    richColors  : boolean
}

const initialState : IInitialStase = {
    richColors : false ,
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
        }
        
    }
}) ;

export const {setColor,clearColor} = toastSlice.actions ;
export default toastSlice.reducer ;