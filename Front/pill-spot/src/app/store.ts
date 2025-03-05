import { configureStore } from "@reduxjs/toolkit";
import authSlice from "../features/auth/auth";
import uploadPhotoSlice from "../features/uploadPhoto/upload";
import  toastSlice  from "../features/Toasts/toastSlice";
import  authLoginSlice  from "../features/auth/authLogin";

export const store = configureStore({
  reducer: {
    auth: authSlice,
    imgaeUploadSlice: uploadPhotoSlice,
    toastSlice : toastSlice ,
    authLogin : authLoginSlice,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({
      serializableCheck: false,
    }),
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
