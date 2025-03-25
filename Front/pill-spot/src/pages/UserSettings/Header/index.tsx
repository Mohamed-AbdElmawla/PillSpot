import LogoSVG from "../../../UI/LogoSVG";
import { BiSearchAlt } from "react-icons/bi";
// import { IoNotificationsOutline } from "react-icons/io5";
import NotificationDrawer from "../../../components/Notification";

const UserSettingHeader = () => {
  return (
    <div className="bg-white w-full flex justify-between ">
      <div className="flex items-center gap-3">
        <LogoSVG w="45" h="45" />
        <span className="text-2xl font-bold text-[#02457A] font-logo">
          Pill Spot
        </span>
      </div>
      <div className="flex items-center gap-10">
        <input
          type="search"
          className="w-40 h-10 rounded-full px-5 border-0 bg-gray-100"
          placeholder="Search..."
        />
        <BiSearchAlt className="text-3xl text-[#02457A]" />
        <NotificationDrawer/>
        {/* <IoNotificationsOutline className="text-3xl text-[#02457A]" /> */}
        <img src="/src/pages/UserSettings/MainPage/images/455280085_515769004150965_1822829626503930280_n.jpg" className="w-20 rounded-full" alt="" />
      </div>
    </div>
  );
};

export default UserSettingHeader;
