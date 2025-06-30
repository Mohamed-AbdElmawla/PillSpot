import bk from "../../assets/image.png";
import { IoIosArrowForward } from "react-icons/io";
import { IoIosArrowBack } from "react-icons/io";
import { ChangeEvent, useState, useEffect } from "react";
import { iconMap, secondPage } from "./common";
import FirstPage from "./FirstPage";
import PharPic from "./PicturePage";
import Map from "./SecondPage";
import TimeDetails from "./ThirdPage";
import { useDispatch, useSelector } from "react-redux";
import { setLocationInfo, resetPharmacyForm } from "../../features/Pharmacy/Register/PharmacyRegisterSlice";
import { RootState } from "../../app/store";
import OneInput from "./oneInput";
import { PiCityLight } from "react-icons/pi";
import { IValidationErrors, validatePharmacyData } from "./Validation";
import { MdErrorOutline } from "react-icons/md";
import { toast } from "sonner";
import { setColor } from "../../features/Toasts/toastSlice";
import PharmacyDetailsModal from "./ComfirmationModal";
import { resetPharmacyRequest } from "../../features/Pharmacy/Register/PharmacyRequestToBack";
import { useNavigate } from "react-router-dom";


const RegPharmacy = () => {
  const navigate = useNavigate();
  const [curPage, setCurPage] = useState(1);
  const [openModal,setOpenModal] = useState(false) ;
  const [addressInfo, setaddressInfo] = useState({
    CityName: "",
    AdditionalInfo: "",
  });
  const [errors, setErrors] = useState<IValidationErrors>({
    Name: { required: "", invalid: "" },
    ContactNumber: { required: "", invalid: "" },
    LicenseId: { required: "", invalid: "" },
    AdditionalInfo: { required: "", invalid: "" },
    OpeningTime: { required: "", invalid: "" },
    ClosingTime: { required: "", invalid: "" },
    Longitude: { required: "", invalid: "" },
    Latitude: { required: "", invalid: "" },
    DaysOpen: { required: "", invalid: "" },
    CityName: { required: "", invalid: "" },
  });

  const [showError,setShowError] = useState(false) ;
  
  const PharData = useSelector((state: RootState) => state.pharRegister);
  const dispatch = useDispatch();

  // Reset all pharmacy registration data on mount
  useEffect(() => {
    dispatch(resetPharmacyForm());
    dispatch(resetPharmacyRequest());
    setaddressInfo({ CityName: "", AdditionalInfo: "" });
    setErrors({
      Name: { required: "", invalid: "" },
      ContactNumber: { required: "", invalid: "" },
      LicenseId: { required: "", invalid: "" },
      AdditionalInfo: { required: "", invalid: "" },
      OpeningTime: { required: "", invalid: "" },
      ClosingTime: { required: "", invalid: "" },
      Longitude: { required: "", invalid: "" },
      Latitude: { required: "", invalid: "" },
      DaysOpen: { required: "", invalid: "" },
      CityName: { required: "", invalid: "" },
    });
    setShowError(false);
    setCurPage(1);
    setOpenModal(false);
  }, [dispatch]);

  const newData = { ...PharData, AdditionalInfo: addressInfo.AdditionalInfo };
  dispatch(setLocationInfo(newData));

  function handleChange(
    e: ChangeEvent<HTMLTextAreaElement> | ChangeEvent<HTMLInputElement>
  ) {
    const { name, value } = e.target;
    setaddressInfo((prev) => ({
      ...prev,
      [name]: value,
    }));
  }

  console.log(addressInfo);

  function handleNext() {
    if (curPage === 4) {
      const errorsObj = validatePharmacyData(PharData);
      if (Object.values(errorsObj).some(error => error.required || error.invalid)) {
        setErrors(errorsObj);
        setShowError(true);
        setOpenModal(false);
        dispatch(setColor());
        toast.error("There is errors with data you entered") ;
      } else {
        setOpenModal(true);
        
        // request sent successfully and return to the user settings page

      }
      return;
    }
    setCurPage(curPage + 1);
    setShowError(false) ;
  }
  



  function handleBack() {
    if (curPage === 1) return;
    setCurPage(curPage - 1);
    setShowError(false);
  }

  const secondPageRender = secondPage.map((p) => (
    <div className="mt-5 flex flex-col">
      <div className="relative w-120">
        <div className="absolute left top-3 text-gray-500">
          {iconMap.get(p.name)}
        </div>

        <textarea
          placeholder="Address Additional Information (max-250 words)"
          name={p.name}
          className="border border-gray-400 p-2 pl-10 rounded-t-3xl rounded-bl-3xl w-full placeholder-gray-500 focus:outline-none indent-5 placeholder:pt-2"
          onChange={handleChange}
        />

        {PharData.CityName && PharData.CityName === "Unknown" && (
          <OneInput
            name="CityName"
            title="City Name"
            placeHolder="Please enter city name"
            type="text"
            onChange={handleChange}
          >
            <PiCityLight className="absolute left-5 text-4xl font-bold text-gray-400" />
          </OneInput>
        )}
      </div>
    </div>
  ));

  const errorsRender = Object.entries(errors).map(([field, error]) => (
    <>
    <span key={field} className="text-red-500 text-xl font-bold">
      {error.required && <div className="flex items-center gap-1"><MdErrorOutline className="text-2xl text-red-600 " />{error.required}</div>}
      {error.invalid && <div className="flex items-center gap-1"><MdErrorOutline /> {error.invalid}</div>}
    </span>
    </>
  ));
  
  
 
  

  const pages = [<FirstPage />, <PharPic />, secondPageRender, <TimeDetails />];
  const pagesTitle = [
    <span className="text-xl m-10 font-bold text-gray-600">
      Pharmacy main information
    </span>,
    <span className="text-xl m-10 font-bold text-gray-600">
      Pharmacy Picture
    </span>,
    <span className="text-xl m-10 font-bold text-gray-600">
      Pharmacy address information
    </span>,
    <span className="text-xl m-10 font-bold text-gray-600">
      Pharmacy account password
    </span>,
  ];

  return (
    <div style={{ backgroundImage: `url(${bk})` }}>
      {/* Back Button */}
      <button
        onClick={() => navigate(-1)}
        className="fixed top-6 left-6 z-50 flex items-center gap-2 px-4 py-2 bg-white/80 hover:bg-white rounded-full shadow text-gray-700 font-semibold text-base transition"
        aria-label="Go back"
      >
        <IoIosArrowBack className="text-xl" />
        Back
      </button>
      <div className="container bg-cover bg-center m-auto h-screen flex">
        <div className="flex-[3] flex items-center justify-center flex-col gap-10">
          <span className="text-9xl text-white font-bold">Hello !</span>
          {curPage === 3 && (
            <>
              <span className="text-3xl text-white font-bold">
                Please select your pharmacy location on the map !
              </span>
              <Map />
            </>
          )}

          {
            showError &&(
              
            
              <div className="grid grid-cols-2 bg-white p-10 rounded-2xl gap-5">
               { errorsRender}
              </div>
              )
          }




        </div>
        <div className="flex-2 flex flex-col ">
          <div className="flex-1 flex items-end justify-center">
            <span className="text-5xl text-white m-10">
              Register Pharmacy !
            </span>
          </div>
          <div className="flex-3 bg-white rounded-t-[80px] flex flex-col gap-3 items-center relative  overflow-hidden">
            <div className="mt-5 flex flex-col items-center">
              {pagesTitle[curPage - 1]}
              {pages[curPage - 1]}

              <div className="flex items-center gap-70 mt-20 absolute bottom-15">
                <button
                  className="text-gray-500 text-3xl font-bold flex items-center justify-center gap-2 cursor-pointer hover:text-black duration-200"
                  onClick={handleBack}
                >
                  {curPage !== 1 && (
                    <>
                      <IoIosArrowBack /> Back
                    </>
                  )}
                </button>
                <button
                  className="text-gray-500 text-3xl font-bold flex items-center justify-center gap-2 cursor-pointer hover:text-black duration-200"
                  onClick={handleNext}
                >
                  {curPage === 4 ? (
                    <>
                      {/* Submit <BsSendFill /> */}
                      <PharmacyDetailsModal canOpen={openModal}/>
                    </>
                  ) : (
                    <>
                      Next <IoIosArrowForward />
                    </>
                  )}
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default RegPharmacy;
