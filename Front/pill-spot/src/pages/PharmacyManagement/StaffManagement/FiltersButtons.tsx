import { Dispatch, SetStateAction, useState } from "react";

interface Iprops {
  setSelectedStaff: Dispatch<SetStateAction<string>>;
}

const FiltersButtons = ({ setSelectedStaff }: Iprops) => {
  const [isActive, setIsActive] = useState("1"); // 1 all ,
  const activeStyle = "bg-[#ACD9FD] text-white btn rounded-2xl";
  const mainStyle = "btn rounded-2xl text-gray-500";
  return (
    <div className="flex flex-wrap justify-start gap-3 sm:gap-5 w-full mb-10">
      <button 
        onClick={() => {setIsActive("1");setSelectedStaff('1')}}
        className={isActive === "1" ? activeStyle : mainStyle}
      >
        All
      </button>
      <button
        onClick={() => {setIsActive("2");setSelectedStaff('2')}}
        className={isActive === "2" ? activeStyle : mainStyle}
      >
        Pharmacists
      </button>
      <button
        onClick={() => {setIsActive("3");setSelectedStaff('3')}}
        className={isActive === "3" ? activeStyle : mainStyle}
      >
        Inventory & Logistics
      </button>
      <button
        onClick={() => {setIsActive("4");setSelectedStaff('4')}}
        className={isActive === "4" ? activeStyle : mainStyle}
      >
        Administration & Accounting
      </button>
      <button
        onClick={() => {setIsActive("5");setSelectedStaff('5')}}
        className={isActive === "5" ? activeStyle : mainStyle}
      >
        Sales & Customer Service
      </button>
    </div>
  );
};

export default FiltersButtons;
