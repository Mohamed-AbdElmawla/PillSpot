import { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { setProfilePicture } from "../../features/uploadPhoto/upload";
import { RootState } from "../../app/store";

interface Iprops{
  width? : string ;
}

const ImageUpload = ({width}:Iprops) => {
  const [preview, setPreview] = useState<string | null>(null);
  const dispatch = useDispatch();
  const imgae = useSelector(
    (state: RootState) => state.imgaeUploadSlice.profilePicture
  );

  const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    if (file) {
      const imageUrl = URL.createObjectURL(file);
      setPreview(imageUrl);
      dispatch(setProfilePicture(file));
    } else if (imgae !== null) {
      const imageUrl = URL.createObjectURL(imgae);
      setPreview(imageUrl);
    }
  };

  const usedWidth = (width)?width:" w-50 h-50" ;

  return (
    <div>
      <div className="flex flex-col items-center gap-4 relative">
        <label
          htmlFor="avatar-upload"
          className={`mb-5 rounded-full border-2 border-gray-300 flex items-center justify-center cursor-pointer overflow-hidden bg-gray-100 relative ${usedWidth}`}
        >
          {preview ? (
            <img
              src={preview}
              alt="Avatar"
              className="w-full h-full object-cover"
            />
          ) : (
            <span className="text-gray-400">Upload</span>
          )}
          <div
            className={`absolute bottom-3 
          right-6 w-8 h-8
           bg-blue-500 text-white
            flex items-center justify-center 
            rounded-full border-2 border-white shadow-lg z-10
            duration-200
            hover:bg-blue-300 
            hover:text-black
            
            `}
          >
            +
          </div>
        </label>
        <input
          id="avatar-upload"
          type="file"
          accept="image/*"
          className="hidden"
          onChange={handleFileChange}
        />
      </div>
    </div>
  );
};

export default ImageUpload;
