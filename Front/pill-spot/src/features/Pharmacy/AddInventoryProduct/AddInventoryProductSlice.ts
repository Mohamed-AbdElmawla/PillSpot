import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { AxiosError } from "axios";
import axiosInstance from "../../axiosInstance";

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
      const response = await axiosInstance.get(
        `api/pharmacyproducts/pharmacy/${data!}/products`
      );
      console.log(response.data);
      // Only return quantity, productDto, and pharmacyDto
      const filtered = Array.isArray(response.data)
        ? response.data.map((item) => ({
            quantity: item.quantity,
            productDto: item.productDto,
            pharmacyDto: item.pharmacyDto,
          }))
        : [];
      return filtered;
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

export const UpdateProductQuantity = createAsyncThunk(
  "inventory/updateProductQuantity",
  async (
    {
      pharmacyId,
      productId,
      body,
    }: {
      pharmacyId: string;
      productId: string;
      body: { quantity: number; isAvailable: boolean; minimumStockThreshold: number };
    },
    thunkAPI
  ) => {
    try {
      const response = await axiosInstance.put(
        `api/pharmacyproducts/pharmacy/${pharmacyId}/product/${productId}`,
        body
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
