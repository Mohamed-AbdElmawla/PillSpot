import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";

interface IMedicine {
  quantity: number;
  productDto: {
    productId: string;
    subCategoryDto: null | object;
    name: string;
    description: string;
    price: number;
    imageURL: string;
    createdDate: string;
  };
  pharmacyDto: {
    pharmacyId: string;
    name: string;
    logoURL: string;
    logo: null | string;
    locationDto: null | object;
    contactNumber: string;
    openingTime: string;
    closingTime: string;
    isOpen24: boolean;
    daysOpen: string;
  };
}

interface IinitialState {
  inventoryData: IMedicine[];
  isLoading: boolean;
  error: string;
}

const intialState: IinitialState = {
  inventoryData: [],
  isLoading: false,
  error: "",
};

export const FetchInventoryData = createAsyncThunk(
  "/fetchInventory",
  async (data: string | undefined, thunkAPI) => {
    try {
      const response = await axios.get(
        `https://localhost:7298/api/pharmacyproducts/pharmacy/${data!}/products`
      );
      console.log(response.data);
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

const FetchInventoryDataSlice = createSlice({
  name: "FetchInventoryDataSlice",
  initialState: intialState,
  reducers: {
    ClearInventoryData: (state) => {
      state.inventoryData = [];
      state.error = "";
      state.isLoading = false;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(FetchInventoryData.pending, (state) => {
        state.isLoading = true;
        state.error = "";
      })
      .addCase(FetchInventoryData.fulfilled, (state, action) => {
        state.isLoading = false;
        state.inventoryData = action.payload;
        console.log(state.inventoryData);
      })
      .addCase(FetchInventoryData.rejected, (state, action) => {
        state.isLoading = false;
        state.error = action.payload as string;
      });
  },
});

export const { ClearInventoryData } = FetchInventoryDataSlice.actions;
export default FetchInventoryDataSlice.reducer;
