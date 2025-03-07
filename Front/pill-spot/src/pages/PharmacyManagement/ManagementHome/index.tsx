import DataEditForm from "./DataEditForm";
import HomeHeader from "./HomeHeader";
import SideBar from "./SideBar/SideBar";

const PharManagementHome = () => {
  return (
    <div className="container flex flex-col gap-10  pt-16 ">
      <div className="w-full m-auto">
        <HomeHeader />
      </div>
      <div className="flex absolute top-70 gap-30 ">
        <div className="">
          <DataEditForm />
        </div>
        <div className="">
          <SideBar />
        </div>
      </div>
    </div>
  );
};

export default PharManagementHome;
