import { createAsyncThunk, createSlice , PayloadAction } from "@reduxjs/toolkit";
import PharmacyServices from "./RegisterService";
import { AxiosError } from "axios";

export interface IUser {
  Name: string;
  ContactNumber: string;
  LicenseId: string;
  PharmacistLicense: File | null;
  AdditionalInfo: string;
  OpeningTime: string;
  ClosingTime: string;
  IsOpen24: boolean;
  DaysOpen: string;
  Longitude: string;
  Latitude: string;
  logo: File | null;
  CityName: string;
  GovernmentName : string ;
}

interface IInitialState {
  user: IUser | null;
  isError: boolean;
  isSuccess: boolean;
  isLoading: boolean;
  message: string;
}

const initialState: IInitialState = {
  user: null,
  isError: false,
  isSuccess: false,
  isLoading: false,
  message: "",
};

export const SendPharmacyRegisterRequest = createAsyncThunk(
  "/pharmacyRegister",
  async (user: IUser, thunkAPI) => {
    try {
        return await PharmacyServices.registerPharmacy(user) ;
    }catch (err) {
        if (err instanceof AxiosError) {
          const message =
            (err.response && err.response.data && err.response.data.message) ||
            err.message ||
            err.toString();
          return thunkAPI.rejectWithValue(message);
        }
        return thunkAPI.rejectWithValue("An unknown error occurred");
      }
  }
);

// we will need to add reducer to clear the pharmacy data after register
export const RequestAddPharmacySlice = createSlice({
    name : 'requestPharmacyAdd' , 
    initialState , 
    reducers:{
        resetPharmacyRequest : (state)=> {
            state.user = null ;
            state.isError=false ;
            state.isLoading = false ; 
            state.isSuccess = false ; 
            state.message = "" ;  
        }
    },
    extraReducers : (builder) => {
        builder
        .addCase(SendPharmacyRegisterRequest.pending , (state)=>{
            state.isLoading = true ; 
        })
        .addCase(SendPharmacyRegisterRequest.fulfilled,(state,action:PayloadAction<IUser>)=>{
            state.user = action.payload ;
            state.isLoading = false ; 
            state.isSuccess = true ; 
        })
        .addCase(SendPharmacyRegisterRequest.rejected,(state,action)=>{
            state.isLoading = false;
            state.isError = true;
            state.message = (action.payload as string) || "An error occurred";
            state.user = null;
        })
    }

}) ; 

export const {resetPharmacyRequest} = RequestAddPharmacySlice.actions ; 
export default RequestAddPharmacySlice.reducer ;