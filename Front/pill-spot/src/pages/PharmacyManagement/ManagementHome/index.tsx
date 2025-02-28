import DataEditForm from "./DataEditForm";
import HomeHeader from "./HomeHeader";
import SideBar from "./SideBar/SideBar";

const PharManagementHome = () => {
  return (
    <div className="container flex flex-col gap-10  pt-16 ">
      <div className="w-full m-auto">
        <HomeHeader />
      </div>
      <div className="flex">
        <div className="flex-[3]">
          <DataEditForm />
        </div>
        <div className="flex-1">
          <SideBar />
        </div>
      </div>
    </div>
  );
};

export default PharManagementHome;
