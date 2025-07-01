import { useDispatch, useSelector } from "react-redux";
import { setMainInfo } from "../../../features/Pharmacy/Register/PharmacyRegisterSlice";
import { RootState } from "../../../app/store";
import { useForm } from "react-hook-form";
import { useEffect } from "react";

interface Idata {
  Name: string;
  ContactNumber: string;
  LicenseId: string;
  PharmacistLicense: File | null;
}

const initialData: Idata = {
  Name: "",
  ContactNumber: "",
  LicenseId: "",
  PharmacistLicense: null,
};

const MAX_FILE_SIZE_MB = 1;
const ALLOWED_FILE_TYPES = ["application/pdf", "image/jpeg", "image/png"];

const FirstPage = () => {
  const dispatch = useDispatch();
  const RegData = useSelector((state: RootState) => state.pharRegister);

  const {
    register,
    setValue,
    watch,
    formState: { errors },
  } = useForm<Idata>({
    defaultValues: {
      ...initialData,
      ...RegData,
    },
  });

  // Watch all fields and update Redux on change
  const watched = watch();
  useEffect(() => {
    dispatch(setMainInfo({ ...RegData, ...watched }));
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [watched]);

  // File input validation and handling
  function handleFileChange(e: React.ChangeEvent<HTMLInputElement>) {
    const file = e.target.files?.[0] || null;
    if (file) {
      if (file.size > MAX_FILE_SIZE_MB * 1024 * 1024) {
        setValue("PharmacistLicense", null);
        alert(`File size must be less than ${MAX_FILE_SIZE_MB}MB.`);
        return;
      }
      if (!ALLOWED_FILE_TYPES.includes(file.type)) {
        setValue("PharmacistLicense", null);
        alert("Invalid file type. Only PDF, JPG, and PNG allowed.");
        return;
      }
      setValue("PharmacistLicense", file);
    } else {
      setValue("PharmacistLicense", null);
    }
  }

  return (
    <form className="space-y-6 w-lg px-2">
      {/* Name */}
      <div>
        <label htmlFor="Name" className="block text-gray-500 mb-2 ml-2 font-bold">
          Pharmacy Name
        </label>
        <input
          id="Name"
          type="text"
          className="h-12 w-full border indent-5 border-gray-400 rounded-2xl pl-2 pr-2 placeholder:font-bold outline-none focus:border-gray-700 text-gray-500 text-base font-bold"
          placeholder="Pharmacy Name"
          {...register("Name", { required: "Pharmacy Name is required" })}
        />
        {errors.Name && <span className="text-red-500 text-sm font-semibold block mt-1 w-full">{errors.Name.message}</span>}
      </div>
      {/* Contact Number */}
      <div>
        <label htmlFor="ContactNumber" className="block text-gray-500 mb-2 ml-2 font-bold">
          Phone Number
        </label>
        <input
          id="ContactNumber"
          type="text"
          className="h-12 w-full border indent-5 border-gray-400 rounded-2xl pl-2 pr-2 placeholder:font-bold outline-none focus:border-gray-700 text-gray-500 text-base font-bold"
          placeholder="Pharmacy Phone Number"
          {...register("ContactNumber", {
            required: "Phone number is required",
            pattern: {
              value: /^\d{10,15}$/,
              message: "Invalid contact number. It should be 10-15 digits.",
            },
          })}
        />
        {errors.ContactNumber && <span className="text-red-500 text-sm font-semibold block mt-1 w-full">{errors.ContactNumber.message}</span>}
      </div>
      {/* License ID */}
      <div>
        <label htmlFor="LicenseId" className="block text-gray-500 mb-2 ml-2 font-bold">
          License Number
        </label>
        <input
          id="LicenseId"
          type="text"
          className="h-12 w-full border indent-5 border-gray-400 rounded-2xl pl-2 pr-2 placeholder:font-bold outline-none focus:border-gray-700 text-gray-500 text-base font-bold"
          placeholder="License Number"
          {...register("LicenseId", { required: "License Number is required" })}
        />
        {errors.LicenseId && <span className="text-red-500 text-sm font-semibold block mt-1 w-full">{errors.LicenseId.message}</span>}
      </div>
      {/* Pharmacist License File */}
      <div>
        <label htmlFor="PharmacistLicense" className="block text-gray-500 mb-2 ml-2 font-bold">
          License Document
        </label>
        <fieldset className="fieldset">
          <input
            id="PharmacistLicense"
            type="file"
            className="file-input rounded-2xl w-full focus:outline-none focus:border-gray-300 px-2"
            accept=".pdf,.jpg,.jpeg,.png"
            onChange={handleFileChange}
            aria-label="Upload Pharmacist License"
          />
          <label className="fieldset-label">Max size 1MB. Allowed: PDF, JPG, PNG</label>
          {errors.PharmacistLicense && (
            <span className="text-red-500 text-sm font-semibold block mt-1 w-full">
              {errors.PharmacistLicense.message as string}
            </span>
          )}
        </fieldset>
      </div>
    </form>
  );
};

export default FirstPage;
