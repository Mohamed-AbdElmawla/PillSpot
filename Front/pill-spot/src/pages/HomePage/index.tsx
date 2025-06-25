import { useDispatch, useSelector } from "react-redux";
import MainBody from "./Body";
import HomeFooter from "./Footer";
import HomeHeader from "./Header";
import { AppDispatch, RootState } from "../../app/store";
import { FetchHomeCategory, FetchHomeProducts } from "../../features/HomePage/Products/fetchProdcuts";
import { useEffect } from "react";



const HomePageMain = () => {
  const dispatch = useDispatch<AppDispatch>() ;

  // error here
  useEffect(()=>{
    dispatch(FetchHomeProducts({PageNumber:"1",PageSize:"12"}));
    dispatch(FetchHomeCategory());
  },[])

  const loadingProducts = useSelector((state:RootState)=>state.fetchHomeProductSlice.LoadingProducts) ; 
  const loadingCategroies = useSelector((state:RootState)=>state.fetchHomeProductSlice.LoadingCategories) ; 


  // const Products = useSelector((state:RootState)=>state.fetchHomeProductSlice.Products) ; 
  // const Categroies = useSelector((state:RootState)=>state.fetchHomeProductSlice.Categories) ; 

  return (
    <>
    {
      (loadingCategroies || loadingProducts) ?
        <div className="flex items-center justify-center w-full h-screen">
          <div className="loading loading-ring w-150"></div>
        </div>
      :
      <div className="flex flex-col min-h-screen  bg-blue-50">
        <div className="container m-auto flex-1 bg-blue-50 px-2 ">
          <HomeHeader />
       
          <MainBody />
        </div>
        <div className="mt-auto">
          <HomeFooter/>
        </div>
      </div>
    }
    </>
  );
};

export default HomePageMain;
