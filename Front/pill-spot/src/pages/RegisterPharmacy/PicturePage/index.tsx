import ImageUpload from "../../../UI/ImageUpload";
import { IoMdAddCircle } from "react-icons/io";

import { setLogo } from "../../../features/Pharmacy/Register/PharmacyRegisterSlice";
import { RootState } from "../../../app/store";
import { useDispatch, useSelector } from "react-redux";
import { useEffect } from "react";



const PharPic = () => {
  const photo = useSelector((state: RootState) => state.imgaeUploadSlice.profilePicture);
  const dispatch = useDispatch();

  useEffect(() => {
    if (photo) {
      dispatch(setLogo(photo));
    }
  }, [photo, dispatch]);

  function handleIconClick() {
    const elem = document.getElementById("avatar-upload");
    if (elem) {
      elem.click();
    }
  }

  return (
    <div className="flex items-end relative">
      {photo ? (
        <img
          src={typeof photo === "string" ? photo : URL.createObjectURL(photo)}
          alt="Profile Preview"
          className="w-80 h-80 rounded-full object-cover border border-gray-300"
        />
      ) : (
        <ImageUpload width="w-80 h-80" />
      )}
      
      <IoMdAddCircle
        className="text-5xl text-blue-400 absolute right-10 bottom-7 hover:scale-110 duration-300 hover:cursor-pointer"
        onClick={handleIconClick}
      />
    </div>
  );
};

export default PharPic;