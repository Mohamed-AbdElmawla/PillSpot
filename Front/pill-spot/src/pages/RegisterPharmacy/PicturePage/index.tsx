import { IoMdAddCircle } from "react-icons/io";
import { setLogo } from "../../../features/Pharmacy/Register/PharmacyRegisterSlice";
import { clearProfilePicture } from "../../../features/uploadPhoto/upload";
import { useDispatch } from "react-redux";
import { useEffect, useRef, useState } from "react";

const MAX_FILE_SIZE_MB = 2;
const ALLOWED_FILE_TYPES = ["image/jpeg", "image/png"];

const PharPic = () => {
  const dispatch = useDispatch();
  const [previewUrl, setPreviewUrl] = useState<string | null>(null);
  const [error, setError] = useState<string>("");
  const fileInputRef = useRef<HTMLInputElement>(null);

  useEffect(() => {
    dispatch(clearProfilePicture());
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  // Clean up preview URL when component unmounts or when previewUrl changes
  useEffect(() => {
    return () => {
      if (previewUrl) {
        URL.revokeObjectURL(previewUrl);
      }
    };
  }, [previewUrl]);

  function handleFileChange(e: React.ChangeEvent<HTMLInputElement>) {
    const file = e.target.files?.[0];
    if (!file) return;
    if (file.size > MAX_FILE_SIZE_MB * 1024 * 1024) {
      setError(`File size must be less than ${MAX_FILE_SIZE_MB}MB.`);
      return;
    }
    if (!ALLOWED_FILE_TYPES.includes(file.type)) {
      setError("Invalid file type. Only JPG and PNG allowed.");
      return;
    }
    setError("");
    // Clean up old preview URL
    if (previewUrl) {
      URL.revokeObjectURL(previewUrl);
    }
    // Set preview immediately
    const url = URL.createObjectURL(file);
    setPreviewUrl(url);
    dispatch(setLogo(file));
  }

  function handleRemovePhoto() {
    if (previewUrl) {
      URL.revokeObjectURL(previewUrl);
    }
    setPreviewUrl(null);
    if (fileInputRef.current) fileInputRef.current.value = "";
  }

  function handleUploadClick() {
    if (fileInputRef.current) fileInputRef.current.click();
  }

  return (
    <div className="flex flex-col items-center gap-4 w-full">
      <div className="relative flex flex-col items-center">
        {previewUrl ? (
          <>
            <img
              src={previewUrl}
              alt="Pharmacy Logo Preview"
              className="w-80 h-80 rounded-full object-cover border-2 border-gray-300 shadow-md"
            />
            <button
              type="button"
              className="mt-2 px-4 py-1 bg-red-500 text-white rounded-lg text-sm font-semibold hover:bg-red-600 transition"
              onClick={handleRemovePhoto}
              aria-label="Remove photo"
            >
              Remove Photo
            </button>
          </>
        ) : (
          <div className="w-80 h-80 flex items-center justify-center rounded-full border-2 border-dashed border-gray-300 bg-gray-50">
            <span className="text-gray-400 text-lg">No Photo Selected</span>
          </div>
        )}
        <input
          type="file"
          accept="image/jpeg,image/png"
          className="hidden"
          ref={fileInputRef}
          onChange={handleFileChange}
        />
        <button
          type="button"
          className="flex items-center gap-2 mt-4 px-6 py-2 bg-blue-500 text-white rounded-xl font-bold hover:bg-blue-600 transition"
          onClick={handleUploadClick}
          aria-label="Upload pharmacy logo"
        >
          <IoMdAddCircle className="text-2xl" />
          {previewUrl ? "Change Photo" : "Upload Photo"}
        </button>
        {error && <span className="text-red-500 text-sm font-semibold block mt-2">{error}</span>}
      </div>
    </div>
  );
};

export default PharPic;