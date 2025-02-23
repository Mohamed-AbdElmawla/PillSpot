import { createBrowserRouter, createRoutesFromElements, Route, RouterProvider } from "react-router-dom";

import Home from "../pages/Landing";
import RootPage from "../layouts/RootPage";
import ResultPage from "../pages/ResultPage";

// Define the router
const router = createBrowserRouter(
  createRoutesFromElements(
    <Route path="/" element={<RootPage />}>
         <Route path="landing" element={<Home />} />
         <Route path="result" element={<ResultPage />} />


    </Route>
  )
);

// Main Router Component
const Router = () => {
  return (
    <RouterProvider router={router} />
  );
};

export default Router;
