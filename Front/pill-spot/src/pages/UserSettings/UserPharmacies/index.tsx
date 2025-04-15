import  { useEffect } from "react";
import OnePharmacy from "./OnePharmacy";
import { useDispatch, useSelector } from "react-redux";
import { fetchUserPharmacies } from "../../../features/Pharmacy/CRUD/UserPharmaciesSlice/GetUserPharmcsSlice";
import { AppDispatch, RootState } from "../../../app/store";

const UserPharmacies = () => {

  const {
        list: pharmacies,
        loading,
        error,
      } = useSelector((state: RootState) => state.getUserPharmacies);

  console.log(pharmacies, loading, error); 
  const dispatch = useDispatch<AppDispatch>()

  useEffect(()=>{
    dispatch(fetchUserPharmacies()) ;
  },[])
  
  // function handleclick(){
  //   console.log("will try")
  //   dispatch(fetchUserPharmacies()) ;
  // }
  
  
  const pharData = pharmacies.map((p) => (
    <OnePharmacy
      name={p.name}
      contNumber={p.contactNumber}
      openTime={p.openingTime}
      closeTime={p.closingTime}
      imageUrl={p.logoURL}
      location={p.locationDto}
      pharmacyId={p.pharmacyId}
      key={p.pharmacyId}
    />
  ));
  console.log(pharData)



  return (
    <div className="flex justify-center items-cente flex-wrap gap-5">
      {/* <button className="btn" onClick={handleclick}>
        get pharmacy
      </button> */}
      {
        loading ? <><div>Get your Data</div></> :pharData
      }
   
    </div>
  );
};

export default UserPharmacies;
