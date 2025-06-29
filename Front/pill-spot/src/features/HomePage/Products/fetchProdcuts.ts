import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { AxiosError } from "axios";
import axiosInstance from "../../axiosInstance";


interface IProduct {
  quantity: number;
  productDto: {
    productId: string;
    subCategoryDto: null;
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
    logo: null;
    locationDto: null;
    contactNumber: string;
    openingTime: string;
    closingTime: string;
    isOpen24: false;
    daysOpen: string;
  };
}

interface ICategory {
  name: string;
  categoryId: string;
}

interface IInitialState {
  Products: IProduct[] | null;
  Categories: ICategory[] | null;
  LoadingProducts: boolean;
  LoadingCategories: boolean;
  Error: string;
}

interface IData {
  PageNumber: string;
  PageSize: string;
  Name?: string;
}

const initialState: IInitialState = {
  Error: "",
  LoadingProducts: false,
  LoadingCategories: false,
  Products: null,
  Categories: null,
};

export const FetchHomeProducts = createAsyncThunk(
  "/fetchHomeProducts",
  async (data: IData, thunkAPI) => {
    try {
      let url = `api/pharmacyproducts?PageNumber=${data.PageNumber}&PageSize=${data.PageSize}`;
      if (data.Name) {
        url += `&searchterm=${encodeURIComponent(data.Name)}`;
      }
      const response = await axiosInstance.get(url);
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

export const FetchHomeCategory = createAsyncThunk(
  "/fetchHomeCategory",
  async () => {
    try {
      const response = await axiosInstance.get("api/categories");
      return response.data;
    } catch (err) {
      if (err instanceof AxiosError) {
        const message =
          err.response?.data?.message || err.message || "Unknown error";
        return message;
      }
      return "An unknown error occurred";
    }
  }
);

const HomeData = createSlice({
  name: "fetchHomeProductSlice",
  initialState,
  reducers: {
    clearHomeProduct(state) {
      state.Error = "";
      state.LoadingProducts = false;
      state.LoadingCategories = false;
      state.Products = null;
      state.Categories = null;
    },
  },
  extraReducers: (builder) => {
    builder
      // FetchHomeProducts cases
      .addCase(FetchHomeProducts.pending, (state) => {
        state.Error = "";
        state.LoadingProducts = true;
        state.Products = null;
      })
      .addCase(FetchHomeProducts.fulfilled, (state, action) => {
        state.Error = "";
        state.LoadingProducts = false;
        state.Products = action.payload;
      })
      .addCase(FetchHomeProducts.rejected, (state) => {
        state.Error = "There is an error";
        state.LoadingProducts = false;
        state.Products = null;
      })

      // FetchHomeCategory cases
      .addCase(FetchHomeCategory.pending, (state) => {
        state.Error = "";
        state.LoadingCategories = true;
        state.Categories = null;
      })
      .addCase(FetchHomeCategory.fulfilled, (state, action) => {
        state.Error = "";
        state.LoadingCategories = false;
        state.Categories = action.payload;
      })
      .addCase(FetchHomeCategory.rejected, (state) => {
        state.Error = "There is an error";
        state.LoadingCategories = false;
        state.Categories = null;
      });
  },
});

export const { clearHomeProduct } = HomeData.actions;
export default HomeData.reducer;
