import { AiOutlineHome } from "react-icons/ai";
import { LuUser } from "react-icons/lu";
import { MdOutlineShoppingBag } from "react-icons/md";
import { GoChecklist } from "react-icons/go";
import { BsGear } from "react-icons/bs";
import { BsCapsule } from "react-icons/bs";
import { MdOutlineLogout } from "react-icons/md";
import { IoMenu } from "react-icons/io5";



import "./style.css";
import { NavLink } from "react-router-dom";

const UserSettingSider = () => {
  return (
    <>
    <div className="flex flex-col justify-around  items-center h-screen ">
      <div> 
          <IoMenu className="text-4xl text-blue-600" />
       </div>
      <div className="flex flex-col gap-10 items-center">
        <NavLink to={"page1"} className="text-4xl ">
          <AiOutlineHome />
        </NavLink>
        <NavLink to={"page2"} className="text-4xl  ">
          <LuUser />
        </NavLink>
        <NavLink to={"page3"} className="text-4xl  ">
          <MdOutlineShoppingBag />
        </NavLink>
        <NavLink to={"page4"} className="text-4xl ">
          <GoChecklist />
        </NavLink>
        <NavLink to={"page5"} className="text-4xl ">
          <BsGear />
        </NavLink>
        <NavLink to={"page6"} className="text-4xl ">
          <BsCapsule />
        </NavLink>
      </div>

      <div>
        <NavLink to={"/homepage"} className="text-4xl">
          <MdOutlineLogout />
        </NavLink>
      </div>
    </div>
    </>
  );
};

export default UserSettingSider;
