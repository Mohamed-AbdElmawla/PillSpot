import { MdOutlineInventory2 } from "react-icons/md";
import { TiHomeOutline } from "react-icons/ti";
import { MdOutlineShoppingCart } from "react-icons/md";
import { IoPeopleOutline } from "react-icons/io5";
import { FaChartSimple } from "react-icons/fa6";
import { MdOutlineLogout } from "react-icons/md";
import PharManagemetDetails from "./PharDetails";
import ButtenLink from "./ButtonLink";
import { toast } from "sonner";
import { useNavigate } from "react-router-dom";
import logoimg from "./PharDetails/log2.png"
import { useSelector } from "react-redux";
import { RootState } from "../../app/store";

const mainColor = "text-cyan-500";

const SidePanel = () => {

  const currentPhar = useSelector((state:RootState) => state.currentPharmacy) ;
  console.log(currentPhar.pharmacy?.logoURL)

  const navigate = useNavigate();
  return (
    <div className="card  rounded-box grid h-227 place-items-center  m-auto mr-0 font-roboto">
      <div className="flex flex-col justify-between h-10/12 text-2xl list-none items-center">
        <PharManagemetDetails
          imgSrc={currentPhar.pharmacy?.logoURL}
          name={currentPhar.pharmacy?.name}
          email={currentPhar.pharmacy?.contactNumber}
        />

        <div className="flex flex-col gap-4">
          <ButtenLink pageURL="pharmanhome" title="Home" mainColor={mainColor}>
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
                <MdOutlineLogout className="hidden md:flex" />
              </div>
              <button
                className=" hover:cursor-pointer"
                onClick={() => {
                  toast.success("Logged Out");
                  navigate("/usersettingpage");
                }}
              >
                Log out
              </button>
            </div>
            <div className="hidden md:flex items-center gap-2 text-5xl text-white  p-6 rounded-4xl font-logo">
              <div>PillSpot</div>
              <img src={logoimg} className="w-20" />
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default SidePanel;
