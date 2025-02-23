import { createSlice , PayloadAction } from "@reduxjs/toolkit";


interface IInitialState{
    profilePicture : File | null ;
}

const initialState : IInitialState = {
    profilePicture : null ,
}

export const uploadPhotoSlice = createSlice({
    name : 'imgaeUploadSlice' , 
    initialState , 
    reducers:{
        setProfilePicture : (state , action : PayloadAction<File | null>) =>{
            state.profilePicture = action.payload ;
        } , 
        clearProfilePicture : (state)=>{
            state.profilePicture = null ;
        }
    },
    
})

export const {setProfilePicture,clearProfilePicture} = uploadPhotoSlice.actions ;
export default uploadPhotoSlice.reducer ;