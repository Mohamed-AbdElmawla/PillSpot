
import SecondHeader from "./TopHeader";
import Advs from "./Advs";
import Products from "./Products";
import PharmacyWithUs from "./Pharmacies";
import DoctorsCons from "./Doctors";
// import Cookies from "js-cookie";

const MainBody = () => {

  // const token = Cookies.get("AccessToken"); // Replace "AccessToken" with your cookie name
  // console.log("Token:", token);

  return (
    <div className="container">
      <SecondHeader />
      <Advs />
      <Products />
      <DoctorsCons />
      <PharmacyWithUs />
    </div>
  );
};

export default MainBody;
