import {
  createBrowserRouter,
  createRoutesFromElements,
  Navigate,
  Route,
  RouterProvider,
} from "react-router-dom";

import Home from "../pages/Landing";
import RootPage from "../layouts/RootPage";
import ResultPage from "../pages/ResultPage";
import PharManagementLayout from "../pages/PharmacyManagement";
import InventoryPage from "../pages/PharmacyManagement/Inventory";
import PharManagementHome from "../pages/PharmacyManagement/ManagementHome";
import OrderManagementHome from "../pages/PharmacyManagement/OrdersManagemnt";
import StaffManagement from "../pages/PharmacyManagement/StaffManagement";
import DataChart from "../pages/PharmacyManagement/DataChart";
import HomePageMain from "../pages/HomePage";
import UserHomePage from "../layouts/HomePage";
import UserSettingPage from "../layouts/UserPage";
import UserSettingMain from "../pages/UserSettings";
import PharmacyReg from "../layouts/PharmacyReg";
import RegPharmacy from "../pages/RegisterPharmacy";

// Define the router
const router = createBrowserRouter(
  createRoutesFromElements(
    <Route path="/" element={<RootPage />}>
      <Route index element={<Navigate to="landing" replace />} />
      <Route path="landing" element={<Home />} />
      <Route path="result" element={<ResultPage />} />

      // main home page layout and routes
      {/* <Route element={<UserHomePage />}>  // this is for protect router */}
        <Route path="homepage" element={<HomePageMain />} />
        <Route path="pharmacymanagement" element={<PharManagementLayout />}>
          <Route path="pharmanhome" element={<PharManagementHome />} />
          <Route path="pharmaninventory" element={<InventoryPage />} />
          <Route path="pharmanstaff" element={<StaffManagement />} />
          <Route path="pharmananalytics" element={<DataChart />} />
          <Route path="pharmanorders" element={<OrderManagementHome />} />
        </Route>
      {/* </Route> */}

      {/* <Route element={<UserSettingPage />}> // this is for protect router */}
        <Route path="usersettingpage" element={<UserSettingMain />} />
      <Route path="pharmacyregister" element={ <RegPharmacy/>} /> // this is for protect router
      {/* </Route> */}


      
    </Route>
  )
);

// Main Router Component
const Router = () => {
  return <RouterProvider router={router} />;
};

export default Router;
