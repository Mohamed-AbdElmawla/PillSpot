import { FiSearch } from "react-icons/fi";
// import { PiPillFill } from "react-icons/pi";
import InfoOptions from "./Info";
import img from "../../../assets/log2.png";
import Notifications from "./Notifications";
import WishList from "./WishList";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../../app/store";
import { useEffect, useState } from "react";
import { getCurUser } from "../../../features/User/UserSlcie";
import { useNavigate } from "react-router-dom";

const HomeHeader = () => {
  const dispatch = useDispatch<AppDispatch>() ;
  const userName : string = useSelector((state: RootState) => state.authLogin.userLogin) || "";
  const curUserState = useSelector((state:RootState)=> state.CurUserSlice) ;
  const [searchValue, setSearchValue] = useState("");
  const navigate = useNavigate();

  useEffect(()=>{
    dispatch(getCurUser(userName)) ;
  },[])

  const handleSearch = () => {
    if (searchValue.trim()) {
      navigate(`/productpage?medecinetosearch=${encodeURIComponent(searchValue.trim())}`);
    }
  };

  const handleInputKeyDown = (e: React.KeyboardEvent<HTMLInputElement>) => {
    if (e.key === 'Enter') {
      handleSearch();
    }
  };

if(curUserState.isLoading === true){
  return (
    <div>
      fetching data... ;
    </div>
  )
}

  return (
   
    <>
      <div className="container flex items-center justify-between p-5 text-2xl gap-15 rounded-b-4xl bg-gradient-to-r from-[#334c83] to-[#476ba1] bg-[length:200%_200%] bg-left transition-all duration-500 hover:bg-right">
        <div
          id="Logo"
          className="w-full flex-[1.5] text-3xl font-bold flex items-center gap-2 text-[#ffffff]"
        >
          <img src={img} alt="" className="rounded-2xl w-20" />
          Pill Spot
        </div>
        <div
          id="SearchHomeMain"
          className="mx-5 hidden sm:flex justify-center flex-4 items-center"
        >
          <div className="relative w-full max-w-3xl">
            <input
              type="text"
              placeholder="Search"
              className="w-full  placeholder:text-black border-0 bg-[#e3eaf6] shadow-sm focus:border-gray-400 outline-none rounded-2xl indent-6 h-11 pr-12"
              value={searchValue}
              onChange={e => setSearchValue(e.target.value)}
              onKeyDown={handleInputKeyDown}
            />
            <FiSearch
              className="absolute right-4 top-1/2 transform -translate-y-1/2 text-gray-500 cursor-pointer"
              onClick={handleSearch}
            />
          </div>
        </div>
        <div id="info" className="flex-2 w-full text-[#242a47]">
          {typeof curUserState.curUser === 'object' && curUserState.curUser !== null ? (
            <InfoOptions name={curUserState.curUser.firstName + " " + curUserState.curUser.lastName} email={curUserState.curUser.email} />
          ) : null}
        </div>
        <div
          id="cart&wishlist"
          className="flex-1 flex items-center text-[#242a47]"
        >
          <Notifications />
          <WishList />
        </div>
      </div>
    </>
  );
};

export default HomeHeader;
