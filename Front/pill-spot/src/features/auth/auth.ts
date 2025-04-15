import { createAsyncThunk, createSlice, PayloadAction } from "@reduxjs/toolkit";

import { IinitialState } from "./types";
import authServices from "./authServices";
import { ISignUpData } from "../../components/SignUpModel/types";
import { AxiosError } from "axios";

// get user from local storage firlst and check
const storedUser = localStorage.getItem("user");
const user: string | null = storedUser ? JSON.parse(storedUser) : null;

// const emptyInitialState = {
//     isError : false ,
//     isSuccess : false ,
//     isLoading : false ,
//     message : ''
// }

const initialState: IinitialState = {
  user: user,
  isError: false,
  isSuccess: false,
  isLoading: false,
  message: "",
};

// registe user

export const register = createAsyncThunk(
  "auth/register",
  async (user: ISignUpData | FormData, thunkAPI) => {
    try {
      return await authServices.register(user);
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

export const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {
    reset: (state) => {
      state.isError = false;
      state.isLoading = false;
      state.isSuccess = false;
      state.message = "";
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(register.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(
        register.fulfilled,
        (state, action: PayloadAction<ISignUpData>) => {
          state.isLoading = false;
          state.isSuccess = true;
          state.user = action.payload;
        }
      )
      .addCase(register.rejected, (state, action) => {
        state.isLoading = false;
        state.isError = true;
        state.message = (action.payload as string) || "An error occurred";
        state.user = null;
      })
  },
});

export const { reset } = authSlice.actions;

export default authSlice.reducer;
