import { createSlice, PayloadAction } from "@reduxjs/toolkit";

interface IInitialState {
  Name: string;
  ContactNumber: string;
  LicenseId: string;
  PharmacistLicense: File | null;
  AdditionalInfo: string;
  OpeningTime: string;
  ClosingTime: string;
  IsOpen24: boolean;
  DaysOpen : string ,
  Longitude: string;
  Latitude: string;
  logo : File | null ;
  CityName:string , 
  GovernmentName:string ,
  [key: string]: string | boolean | File | null;
}

const initialState: IInitialState = {
  Name: "",
  ContactNumber: "",
  LicenseId: "",
  PharmacistLicense: null,
  AdditionalInfo: "",
  OpeningTime: "",
  ClosingTime: "",
  IsOpen24: false,
  Longitude: "",
  Latitude: "",
  logo:null ,
  DaysOpen : "" ,
  CityName : "" , 
  GovernmentName:"",
  
};

export const pharmacyRegisterSlice = createSlice({
  name: "pharmacyRegisterSlice",
  initialState,
  reducers: {
    setMainInfo(state, action: PayloadAction<IInitialState>) {
      Object.assign(state, action.payload);
    },
    setLogo(state,action: PayloadAction<File>){
        state.logo = action.payload ;
    },
    setLocationInfo(state,action: PayloadAction<IInitialState>){
        Object.assign(state, action.payload);
    },
    setTimingInfo(state,action: PayloadAction<IInitialState>){
        Object.assign(state, action.payload);
    },
    resetPharmacyForm(state) {
      Object.assign(state, initialState);
    }
  },
});

export const {setMainInfo,setLogo,setLocationInfo,setTimingInfo, resetPharmacyForm} = pharmacyRegisterSlice.actions ;
export default pharmacyRegisterSlice.reducer ;