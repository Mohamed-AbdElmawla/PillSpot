import { MdOutlineInventory2 } from "react-icons/md";
import { TiHomeOutline } from "react-icons/ti";
import { MdOutlineShoppingCart } from "react-icons/md";
import { IoPeopleOutline } from "react-icons/io5";
import { FaChartSimple } from "react-icons/fa6";
import { MdOutlineLogout } from "react-icons/md";
import { PiPillLight } from "react-icons/pi";
import PharManagemetDetails from "./PharDetails";
import ButtenLink from "./ButtonLink";
import { Outlet, useNavigate } from "react-router-dom";
import bgImage from "../../assets/image.png"; 
import { toast } from "sonner";

const PharManagementLayout = () => {
  const navigate = useNavigate();
  const mainColor = "text-cyan-500";
  return (
    <div
      className="flex flex-row w-full h-screen max-w-[8000px] px-4 sm:px-6 lg:px-8 container m-auto bg-cover bg-center bg-no-repeat bg-fixed"
      style={{ backgroundImage: `url(${bgImage})` }}
    >
      <div className="card  rounded-box grid h-227 place-items-center flex-1 m-auto">
        <div className="flex flex-col justify-between h-10/12 text-2xl list-none items-center">
          <PharManagemetDetails
            imgSrc="https://img.daisyui.com/images/profile/demo/2@94.webp"
            name="El Pharmacy"
            email="Elpharmacy@gail.com"
          />

          <div className="flex flex-col gap-4">
            <ButtenLink
              pageURL="pharmanhome"
              title="Home"
              mainColor={mainColor}
            >
              <TiHomeOutline className="text-4xl" />
            </ButtenLink>

            <ButtenLink
              pageURL="pharmaninventory"
              title="Inventory Management"
              mainColor={mainColor}
            >
              <MdOutlineInventory2 className="text-4xl" />
            </ButtenLink>

            <ButtenLink
              pageURL="pharmanorders"
              title="Orders Management"
              mainColor={mainColor}
            >
              <MdOutlineShoppingCart className="text-4xl" />
            </ButtenLink>

            <ButtenLink
              pageURL="pharmanstaff"
              title="Staff Management"
              mainColor={mainColor}
            >
              <IoPeopleOutline className="text-4xl" />
            </ButtenLink>

            <ButtenLink
              pageURL="pharmananalytics"
              title="Analytics"
              mainColor={mainColor}
            >
              <FaChartSimple className="text-4xl" />
            </ButtenLink>
          </div>

          <div>
            <div className="mt-15">
              <hr className="border-t-2 text-gray-300 my-4" />
            </div>
            <div className="flex flex-col items-center gap-5">
              <div className="flex items-center rounded-3xl duration-200 isActive mainColor text-amber-50 gap-2 text-3xl my-5 hover:text-red-600 font-bold hover:cursor-pointer">
                <div className="text-4xl  hover:cursor-pointer">
                  <MdOutlineLogout />
                </div>
                <button
                  className=" hover:cursor-pointer"
                  onClick={() => {
                    toast.success("Logged Out");
                    navigate("/");
                  }}
                >
                  Log out
                </button>
              </div>
              <div className="flex items-center gap-2 text-5xl text-white border border-dashed p-6 rounded-4xl">
                <div>PillSpot</div>
                <PiPillLight />
              </div>
            </div>
          </div>
        </div>
      </div>

      <div className="card bg-white grid h-227 place-items-center flex-[3] rounded-3xl m-auto w-full max-w-[1400px] p-6 overflow-auto md:overflow-auto">
        <Outlet />
      </div>
    </div>
  );
};

export default PharManagementLayout;
