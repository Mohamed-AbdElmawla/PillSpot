import ProductPopular from "./Product";
import MainInfo from "./MainInfo";
import { Link } from "react-router-dom";
import img from './images/image copy 4.png'


const UserSettingsMain = () => {
  return (
    <div className="flex flex-col justify-center">
      <MainInfo />

      <div className="flex h-80 mt-5 gap-x-8">
        <div>
          <span className="p-1 text-xl font-bold text-[#02457A] mb-2 block">
            Popular choices based on your past orders
          </span>
          <div className="flex flex-col gap-x-8 lg:flex-row">
            <ProductPopular />
            <ProductPopular />
            <ProductPopular />
            <ProductPopular />
            <ProductPopular />
          </div>
        </div>
        {/* "url('/src/assets/image.png')" */}
        <div
          className="w-113 mx-auto mr-0 h-90 bg-cover bg-center rounded-2xl flex flex-col items-center justify-center"
          style={{ backgroundImage: `url(${img})` }}
        >
          <img
            src="/src/pages/UserSettings/MainPage/images/image.png"
            className="w-50 h-50 "
          />
          <div className="text-center text-white font-bold text-lg px-20">
            Want to add your pharmacy to our system? Start here!
          </div>

          <Link to="/pharmacyregister">
            <span className="btn bg-[#02457A] text-white rounded-2xl border-0 mt-5">
              Add Pharmacy
            </span>
          </Link>
        </div>
      </div>
    </div>
  );
};

export default UserSettingsMain;
