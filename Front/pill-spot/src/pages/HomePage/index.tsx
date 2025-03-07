import MainBody from "./Body";
import HomeFooter from "./Footer";
import HomeHeader from "./Header";

const HomePageMain = () => {
  return (
    <>
      <div className="flex flex-col min-h-screen">
        <div className="container m-auto flex-1 bg-white">
          <HomeHeader />
          <hr className="border-gray-200" />
          <MainBody />
        </div>
        <div className="mt-auto">
          <HomeFooter />
        </div>
      </div>
    </>
  );
};

export default HomePageMain;
