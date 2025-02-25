import MainBody from "./Body";
import HomeHeader from "./Header";

const HomePageMain = () => {
  return (
    <>
      <div className="container m-auto h-screen bg-white">
        <HomeHeader/>
        <hr className="border-gray-200" />
        <MainBody/>
      </div>
    </>
  );
};

export default HomePageMain;
