import axiosInstance from "../../axiosInstance";

interface IInitialState {
  Name: string;
  ContactNumber: string;
  LicenseId: string;
  PharmacistLicense: File | null;
  AdditionalInfo: string;
  OpeningTime: string;
  ClosingTime: string;
  IsOpen24: boolean;
  DaysOpen: string;
  Longitude: string;
  Latitude: string;
  logo: File | null;
  CityName: string;
  GovernmentName: string;
}

const convertToFormData = (data: IInitialState) => {
  const formData = new FormData();

  formData.append("Name", data.Name);
  formData.append("ContactNumber", data.ContactNumber);
  formData.append("LicenseId", data.LicenseId);
  formData.append("OpeningTime", data.OpeningTime);
  formData.append("ClosingTime", data.ClosingTime);
  formData.append("DaysOpen", data.DaysOpen);

  formData.append("IsOpen24", data.IsOpen24 ? "true" : "false");

  if (data.PharmacistLicense instanceof File) {
    formData.append("PharmacistLicense", data.PharmacistLicense);
  }
  if (data.logo instanceof File) {
    formData.append("logo", data.logo);
  }

  formData.append("Location.Longitude", data.Longitude.toString());
  formData.append("Location.Latitude", data.Latitude.toString());
  formData.append("Location.AdditionalInfo", data.AdditionalInfo);
  formData.append("Location.CityName", data.CityName);
  formData.append("Location.GovernmentName", data.GovernmentName);

  return formData;
};

async function registerPharmacy(data: IInitialState) {
  const fromData = convertToFormData(data);
  console.log("The data that will be sent is:");

  for (const [key, value] of fromData.entries()) {
    console.log(key, value);
  }

  const response = await axiosInstance.post(
    import.meta.env.VITE_PHARMACY_REQUEST,
    fromData,
    { withCredentials: true }
  );
  console.log(response);
  return response.data;
}

const PharmacyServices = {
  registerPharmacy,
};

export default PharmacyServices;
