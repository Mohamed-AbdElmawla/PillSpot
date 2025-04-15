import { Navigate, Outlet } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../app/store";
import { useEffect } from "react";
import { checkAuth, logoutUser } from "../../features/auth/authLogin";

const UserHomePage = () => {
  // const user = useSelector((state:RootState) => state.authLogin.userLogin);
  // console.log(user) ;

  // return user ? <Outlet /> :  <Navigate to="/landing" replace />;

  const dispatch = useDispatch<AppDispatch>();
  const { isAuthenticated } = useSelector(
    (state: RootState) => state.authLogin
  );
  const userName = useSelector((state: RootState) => state.authLogin.userLogin);

  useEffect(() => {
    dispatch(checkAuth(userName));
  }, [dispatch,userName]);

  useEffect(() => {
    //when token expired the log out does not do anything because teh token deleted
    if(!isAuthenticated){
      dispatch(logoutUser());
    }
  }, [isAuthenticated]);

  console.log(isAuthenticated);

  if (isAuthenticated) {
    return <Outlet />;
  } 
  console.log(userName)
  return <Navigate to="/landing" replace />;
};

export default UserHomePage;

// import { useEffect } from 'react';
// import { useDispatch, useSelector } from 'react-redux';
// import { checkAuth } from './redux/authSlice';

// const App = () => {
//   const dispatch = useDispatch();
//   const { isAuthenticated } = useSelector((state) => state.auth);

//   useEffect(() => {
//     dispatch(checkAuth());
//   }, [dispatch]);

//   return (
//     <div>
//       <h1>{isAuthenticated ? 'Logged In' : 'Logged Out'}</h1>
//     </div>
//   );
// };

// export default App;
