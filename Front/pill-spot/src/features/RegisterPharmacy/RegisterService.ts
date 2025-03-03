import axios from "axios";

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
  // const formData = new FormData();

  // Object.entries(data).forEach(([key, value]) => {
  //   if (key === "files" && Array.isArray(value)) {
  //     value.forEach((file, index) => {
  //       formData.append(`files[${index}]`, file);
  //     });
  //   } else {
  //     formData.append(key, value as string | Blob);
  //   }
  // });
  // const locationData: Record<string, string> = {}; 

  // const formData = new FormData();
  
  // Object.entries(data).forEach(([key, value]) => {
  //   if (["Longitude", "Latitude", "CityName", "AdditionalInfo", "GovernmentName"].includes(key)) {
  //     locationData[key] = key === "Longitude" || key === "Latitude" ? parseFloat(value as string) : value; // Convert Longitude & Latitude to double
  //   } else if (key === "files" && Array.isArray(value)) {
  //     value.forEach((file, index) => {
  //       formData.append(`files[${index}]`, file);
  //     });
  //   } else {
  //     formData.append(key, value as string | Blob);
  //   }
  // });
  
  // // Append the `Location` object as a JSON string
  // formData.append("Location", JSON.stringify(locationData));
  

  // // Append the `Location` object as a JSON string
  // formData.append("Location", JSON.stringify(locationData));


  const formData = new FormData();

// Append primitive fields
formData.append("Name", data.Name);
formData.append("ContactNumber", data.ContactNumber);
formData.append("LicenseId", data.LicenseId);
formData.append("OpeningTime", data.OpeningTime);
formData.append("ClosingTime", data.ClosingTime);
formData.append("DaysOpen", data.DaysOpen);

// Convert boolean to a string manually if the backend expects it
formData.append("IsOpen24", data.IsOpen24 ? "true" : "false");

// Append files correctly
if (data.PharmacistLicense instanceof File) {
  formData.append("PharmacistLicense", data.PharmacistLicense);
}
if (data.logo instanceof File) {
  formData.append("logo", data.logo);
}

// Append location as separate fields (to avoid JSON parsing issues)
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

  const response = await axios.post(
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
