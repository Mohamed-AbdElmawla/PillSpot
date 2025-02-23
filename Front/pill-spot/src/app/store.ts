import { configureStore } from "@reduxjs/toolkit";
import authSlice from "../features/auth/auth";
import uploadPhotoSlice from "../features/uploadPhoto/upload";
import  toastSlice  from "../features/Toasts/toastSlice";

export const store = configureStore({
  reducer: {
    auth: authSlice,
    imgaeUploadSlice: uploadPhotoSlice,
    toastSlice : toastSlice ,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({
      serializableCheck: false,
    }),
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
