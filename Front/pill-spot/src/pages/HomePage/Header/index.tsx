import { FiSearch } from "react-icons/fi";
import { PiPillFill } from "react-icons/pi";
import InfoOptions from "./Info";

import HomeCart from "./cart";
import WishList from "./WishList";

const HomeHeader = () => {
  return (
    <>
      <div className="container flex items-center justify-between p-5 text-2xl gap-15">
        <div
          id="Logo"
          className="w-full flex-1 text-3xl font-bold flex items-center gap-2"
        >
          <PiPillFill />
          Pill Spot
        </div>
        <div
          id="SearchHomeMain"
          className="mx-5 hidden sm:flex justify-center flex-4 items-center"
        >
          <div className="relative w-full max-w-3xl">
            <input
              type="text"
              placeholder="Search"
              className="w-full  placeholder:text-black border-0 bg-gray-100 shadow-sm focus:border-gray-400 outline-none rounded-2xl indent-6 h-11 pr-12"
            />
            <FiSearch className="absolute right-4 top-1/2 transform -translate-y-1/2 text-gray-500" />
          </div>
        </div>
        <div id="info" className="flex-2 w-full">
          <InfoOptions />
        </div>
        <div id="cart&wishlist" className="flex-1 flex items-center">
          <HomeCart />
          <WishList />
        </div>
      </div>
    </>
  );
};

export default HomeHeader;
