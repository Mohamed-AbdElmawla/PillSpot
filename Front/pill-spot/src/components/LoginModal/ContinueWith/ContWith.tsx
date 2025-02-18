import { FaGoogle } from "react-icons/fa6";
import { BsMicrosoft } from "react-icons/bs";
import { FaFacebook } from "react-icons/fa6";
import { FaXTwitter } from "react-icons/fa6";
const ContWith = () => {
  return (
    <>
  <div className="flex flex-col items-center my-4">
    <span className="text-gray-500 font-semibold tracking-wide text-sm sm:text-base md:text-lg lg:text-xl">
      OR CONTINUE WITH
    </span>
    <hr className="w-full border-t-2 border-gray-300 mt-2" />
  </div>

  <div className="text-[#02457a] flex justify-center gap-6 sm:gap-8 md:gap-10 mt-4 sm:mt-6">
    <FaGoogle className="hover:scale-130 hover:text-blue-500 transition-transform duration-300 ease-in-out text-3xl sm:text-4xl md:text-5xl" />
    <BsMicrosoft className="hover:scale-130 hover:text-blue-500 transition-transform duration-300 ease-in-out text-3xl sm:text-4xl md:text-5xl" />
    <FaFacebook className="hover:scale-130 hover:text-blue-500 transition-transform duration-300 ease-in-out text-3xl sm:text-4xl md:text-5xl" />
    <FaXTwitter className="hover:scale-130 hover:text-blue-500 transition-transform duration-300 ease-in-out text-3xl sm:text-4xl md:text-5xl" />
  </div>
</>
  );
};

export default ContWith;
