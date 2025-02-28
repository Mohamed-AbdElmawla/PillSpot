import bk from "../../assets/image.png";
import { IoIosArrowForward } from "react-icons/io";
import { IoIosArrowBack } from "react-icons/io";
import { ChangeEvent, useState } from "react";
import { iconMap, secondPage } from "./common";
import FirstPage from "./FirstPage";
import PharPic from "./PicturePage";
import Map from "./SecondPage";
import TimeDetails from "./ThirdPage";
import { useDispatch, useSelector } from "react-redux";
import { setTimingInfo } from "../../features/RegisterPharmacy/PharmacyRegisterSlice";
import { RootState } from "../../app/store";




const RegPharmacy = () => {
  const [curPage, setCurPage] = useState(1);
  const [additionalInfo,setAddInfo] = useState(''); 

  const PharData = useSelector((state:RootState)=>state.pharRegister) ; 
  const newData = {...PharData , AdditionalInfo : additionalInfo} ;
  const dispatch = useDispatch() ;
  dispatch(setTimingInfo(newData));

  function handleChange(e: ChangeEvent<HTMLTextAreaElement>){
      setAddInfo(e.target.value) ;
  }
  console.log(additionalInfo) ;

  function handleNext() {
    if (curPage === 4) return;
    setCurPage(curPage + 1);
  }

  function handleBack() {
    if (curPage === 1) return;
    setCurPage(curPage - 1);
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
      </div>
    </div>
  ));



  const pages = [<FirstPage />, <PharPic />, secondPageRender, <TimeDetails/>];
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
                  <IoIosArrowBack /> Back
                </button>
                <button
                  className="text-gray-500 text-3xl font-bold flex items-center justify-center gap-2 cursor-pointer hover:text-black duration-200"
                  onClick={handleNext}
                >
                  Next <IoIosArrowForward />
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
