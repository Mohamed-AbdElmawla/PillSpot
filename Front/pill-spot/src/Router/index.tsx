import {
  createBrowserRouter,
  createRoutesFromElements,
  Navigate,
  Route,
  RouterProvider,
} from "react-router-dom";

import Home from "../pages/Landing";
import RootPage from "../layouts/RootPage";
// import ResultPage from "../pages/ResultPage";
import PharManagementLayout from "../pages/PharmacyManagement";
import InventoryPage from "../pages/PharmacyManagement/Inventory";
import PharManagementHome from "../pages/PharmacyManagement/ManagementHome";
import OrderManagementHome from "../pages/PharmacyManagement/OrdersManagemnt";
import StaffManagement from "../pages/PharmacyManagement/StaffManagement";
import DataChart from "../pages/PharmacyManagement/DataChart";
import HomePageMain from "../pages/HomePage";
import UserHomePage from "../layouts/HomePage";


// import PharmacyReg from "../layouts/PharmacyReg";
import RegPharmacy from "../pages/RegisterPharmacy";
import UserSettingLayout from "../pages/UserSettings";
import UserSettingsMain from "../pages/UserSettings/MainPage";
import OrdersCartPage from "../pages/UserSettings/OrdersCart";
import UserOrderedOrders from "../pages/UserSettings/OrderedOrders";
import UserEditInofPage from "../pages/UserSettings/UserEditInfo";
import UserPharmacies from "../pages/UserSettings/UserPharmacies";
import UserSettingPage from "../layouts/UserPage";
// import AdminCategories from "../layouts/tempAdmin/tempAdmin";

import UserNotifications from "../pages/UserSettings/userNotifications";
import ProductPharmacySearch from "../pages/ProductPharmacySearch";
import SearchByDistance from "../pages/SearchByDistance";

// Define the router
const router = createBrowserRouter(
  createRoutesFromElements(
    <Route path="/" element={<RootPage />}>
      <Route index element={<Navigate to="landing" replace />} />
      <Route path="landing" element={<Home />} />
      <Route path="result" element={<SearchByDistance/>} />

      // main home page layout and routes
      <Route element={<UserHomePage />}>  // this is for protect router
        <Route path="homepage" element={<HomePageMain />} />
        <Route path="productpage" element={<ProductPharmacySearch/>} /> 
        {/* <Route path="productpage" element={<ProductPage />} />  */}
        <Route path="pharmacymanagement" element={<PharManagementLayout />}>
          <Route path="pharmanhome" element={<PharManagementHome />} />
          <Route path="pharmaninventory" element={<InventoryPage />} />
          <Route path="pharmanstaff" element={<StaffManagement />} />
          <Route path="pharmananalytics" element={<DataChart />} />
          <Route path="pharmanorders" element={<OrderManagementHome />} />
        </Route>
      </Route>

      {/* <Route path="tempAdminPage" element={<AdminCategories />}>
      
        // this is for protect router
       
      </Route> */}



      <Route element={<UserSettingPage />}> // this is for protect router
        <Route path="usersettingpage" element={<UserSettingLayout />} >
          <Route index element={<UserSettingsMain/>}/>
          <Route path="page1" element={<UserSettingsMain/>}/>
          <Route path="page2" element={<UserNotifications/>}/>
          <Route path="page3" element={<OrdersCartPage/>}/>
          <Route path="page4" element={<div><UserOrderedOrders/></div>}/>
          <Route path="page5" element={<div><UserEditInofPage/></div>}/>
          <Route path="page6" element={<div><UserPharmacies/></div>}/>
        </Route>
      <Route path="pharmacyregister" element={ <RegPharmacy/>} /> // this is for protect router
      </Route>


      
    </Route>
  )
);


const Router = () => {
  return <RouterProvider router={router} />;
};

export default Router;
