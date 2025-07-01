import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";

import authServices from "./authServices";
import { IloginData } from "../../components/SignUpModel/types";
import { AxiosError } from "axios";
import axiosInstance from "../../app/axiosInstance";


// const storedUser = localStorage.getItem("user");
// const user: string | null = storedUser ? JSON.parse(storedUser) : null;

// interface curUser {
//   firstName: string,
//   lastName: string ,
//   email: string,
//   userName: string ,
//   phoneNumber: string,
//   profilePictureUrl: string,
//   dateOfBirth: string,
//   gender: string ,
// }

// const emptyUser : curUser = {

//     firstName: "",
//     lastName:  "",
//     email: "",
//     userName: "" ,
//     phoneNumber: "",
//     profilePictureUrl:"" ,
//     dateOfBirth:"" ,
//     gender: "" ,
  
// }

interface IinitialState{
    userLogin : string | null ; 
    isErrorLogin : boolean ; 
    isSuccessLogin : boolean ;
    isLoadingLogin : boolean ;
    isAuthenticated: boolean, 
    messageLogin : string ; 
}


const initialState: IinitialState = {
  userLogin: null,
  isErrorLogin: false,
  isSuccessLogin: false,
  isLoadingLogin: false,
  isAuthenticated: false,
  messageLogin: "",

};



// export const loginUser = createAsyncThunk('auth/login', async (credentials, { rejectWithValue }) => {
//   try {
//     const response = await axiosInstance.post('/auth/login', credentials);
//     return response.data; // Assume API sets the token in HTTP cookies
//   } catch (error) {
//     return rejectWithValue(error.response?.data || 'Login failed');
//   }
// });

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

export const checkAuth = createAsyncThunk('auth/checkAuth', async (userName : string|null, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.get(`${import.meta.env.VITE_BASE_URL}api/users/${userName}`); // API should return user info if token is valid
    console.log(response.data);
    return response.data;
  } catch (error) {
    if (error instanceof AxiosError) {
      return rejectWithValue(error.response?.data || 'Not authenticated');
    }
    return rejectWithValue('An unknown error occurred');
  }
});



export const logout = createAsyncThunk(
  "auth/logout",
  async (_,thunkAPI) => {
    console.log("iam in serve") ;
    try {
      return await authServices.logout();
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

export const deleteAccount = createAsyncThunk(
  "auth/delete-user-account",
  async (userName:string,thunkAPI) => {
    try {
      return await authServices.deleteAccount(userName);
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
    logoutUser: (state) => {
      console.log(document.cookie) // the token is empty before remove it 
      // document.cookie = 'AccessToken=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;'; // Remove cookie
      state.userLogin = null;
      state.isAuthenticated = false;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(login.pending, (state) => {
        state.isLoadingLogin = true;
      })
      .addCase(
        login.fulfilled,
        (state, action) => {
          state.isLoadingLogin = false;
          state.isSuccessLogin = true;
          state.isAuthenticated = true;
          state.userLogin = String(action.payload);
          console.log(action.payload)
        }
      )
      .addCase(login.rejected, (state, action) => {
        state.isLoadingLogin = false;
        state.isErrorLogin = true;
        state.messageLogin = (action.payload as string) || "An error occurred";
        state.userLogin = null;
      })

      .addCase(logout.pending, (state) => {
        state.isLoadingLogin = true;
      })
      .addCase(
        logout.fulfilled,
        (state) => {
          state.isLoadingLogin = false;
          state.isSuccessLogin = false;
          state.userLogin = null;
        }
      )
      .addCase(logout.rejected, (state, action) => {
        state.isLoadingLogin = false;
        state.isErrorLogin = true;
        state.messageLogin = (action.payload as string) || "An error occurred";
      })

      .addCase(checkAuth.pending, (state) => {
        state.isLoadingLogin = true;
        state.isSuccessLogin = false ;
      })
      .addCase(checkAuth.fulfilled, (state, action) => {
        state.userLogin = action.payload.userName;
        state.isAuthenticated = true;
        state.isSuccessLogin = false ;
      })
      .addCase(checkAuth.rejected, (state) => {
        state.userLogin = null;
        state.isSuccessLogin = false ;
        state.isAuthenticated = false;
        state.isErrorLogin = false;
      });

      

  },
});

export const { resetLogin , logoutUser } = authLoginSlice.actions;

export default authLoginSlice.reducer;
