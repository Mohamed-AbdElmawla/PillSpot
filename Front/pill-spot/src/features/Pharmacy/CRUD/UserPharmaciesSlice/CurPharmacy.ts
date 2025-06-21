import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import { AxiosError } from "axios";
import axiosInstance from "../../../axiosInstance";

interface Pharmacy {
  name: string;
  logo: File | null; 
  contactNumber: string;
  openingTime: string; 
  closingTime: string; 
  isOpen24: boolean;
  daysOpen: string;
  logoURL:string;
  pharmacyId : string 
}

interface CurrentPharmacyState {
  pharmacy: Pharmacy | null;
  loading: boolean;
  error: string | null;
}

const initialState: CurrentPharmacyState = {
  pharmacy: null,
  loading: false,
  error: null,
};


export const fetchCurrentPharmacy = createAsyncThunk(
  "pharmacy/fetchCurrentPharmacy",
  async (pharmacyId: string | undefined, thunkAPI) => {
    try {
      const response = await axiosInstance.get(
        `api/pharmacies/${pharmacyId}`,
        { withCredentials: true }
      );
      console.log(response.data)
      return response.data;
    } catch (err) {
      if (err instanceof AxiosError) {
        const message =
          err.response?.data?.message || err.message || "Unknown error";
        return thunkAPI.rejectWithValue(message);
      }
      return thunkAPI.rejectWithValue("An unknown error occurred");
    }
  }
);


export const updateCurrentPharmacy = createAsyncThunk(
  "pharmacy/updateCurrentPharmacy",
  async ({ pharmacyId, data }: { pharmacyId: string | undefined ; data : FormData }, thunkAPI) => {
    try {
    //   const formData = new FormData();
    //   formData.append("name", data.name);
    //   if (data.logo) formData.append("logo", data.logo); 
    //   formData.append("contactNumber", data.contactNumber);
    //   formData.append("openingTime", data.openingTime);
    //   formData.append("closingTime", data.closingTime);
    //   formData.append("isOpen24", String(data.isOpen24));
    //   formData.append("daysOpen", data.daysOpen);

      const response = await axiosInstance.put(
        `api/pharmacies/${pharmacyId}`,
        data,
        { headers: { "Content-Type": "multipart/form-data" }, withCredentials: true }
      );
      return response.data;
    } catch (err) {
      if (err instanceof AxiosError) {
        const message =
          err.response?.data?.message || err.message || "Unknown error";
        return thunkAPI.rejectWithValue(message);
      }
      return thunkAPI.rejectWithValue("An unknown error occurred");
    }
  }
);

const currentPharmacySlice = createSlice({
  name: "currentPharmacy",
  initialState,
  reducers: {
    clearCurrentPharmacy: (state) => {
      state.pharmacy = null;
      state.error = null;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(fetchCurrentPharmacy.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(fetchCurrentPharmacy.fulfilled, (state, action) => {
        state.loading = false;
        state.pharmacy = action.payload;
      })
      .addCase(fetchCurrentPharmacy.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload as string;
      })
      .addCase(updateCurrentPharmacy.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(updateCurrentPharmacy.fulfilled, (state) => {
        state.loading = false;
        // state.pharmacy = action.payload;
      })
      .addCase(updateCurrentPharmacy.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload as string;
      });
  },
});

export const { clearCurrentPharmacy } = currentPharmacySlice.actions;
export default currentPharmacySlice.reducer;
