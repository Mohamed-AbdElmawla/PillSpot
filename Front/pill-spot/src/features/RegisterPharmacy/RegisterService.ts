import axios from "axios";

interface IInitialState {
    Name: string;
    ContactNumber: string;
    LicenseID: string;
    PharmacistLicense: File | null;
    AdditionalInfo: string;
    OpeningTime: string;
    ClosingTime: string;
    IsOpen24: boolean;
    DaysOpen : string ,
    Longitude: string;
    Latitude: string;
    logo : File | null ;
    CityName:string , 
  }
  

  const convertToFormData = (data: IInitialState) => {
    const formData = new FormData();
  
    Object.entries(data).forEach(([key, value]) => {
      if (key === "files" && Array.isArray(value)) {
        value.forEach((file, index) => {
          formData.append(`files[${index}]`, file);
        });
      } else {
        formData.append(key, value as string | Blob);
      }
    });
  
    return formData;
  };

async function registerPharmacy(data:IInitialState) {


  const fromData = convertToFormData(data)
  console.log("The data that will be sent is:");

for (const [key, value] of fromData.entries()) {
  console.log(key, value);
}

  const response = await axios.post(
    import.meta.env.VITE_PHARMACY_REQUEST,
    fromData,
    { withCredentials: true }
  );
  console.log(response) ;
  return response.data;
}


const PharmacyServices = {
  registerPharmacy
}

export default PharmacyServices ;