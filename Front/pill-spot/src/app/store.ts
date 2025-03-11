import { configureStore } from "@reduxjs/toolkit";
import authSlice from "../features/auth/auth";
import uploadPhotoSlice from "../features/uploadPhoto/upload";
import  toastSlice  from "../features/Toasts/toastSlice";
import  authLoginSlice  from "../features/auth/authLogin";
import  pharmacyRegisterSlice  from "../features/Pharmacy/Register/PharmacyRegisterSlice";
import  RequestAddPharmacySlice  from "../features/Pharmacy/Register/PharmacyRequestToBack";
import { loadState, saveState } from "./sessionStorageHelper"

const preloadedState = loadState();

export const store = configureStore({
  reducer: {
    auth: authSlice,
    imgaeUploadSlice: uploadPhotoSlice,
    toastSlice : toastSlice ,
    authLogin : authLoginSlice,
    pharRegister : pharmacyRegisterSlice ,
    requestPharmacyAdd : RequestAddPharmacySlice ,
  },
  preloadedState,
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({
      serializableCheck: false,
    }),
});


store.subscribe(() => {
  saveState(store.getState());
});


export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
