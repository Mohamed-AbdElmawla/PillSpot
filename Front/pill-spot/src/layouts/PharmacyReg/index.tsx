
import { Outlet } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState } from "../../app/store";
import RegPharmacy from "../../pages/RegisterPharmacy";

const PharmacyReg = () => {
  const user = useSelector((state: RootState) => state.authLogin.userLogin);
  return user ? <Outlet /> : <RegPharmacy/> ;
};

export default PharmacyReg;
