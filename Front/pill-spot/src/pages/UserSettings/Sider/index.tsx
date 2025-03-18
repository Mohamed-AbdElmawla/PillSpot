import { AiOutlineHome } from "react-icons/ai";
import "./style.css"
import { NavLink } from "react-router-dom";

const UserSettingSider = () => {

    const ButtonStyle = ""


  return (
    <div className="flex flex-col  justify-center items-center h-screen ">
      <div className="flex flex-col gap-10 items-center">
        
        <NavLink to={"#adf"} className="text-4xl text-black"><AiOutlineHome/></NavLink>

      
        <NavLink to={"#asdfa"} className="text-4xl"><AiOutlineHome/></NavLink>
        <NavLink to={"###"} className="text-4xl "><AiOutlineHome/></NavLink>
        <NavLink to={"####"} className="text-4xl "><AiOutlineHome/></NavLink>
        <NavLink to={"#####"} className="text-4xl "><AiOutlineHome/></NavLink>
      </div>
    </div>
  );
};

export default UserSettingSider;
