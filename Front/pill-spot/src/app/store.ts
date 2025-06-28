import { configureStore } from "@reduxjs/toolkit";
import authSlice from "../features/auth/auth";
import uploadPhotoSlice from "../features/uploadPhoto/upload";
import  toastSlice  from "../features/Toasts/toastSlice";
import  authLoginSlice  from "../features/auth/authLogin";
import  pharmacyRegisterSlice  from "../features/Pharmacy/Register/PharmacyRegisterSlice";
import  RequestAddPharmacySlice  from "../features/Pharmacy/Register/PharmacyRequestToBack";
import { loadState, saveState } from "./sessionStorageHelper"
import GetUserPharmcsSlice from "../features/Pharmacy/CRUD/UserPharmaciesSlice/GetUserPharmcsSlice";
import  fetchCurrentPharmacy  from "../features/Pharmacy/CRUD/UserPharmaciesSlice/CurPharmacy";
import  FetchInventoryDataSlice  from "../features/Pharmacy/AddInventoryProduct/AddInventoryProductSlice";
import HomeData from "../features/HomePage/Products/fetchProdcuts"
import UsersInfoSclice  from "../features/User/UserSlcie";
import  notificationSlice  from "../features/Notifications/notificationSlice";

const preloadedState = loadState();

export const store = configureStore({
  reducer: {
    auth: authSlice,
    imgaeUploadSlice: uploadPhotoSlice,
    toastSlice : toastSlice ,
    authLogin : authLoginSlice,
    pharRegister : pharmacyRegisterSlice ,
    requestPharmacyAdd : RequestAddPharmacySlice ,
    getUserPharmacies : GetUserPharmcsSlice ,
    currentPharmacy : fetchCurrentPharmacy ,
    FetchInventoryDataSlice : FetchInventoryDataSlice,
    fetchHomeProductSlice : HomeData ,
    CurUserSlice : UsersInfoSclice ,
    notifications : notificationSlice,
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
