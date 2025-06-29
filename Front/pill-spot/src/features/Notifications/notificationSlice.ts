import { createSlice, createAsyncThunk, PayloadAction } from "@reduxjs/toolkit";
import {
  fetchNotifications,
  deleteNotification,
  markNotificationAsRead,
  markAllNotificationsAsRead,
  getUnreadNotificationCount,
  getUnreadNotifications,
  getNotificationById,
  getProductNotificationPreference,
  getAllNotificationPreferences,
  createProductNotificationPreference,
  updateProductNotificationPreference,
  deleteProductNotificationPreference,
} from "./NotificaitonsServics";

// Define the notification type (adjust fields as needed)
export interface Notification {
    notificationId: string;
    userId: string;
    actorId: string | null;
    title: string;
    message: string;
    content: string;
    type: string;
    data: string;
    relatedEntityId: string | null;
    relatedEntityType: string | null;
    isRead: boolean;
    isNotified: boolean;
    isBroadcast: boolean;
    isDeleted: boolean;
    createdDate: string;
    notifiedDate: string | null;
    modifiedDate: string | null;
    avatarUrl?: string;
}


export interface NotificationPreference {
    preferenceId: string;
    userId: string;
    productId: string;
    pharmacyId: string | null;
    pharmacyName: string | null;
    productName: string;
    isEnabled: boolean;
    notificationTypes: string[];
    createdAt: string;
    lastNotifiedAt: string | null;
}

interface NotificationState {
    notifications: Notification[];
    isLoading: boolean;
    isError: boolean;
    errorMessage: string;
    unreadCount: number;
    preferences: NotificationPreference[];
}

const initialState: NotificationState = {
    notifications: [],
    isLoading: false,
    isError: false,
    errorMessage: "",
    unreadCount: 0,
    preferences: [],
};

export const getNotifications = createAsyncThunk<
    Notification[],
    boolean,
    { rejectValue: string }
>(
    "notifications/getNotifications",
    async (isRead:boolean, thunkAPI) => {
        try {
            const data = await fetchNotifications(isRead);
            return data;
        } catch (error: unknown) {
            let message = "Failed to fetch notifications";
            if (error instanceof Error) {
                message = error.message;
            }
            return thunkAPI.rejectWithValue(message);
        }
    }
);

export const deleteNotificationThunk = createAsyncThunk (
    "notifications/deleteNotification",
    async (id:string, thunkAPI) => {
        try {
            await deleteNotification(id);
            return id;
        } catch (error: unknown) {
            let message = "Failed to delete notification";
            if (error instanceof Error) message = error.message;
            return thunkAPI.rejectWithValue(message);
        }
    }
);

export const markNotificationAsReadThunk = createAsyncThunk(
    "notifications/markNotificationAsRead",
    async (id:string, thunkAPI) => {
        try {
            return await markNotificationAsRead(id);
        } catch (error: unknown) {
            let message = "Failed to mark notification as read";
            if (error instanceof Error) message = error.message;
            return thunkAPI.rejectWithValue(message);
        }
    }
);

export const markAllNotificationsAsReadThunk = createAsyncThunk(
    "notifications/markAllNotificationsAsRead",
    async (_, thunkAPI) => {
        try {
            return await markAllNotificationsAsRead();
        } catch (error: unknown) {
            let message = "Failed to mark all notifications as read";
            if (error instanceof Error) message = error.message;
            return thunkAPI.rejectWithValue(message);
        }
    }
);

export const getUnreadNotificationCountThunk = createAsyncThunk(
    "notifications/getUnreadNotificationCount",
    async (_, thunkAPI) => {
        try {
            return await getUnreadNotificationCount();
        } catch (error: unknown) {
            let message = "Failed to get unread notification count";
            if (error instanceof Error) message = error.message;
            return thunkAPI.rejectWithValue(message);
        }
    }
);

export const getUnreadNotificationsThunk = createAsyncThunk(
    "notifications/getUnreadNotifications",
    async (_, thunkAPI) => {
        try {
            return await getUnreadNotifications();
        } catch (error: unknown) {
            let message = "Failed to get unread notifications";
            if (error instanceof Error) message = error.message;
            return thunkAPI.rejectWithValue(message);
        }
    }
);

export const getNotificationByIdThunk = createAsyncThunk<
    Notification,
    string,
    { rejectValue: string }
>(
    "notifications/getNotificationById",
    async (id, thunkAPI) => {
        try {
            return await getNotificationById(id);
        } catch (error: unknown) {
            let message = "Failed to get notification by id";
            if (error instanceof Error) message = error.message;
            return thunkAPI.rejectWithValue(message);
        }
    }
);



////////////////////////////////////////////////////////////////////////////////  ProducPreference

export const getProductNotificationPreferenceThunk = createAsyncThunk<
    unknown,
    string,
    { rejectValue: string }
>(
    "notifications/getProductNotificationPreference",
    async (productId, thunkAPI) => {
        try {
            return await getProductNotificationPreference(productId);
        } catch (error: unknown) {
            let message = "Failed to get product notification preference";
            if (error instanceof Error) message = error.message;
            return thunkAPI.rejectWithValue(message);
        }
    }
);

export const getAllNotificationPreferencesThunk = createAsyncThunk<
    NotificationPreference[],
    void,
    { rejectValue: string }
>(
    "notifications/getAllNotificationPreferences",
    async (_, thunkAPI) => {
        try {
            return await getAllNotificationPreferences();
        } catch (error: unknown) {
            let message = "Failed to get all notification preferences";
            if (error instanceof Error) message = error.message;
            return thunkAPI.rejectWithValue(message);
        }
    }
);

export const createProductNotificationPreferenceThunk = createAsyncThunk<
    unknown,
    { productId: string; body: { isEnabled: boolean; notificationTypes: string[] } },
    { rejectValue: string }
>(
    "notifications/createProductNotificationPreference",
    async ({ productId, body }, thunkAPI) => {
        try {
            return await createProductNotificationPreference(productId, body);
        } catch (error: unknown) {
            let message = "Failed to create product notification preference";
            if (error instanceof Error) message = error.message;
            return thunkAPI.rejectWithValue(message);
        }
    }
);

export const updateProductNotificationPreferenceThunk = createAsyncThunk<
    unknown,
    { productId: string; body: { isEnabled: boolean; notificationTypes: string[] } },
    { rejectValue: string }
>(
    "notifications/updateProductNotificationPreference",
    async ({ productId, body }, thunkAPI) => {
        try {
            return await updateProductNotificationPreference(productId, body);
        } catch (error: unknown) {
            let message = "Failed to update product notification preference";
            if (error instanceof Error) message = error.message;
            return thunkAPI.rejectWithValue(message);
        }
    }
);

export const deleteProductNotificationPreferenceThunk = createAsyncThunk<
    string,
    string,
    { rejectValue: string }
>(
    "notifications/deleteProductNotificationPreference",
    async (productId, thunkAPI) => {
        try {
            await deleteProductNotificationPreference(productId);
            return productId;
        } catch (error: unknown) {
            let message = "Failed to delete product notification preference";
            if (error instanceof Error) message = error.message;
            return thunkAPI.rejectWithValue(message);
        }
    }
);

export const notificationSlice = createSlice({
    name: "notifications",
    initialState,
    reducers: {
        clearNotifications: (state) => {
            state.notifications = [];
            state.isError = false;
            state.errorMessage = "";
        },
        addNotification: (state, action: PayloadAction<Notification>) => {
            // Avoid duplicates
            if (!state.notifications.some(n => n.notificationId === action.payload.notificationId)) {
                state.notifications = [action.payload, ...state.notifications];
            }
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(getNotifications.pending, (state) => {
                state.isLoading = true;
                state.isError = false;
                state.errorMessage = "";
            })
            .addCase(getNotifications.fulfilled, (state, action: PayloadAction<Notification[]>) => {
                state.isLoading = false;
                state.notifications = action.payload;
            })
            .addCase(getNotifications.rejected, (state, action) => {
                state.isLoading = false;
                state.isError = true;
                state.errorMessage = action.payload || "Failed to fetch notifications";
            })
            .addCase(markAllNotificationsAsReadThunk.fulfilled, (state) => {
                state.notifications = state.notifications.map(n => ({
                    ...n,
                    isRead: true
                }));
            })
            .addCase(getUnreadNotificationCountThunk.fulfilled, (state, action) => {
                state.unreadCount = action.payload;
            })
            .addCase(getAllNotificationPreferencesThunk.pending, (state) => {
                state.isLoading = true;
                state.isError = false;
                state.errorMessage = "";
            })
            .addCase(getAllNotificationPreferencesThunk.fulfilled, (state, action) => {
                state.isLoading = false;
                state.preferences = action.payload;
            })
            .addCase(getAllNotificationPreferencesThunk.rejected, (state, action) => {
                state.isLoading = false;
                state.isError = true;
                state.errorMessage = action.payload || "Failed to get all notification preferences";
            })
            .addCase(updateProductNotificationPreferenceThunk.pending, (state) => {
                state.isLoading = true;
                state.isError = false;
                state.errorMessage = "";
            })
            .addCase(updateProductNotificationPreferenceThunk.fulfilled, (state, action) => {
                state.isLoading = false;
                const updatedPref = action.payload as NotificationPreference;
                if (updatedPref && updatedPref.productId) {
                    const idx = state.preferences.findIndex(p => p.productId === updatedPref.productId);
                    if (idx !== -1) {
                        state.preferences[idx] = { ...state.preferences[idx], ...updatedPref };
                    }
                }
            })
            .addCase(updateProductNotificationPreferenceThunk.rejected, (state, action) => {
                state.isLoading = false;
                state.isError = true;
                state.errorMessage = action.payload || "Failed to update product notification preference";
            })
            .addCase(deleteProductNotificationPreferenceThunk.pending, (state) => {
                state.isLoading = true;
                state.isError = false;
                state.errorMessage = "";
            })
            .addCase(deleteProductNotificationPreferenceThunk.fulfilled, (state, action) => {
                state.isLoading = false;
                state.preferences = state.preferences.filter(p => p.productId !== action.payload);
            })
            .addCase(deleteProductNotificationPreferenceThunk.rejected, (state, action) => {
                state.isLoading = false;
                state.isError = true;
                state.errorMessage = action.payload || "Failed to delete product notification preference";
            });
    },
});

export const { clearNotifications, addNotification } = notificationSlice.actions;
export default notificationSlice.reducer;
