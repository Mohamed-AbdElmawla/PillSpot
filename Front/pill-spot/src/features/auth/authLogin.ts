import { createAsyncThunk, createSlice, PayloadAction } from "@reduxjs/toolkit";

import authServices from "./authServices";
import { IloginData, ISignUpData } from "../../components/SignUpModel/types";
import { AxiosError } from "axios";


const storedUser = localStorage.getItem("user");
const user: string | null = storedUser ? JSON.parse(storedUser) : null;

interface IinitialState{
    userLogin : ISignUpData | null | string ; 
    isErrorLogin : boolean ; 
    isSuccessLogin : boolean ;
    isLoadingLogin : boolean ; 
    messageLogin : string ; 
}

const initialState: IinitialState = {
  userLogin: user,
  isErrorLogin: false,
  isSuccessLogin: false,
  isLoadingLogin: false,
  messageLogin: "",
};





export const login = createAsyncThunk(
  "auth/login",
  async (user: IloginData, thunkAPI) => {
    try {
      return await authServices.login(user);
    } catch (err) {
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

export const authLoginSlice = createSlice({
  name: "authLogin",
  initialState,
  reducers: {
    resetLogin: (state) => {
      state.isErrorLogin = false;
      state.isLoadingLogin = false;
      state.isSuccessLogin = false;
      state.messageLogin = "";
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(login.pending, (state) => {
        state.isLoadingLogin = true;
      })
      .addCase(
        login.fulfilled,
        (state, action: PayloadAction<ISignUpData>) => {
          state.isLoadingLogin = false;
          state.isSuccessLogin = true;
          state.userLogin = action.payload;
        }
      )
      .addCase(login.rejected, (state, action) => {
        state.isLoadingLogin = false;
        state.isErrorLogin = true;
        state.messageLogin = (action.payload as string) || "An error occurred";
        state.userLogin = null;
      });

  },
});

export const { resetLogin } = authLoginSlice.actions;

export default authLoginSlice.reducer;
