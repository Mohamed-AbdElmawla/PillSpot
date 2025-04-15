import { useSelector } from "react-redux";
import PharManagemetDetails from "../PharDetails";
import { IoMdNotificationsOutline } from "react-icons/io";
import { RootState } from "../../../app/store";

const HomeHeader = () => {

  const currentPharmacy = useSelector(
      (state: RootState) => state.currentPharmacy
    );

  return (
    <div className="container flex items-start justify-between absolute top-10 max-w-[70vw]">
      <PharManagemetDetails
        imgSrc={`${currentPharmacy.pharmacy?.logoURL}`}
        name={currentPharmacy.pharmacy?.name}
        email={currentPharmacy.pharmacy?.contactNumber  }
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
