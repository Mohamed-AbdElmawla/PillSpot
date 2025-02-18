import { createBrowserRouter, createRoutesFromElements, Route, RouterProvider } from "react-router-dom";

import Home from "../pages/Landing";

// Define the router
const router = createBrowserRouter(
  createRoutesFromElements(
    <Route path="/" element={<Home />}></Route>
  )
);

// Main Router Component
const Router = () => {
  return (
    <RouterProvider router={router} />
  );
};

export default Router;
