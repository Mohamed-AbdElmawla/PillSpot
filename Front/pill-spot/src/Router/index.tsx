import {
  createBrowserRouter,
  createRoutesFromElements,
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

// Define the router
const router = createBrowserRouter(
  createRoutesFromElements(
    <Route path="/" element={<RootPage />}>
      <Route path="landing" element={<Home />} />
      <Route path="result" element={<ResultPage />} />
      <Route path="pharmacymanagement" element={<PharManagementLayout />}>
        <Route path="pharmanhome" element={<PharManagementHome/>} />
        <Route path="pharmaninventory" element={<InventoryPage/>} />
        <Route path="pharmanstaff" element={<StaffManagement/>} />
        <Route path="pharmananalytics" element={"pharmacy analytics"} />
        <Route path="pharmanorders" element={<OrderManagementHome/>} />
      </Route>
    </Route>
  )
);

// Main Router Component
const Router = () => {
  return <RouterProvider router={router} />;
};

export default Router;
