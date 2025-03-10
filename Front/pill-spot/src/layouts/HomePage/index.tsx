import { Navigate, Outlet } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState } from "../../app/store";

const UserHomePage = () => {
  const user = useSelector((state:RootState) => state.authLogin.userLogin);
  
  return user ? <Outlet /> :  <Navigate to="/landing" replace />;
};

export default UserHomePage;
