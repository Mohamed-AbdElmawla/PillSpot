import axiosInstance from "../axiosInstance";
import { IeditUser } from "./types";

const fetchCurUser = async (userName: string) => {
  const response = await axiosInstance.get(
    `api/users/${userName}`
  );
  console.log(response.data);
  return response.data;
  
};

const editUserInfo = async (
  userData: IeditUser,
  userImage: File | null,
  userName: string
) => {
  try {
    const formData = new FormData();
    console.log("UserData:", userData);

    Object.entries(userData).forEach(([key, value]) => {
      if (
        value !== undefined &&
        value !== null &&
        key !== "Password" &&
        key !== "NewPassword"
      ) {
        formData.append(key, String(value));
      }
    });

    console.log(Object.fromEntries(formData));
    if (userImage) {
      formData.append("ProfilePicture", userImage);
    }

    const response = await axiosInstance.patch(
      `api/users/${userName}`,
      formData,
      {
        withCredentials: true,
      }
    );

    return response.data;
  } catch (error) {
    console.error("Error editing user info:", error);
    throw error;
  }
};

const editUserPassword = async (newPassword: {
  oldPassword: string;
  newPassword: string;
  confirmPassword: string;
  userName: string;
}) => {
  try {
    const passwordData = {
      oldPassword: newPassword.oldPassword,
      newPassword: newPassword.newPassword,
      confirmPassword: newPassword.confirmPassword,
    };
    console.log(passwordData)
    const response = await axiosInstance.put(
      `api/users/${newPassword.userName}/update-password`,
      passwordData,
      { withCredentials: true }
    );

    return response.data;
  } catch (error) {
    console.error("Error updating password:", error);
    throw error;
  }
};

const userServices = {
  fetchCurUser,
  editUserInfo,
  editUserPassword,
};

export default userServices;
