interface IInitialState {
    Name: string;
    ContactNumber: string;
    LicenseId: string;
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

  export interface IValidationErrors {
    [key: string]: { required?: string; invalid?: string }; // Separate required and invalid errors
  }
  
  export function validatePharmacyData(data: IInitialState): IValidationErrors {
    const errors: IValidationErrors = {};
  
    if (!data.Name.trim()) errors.Name = { required: "Name is required." };
  
    if (!data.ContactNumber.trim()) {
      errors.ContactNumber = { required: "Contact number is required." };
    } else if (!/^\d{10,15}$/.test(data.ContactNumber)) {
      errors.ContactNumber = { invalid: "Invalid contact number. It should be 10-15 digits." };
    }
  
    if (!data.LicenseId.trim()) errors.LicenseId = { required: "License ID is required." };
  
    if (!data.PharmacistLicense) errors.PharmacistLicense = { required: "Pharmacist License is required." };
  
    if (!data.AdditionalInfo.trim()) errors.AdditionalInfo = { required: "Additional info is required." };
  
    if (!data.OpeningTime.trim()) {
      errors.OpeningTime = { required: "Opening time is required." };
    } else if (!/^\d{2}:\d{2}$/.test(data.OpeningTime)) {
      errors.OpeningTime = { invalid: "Invalid format. Use HH:MM (e.g., 09:30)." };
    }
  
    if (!data.ClosingTime.trim()) {
      errors.ClosingTime = { required: "Closing time is required." };
    } else if (!/^\d{2}:\d{2}$/.test(data.ClosingTime)) {
      errors.ClosingTime = { invalid: "Invalid format. Use HH:MM (e.g., 21:00)." };
    }
  
    if (data.IsOpen24 === undefined) {
      errors.IsOpen24 = { required: "IsOpen24 must be true or false." };
    }
  
    if (!data.Longitude.trim()) {
      errors.Longitude = { required: "Longitude is required." };
    } else if (!/^(-?\d+(\.\d+)?)$/.test(data.Longitude)) {
      errors.Longitude = { invalid: "Invalid longitude. Must be a valid number." };
    }
  
    if (!data.Latitude.trim()) {
      errors.Latitude = { required: "Latitude is required." };
    } else if (!/^(-?\d+(\.\d+)?)$/.test(data.Latitude)) {
      errors.Latitude = { invalid: "Invalid latitude. Must be a valid number." };
    }
  
    if (!data.logo) errors.logo = { required: "Logo is required." };
  
    if (!data.DaysOpen.trim()) errors.DaysOpen = { required: "Days Open is required." };
  
    if (!data.CityName.trim()) errors.CityName = { required: "City Name is required." };
  
    return errors;
  }
  