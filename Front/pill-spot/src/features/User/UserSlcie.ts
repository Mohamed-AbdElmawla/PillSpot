import { createAsyncThunk, createSlice, PayloadAction } from "@reduxjs/toolkit";
import { emptyUser, IcurUser, IeditUser } from "./types";
import userServices from "./UserServices";
import { AxiosError } from "axios";

interface IinitialState {
  isLoading: boolean;
  error: boolean;
  message: string;
  curUser: IcurUser;
}

const initialState: IinitialState = {
  isLoading: false,
  error: false,
  message: "",
  curUser: emptyUser,
};

export const getCurUser = createAsyncThunk(
  "users/curUser",
  async (userName: string, thunkAPI) => {
    try {
      return await userServices.fetchCurUser(userName);
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

export const editCurUser = createAsyncThunk(
  "users/editcurUser",
  async (
    {
      curUser,
      userImage,
      userName,
    }: { curUser: IeditUser; userImage: File | null; userName: string },
    thunkAPI
  ) => {
    try {
      return await userServices.editUserInfo(curUser, userImage, userName);
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

export const editCurUserPassword = createAsyncThunk(
  "users/editcurUserPassword",
  async (
    newPassword : {
      oldPassword: string;
      newPassword: string;
      confirmPassword: string;
      userName : string ;
    },
    thunkAPI
  ) => {
    try {
      return await userServices.editUserPassword(newPassword);
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

export const UsersInfoSclice = createSlice({
  name: "CurUserSlice",
  initialState,
  reducers: {
    resetCurUser: (state) => {
      state.isLoading = false;
      state.error = false;
      state.message = "";
      state.curUser = emptyUser;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(getCurUser.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(
        getCurUser.fulfilled,
        (state, action: PayloadAction<IcurUser>) => {
          state.isLoading = false;
          state.error = false;
          state.message = "cur user set";
          state.curUser = action.payload;
        }
      )
      .addCase(getCurUser.rejected, (state, action) => {
        state.isLoading = false;
        state.error = true;
        state.message = (action.payload as string) || "An error occurred";
        state.curUser = emptyUser;
      })
      .addCase(editCurUser.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(editCurUser.fulfilled, (state) => {
        state.isLoading = false;
        state.error = false;
        state.message = "User data updated successfully";
      })
      .addCase(editCurUser.rejected, (state, action) => {
        state.isLoading = false;
        state.error = true;
        state.message = (action.payload as string) || "An error occurred";
      })
      .addCase(editCurUserPassword.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(editCurUserPassword.fulfilled, (state) => {
        state.isLoading = false;
        state.error = false;
        state.message = "User data updated successfully";
      })
      .addCase(editCurUserPassword.rejected, (state, action) => {
        state.isLoading = false;
        state.error = true;
        state.message = (action.payload as string) || "An error occurred";
      });
  },
});

export const { resetCurUser } = UsersInfoSclice.actions;
export default UsersInfoSclice.reducer;
