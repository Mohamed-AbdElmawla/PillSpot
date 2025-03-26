import MainBody from "./Body";
import HomeFooter from "./Footer";
import HomeHeader from "./Header";



const HomePageMain = () => {
  return (
    <>
      <div className="flex flex-col min-h-screen  bg-blue-50">
        <div className="container m-auto flex-1 bg-blue-50 px-2 ">
          <HomeHeader />
       
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
