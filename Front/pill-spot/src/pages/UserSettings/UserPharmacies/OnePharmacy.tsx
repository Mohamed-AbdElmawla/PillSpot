import { useDispatch } from 'react-redux';
// import img from '../MainPage/images/image copy.png'
import { AppDispatch } from '../../../app/store';
import { fetchCurrentPharmacy } from '../../../features/Pharmacy/CRUD/UserPharmaciesSlice/CurPharmacy';
import { useNavigate } from 'react-router-dom';

interface IPharmacy {
  name : string ;
  location : string | null ;
  contNumber : string ;
  openTime : string ;
  closeTime:string ;
  pharmacyId : string ;
  imageUrl : string ;
}


const OnePharmacy = ({name,location,contNumber,openTime,closeTime,pharmacyId,imageUrl}:IPharmacy) => {

  const dispatch = useDispatch<AppDispatch>() ;
  const navigate = useNavigate() ;

  async function handleAccessPharmacy() {
    try {
      await dispatch(fetchCurrentPharmacy(pharmacyId)).unwrap();
      navigate("/pharmacymanagement/pharmanhome");
    } catch (error) {
      console.error("Failed to access pharmacy:", error);
    }
  }


  return (
    <div>
       <div
        // key={pharmacy.pharmacyDto.pharmacyId}
        className="bg-gray-50 shadow-md rounded-lg p-4 flex flex-col items-center w-70 hover:scale-103 duration-150"
      >
        <img
             src={`${import.meta.env.VITE_BASE_URL}${imageUrl}`}
         // src={img}
          alt="Pharmacy Logo"
          className="w-24 h-24 rounded-full object-cover mb-3 border border-gray-300"
        />
        <h4 className="text-lg font-semibold text-gray-800">
          ✨{name}
        </h4>
        <p className="text-gray-600 text-sm">
          🪧
          {location || "Assiut "}
        </p>
        <p className="text-gray-500 text-sm">
        
          📞 {contNumber}
        </p>
        <p className="text-gray-500 text-sm">
          🕒 {openTime} -{" "}
          {closeTime}
         
        </p>
        {/* <p className="text-gray-500 text-sm">
          🗓️ {daysOpen}
         
        </p> */}

        <button
          className="mt-4 px-4 py-2 bg-blue-500 text-white rounded-lg hover:bg-blue-600 transition"
          onClick={handleAccessPharmacy}
        >
          Access Pharmacy
        </button>
      </div>
    </div>
  )
}

export default OnePharmacy
