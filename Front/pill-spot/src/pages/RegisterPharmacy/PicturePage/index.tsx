import ImageUpload from "../../../UI/ImageUpload";
import { IoMdAddCircle } from "react-icons/io";

import { setLogo } from "../../../features/RegisterPharmacy/PharmacyRegisterSlice";
import { RootState } from "../../../app/store";
import { useDispatch, useSelector } from "react-redux";



const PharPic = () => {

  const photo = useSelector((state:RootState)=>state.imgaeUploadSlice.profilePicture) ; 
  const dispatch = useDispatch() ;
  dispatch(setLogo(photo!));


  function handleIconClick() {
    const elem = document.getElementById("avatar-upload");
    if (elem) {
      elem.click();
    }
  }

  return (
    <div className="flex items-end relative">
      <ImageUpload width="w-80 h-80" />
      <IoMdAddCircle
        className="text-5xl text-blue-400 absolute right-10 bottom-7 hover:scale-110 duration-300 hover:cursor-pointer"
        onClick={handleIconClick}
      />
    </div>
  );
};

export default PharPic;
