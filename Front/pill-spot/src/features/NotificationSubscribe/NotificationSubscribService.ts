
import axiosInstance from '../axiosInstance';

export interface NotificationPreferencePayload {
  isEnabled: boolean;
  notificationTypes: string[];
}

export async function subscribeToProductAvailability(productId: string, payload: NotificationPreferencePayload) {
  const response = await axiosInstance.post(`/api/ProductNotificationPreference/product/${productId}`, payload);
  return response.data;
}
