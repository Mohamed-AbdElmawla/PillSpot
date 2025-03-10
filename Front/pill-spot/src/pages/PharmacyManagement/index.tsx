
import { Outlet } from "react-router-dom";
import bgImage from "../../assets/image.png"; 
import SidePanel from "./sidePanel";




const PharManagementLayout = () => {

  return (
    <div 
      className="relative w-full min-h-screen bg-gray-900 font-roboto" 
    >

      <div 
        className="absolute inset-0 bg-cover bg-center bg-no-repeat bg-fixed"
        style={{ backgroundImage: `url(${bgImage})` }}
      ></div>
  

      <div className="relative flex flex-row w-full min-h-screen max-w-[2000px] px-4 sm:px-6 lg:px-8 container m-auto ">
        <SidePanel />
  
 
        <div className="card bg-white grid h-227  rounded-3xl m-auto ml-0 w-full max-w-[1400px] p-6 overflow-auto md:overflow-auto">
          
          <Outlet />
        </div>
      </div>
    </div>
  );
  
};

export default PharManagementLayout;
