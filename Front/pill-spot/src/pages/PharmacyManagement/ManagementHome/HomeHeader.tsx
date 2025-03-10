import PharManagemetDetails from "../PharDetails";
import { IoMdNotificationsOutline } from "react-icons/io";

const HomeHeader = () => {
  return (
    <div className="container flex items-start justify-between absolute top-10 max-w-[70vw]">
      <PharManagemetDetails
        imgSrc="https://img.daisyui.com/images/profile/demo/2@94.webp"
        name="El Pharmacy"
        email="Elpharmacy@gail.com"
        dataColor="text-cyan-700"
      />
      <div className="flex items-center gap-10">
        <IoMdNotificationsOutline className="text-4xl text-cyan-700" />
        <button className="btn btn-error rounded-[50px]">Delete Account</button>
      </div>
    </div>
  );
};

export default HomeHeader;
