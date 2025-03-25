import { Navigate, Outlet } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState } from "../../app/store";

const UserSettingPage = () => {
  const user = useSelector((state:RootState) => state.authLogin.userLogin);
  

  // instead of outlit we will call the home page that will have the side an search bar and send outlit within them 
  return user ? <Outlet /> :  <Navigate to="/landing" replace />;
};

export default UserSettingPage;
