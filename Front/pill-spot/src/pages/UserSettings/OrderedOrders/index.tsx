import { useState } from "react";
import img from "../MainPage/images/image copy 5.png"
import { MdOutlineDoneAll } from "react-icons/md";
import { TbTruckReturn } from "react-icons/tb";
import { TbProgressCheck } from "react-icons/tb";
import OneOrderItem from "./OneOrderedItem";
import { Pagination } from "antd";

const UserOrderedOrders = () => {
  const [activePage, setActivePage] = useState(1);

  const notActive = "bg-blue-50 text-[#02457A]";
  const active = "bg-[#02457A] text-white";

  return (
    <div className="flex flex-col w-full h-full min-h-screen my-auto">
      <div className="flex flex-col md:flex-row w-full h-full">
        <div className="flex-1 card rounded-box grid grow place-items-center my-auto h-full px-4 py-6 md:py-0">
          <div className="flex flex-col w-full items-center justify-center gap-6 sm:gap-8 md:gap-10 ">
            <button
              className={`${
                activePage === 1 ? active : notActive
              } group relative flex rounded-tl-2xl rounded-br-2xl w-full max-w-xs h-28 sm:h-32 md:h-40 
                    items-center justify-center p-3 overflow-hidden hover:scale-105 cursor-pointer
                    hover:text-white hover:bg-[#02457A] duration-200`}
              onClick={() => {
                setActivePage(1);
              }}
            >
              <TbProgressCheck className="text-6xl sm:text-7xl md:text-9xl absolute left-1/2 transform -translate-x-1/2 transition-all duration-300 group-hover:left-20" />
              <span className="font-bold absolute opacity-0 transition-opacity duration-300 text-base sm:text-lg md:text-xl group-hover:opacity-100 group-hover:left-34 ml-3">
                In Progress
              </span>
            </button>

            <button
              className={`${
                activePage === 2 ? active : notActive
              } group relative flex rounded-tl-2xl rounded-br-2xl w-full max-w-xs h-28 sm:h-32 md:h-40 
                    items-center justify-center p-3 overflow-hidden hover:scale-105 cursor-pointer
                    hover:text-white hover:bg-[#02457A] duration-200`}
              onClick={() => {
                setActivePage(2);
              }}
            >
              <MdOutlineDoneAll className="text-6xl sm:text-7xl md:text-9xl absolute left-1/2 transform -translate-x-1/2 transition-all duration-300 group-hover:left-20" />
              <span className="font-bold absolute opacity-0 transition-opacity duration-300 text-base sm:text-lg md:text-xl group-hover:opacity-100 group-hover:left-34">
                Complete
              </span>
            </button>

            <button
              className={`${
                activePage === 3 ? active : notActive
              } group relative flex rounded-tl-2xl rounded-br-2xl w-full max-w-xs h-28 sm:h-32 md:h-40 
                    items-center justify-center p-3 overflow-hidden hover:scale-105 cursor-pointer
                    hover:text-white hover:bg-[#02457A] duration-200`}
              onClick={() => {
                setActivePage(3);
              }}
            >
              <TbTruckReturn className="text-6xl sm:text-7xl md:text-9xl absolute left-1/2 transform -translate-x-1/2 transition-all duration-300 group-hover:left-20" />
              <span className="font-bold absolute opacity-0 transition-opacity duration-300 text-base sm:text-lg md:text-xl group-hover:opacity-100 group-hover:left-44">
                Return
              </span>
            </button>
          </div>
        </div>

        <div className="divider divider-horizontal md:block hidden"></div>
        <div className="flex-[4] w-full md:w-auto">
          <div className="grid grid-cols-1 sm:grid-cols-1 md:grid-cols-2 h-[83vh] overflow-y-scroll auto-rows-min gap-x-5 gap-y-5 card rounded-box p-5 rounded-2xl"
            style={{
              backgroundImage: `url(${img})`,
              backgroundRepeat: "no-repeat",
              backgroundSize: "cover",
              backgroundPosition: "center",
            }}
          >
            <OneOrderItem />
            <OneOrderItem />
            <OneOrderItem />
            <OneOrderItem />
            <OneOrderItem />
            <OneOrderItem />
            <OneOrderItem />
            <OneOrderItem />
            <OneOrderItem />
            <OneOrderItem />
          </div>
          <div className="mt-3">
            <Pagination align="center" defaultCurrent={1} total={50} />
          </div>
        </div>
      </div>
    </div>
  );
};

export default UserOrderedOrders;