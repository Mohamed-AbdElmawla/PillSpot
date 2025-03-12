import { IoCart } from "react-icons/io5";
import OneSide from "./OneSide";
import { LuUsersRound } from "react-icons/lu";
import { FaUserTie } from "react-icons/fa";
import { useNavigate } from "react-router-dom";



const SideBar = () => {
  const navigate = useNavigate() ;
  return (
    <div className="flex container flex-col items-start justify-between cursor-pointer"  onClick={()=>navigate('/pharmacymanagement/pharmananalytics')}>
      <OneSide name="Orders This Week" data="2500" color="bg-blue-200">
        <IoCart className="text-4xl" />
      </OneSide>

      <OneSide name="Total Customers" data="2500" color="bg-green-200">
        <LuUsersRound className="text-4xl" />
      </OneSide>

      <OneSide name="Total Staff" data="2500" color="bg-orange-200">
        <FaUserTie className="text-4xl hover:cursor-pointer" />
      </OneSide>
    </div>
  );
};

export default SideBar;
