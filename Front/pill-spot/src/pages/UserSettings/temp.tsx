// import axios from "axios";
// import { ChangeEvent, useState } from "react";
// import { useDispatch, useSelector } from "react-redux";
// import { Link, useNavigate } from "react-router-dom";
// import { fetchUserPharmacies } from "../../features/Pharmacy/CRUD/UserPharmaciesSlice/GetUserPharmcsSlice";
// import { AppDispatch, RootState } from "../../app/store";
// import { fetchCurrentPharmacy } from "../../features/Pharmacy/CRUD/UserPharmaciesSlice/CurPharmacy";

// const UserSettingMain = () => {
//   const [category, setCat] = useState("");
//   const dispatch = useDispatch<AppDispatch>();
//   const {
//     list: pharmacies,
//     loading,
//     error,
//   } = useSelector((state: RootState) => state.getUserPharmacies);
//   const navigate = useNavigate();
//   const CurPharmacy = useSelector((state: RootState) => state.currentPharmacy);
//   console.log(CurPharmacy);

//   function handleChange(e: ChangeEvent<HTMLInputElement>) {
//     setCat(e.target.value);
//   }

//   async function handleClick() {
//     try {
//       const response = await axios.post(
//         "https://localhost:7298/api/categories",
//         { name: category }
//       );
//       console.log(response);
//       const responseGet = await axios.get(
//         "https://localhost:7298/api/categories"
//       );
//       console.log(category);
//       console.log(responseGet.data);
//     } catch (error) {
//       console.error("Error adding category", error);
//     }
//   }

//   function handleGetPhar() {
//     dispatch(fetchUserPharmacies());
//   }

//   function handleGoToPharmacy(pharId: string) {
//     dispatch(fetchCurrentPharmacy(pharId));
//     //
//     navigate('/pharmacymanagement')
    
//   }

//   return (
//     <div className="flex flex-col items-center justify-center min-h-screen bg-gray-100 p-6">
//       {/* Register Pharmacy */}
//       <div className="w-full max-w-md bg-white p-6 rounded-lg shadow-md">
//         <h2 className="text-xl font-semibold text-gray-700 mb-4">
//           User Settings
//         </h2>
//         <Link
//           to="/pharmacyregister"
//           className="block w-full text-center bg-blue-500 text-white py-2 rounded-lg hover:bg-blue-600 transition"
//         >
//           Register Pharmacy
//         </Link>
//       </div>

//       {/* Add Category Section */}
//       <div className="w-full max-w-md bg-white p-6 rounded-lg shadow-md mt-4">
//         <h3 className="text-lg font-medium text-gray-700 mb-3">Add Category</h3>
//         <input
//           type="text"
//           placeholder="Enter category name"
//           value={category}
//           onChange={handleChange}
//           className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-400 focus:outline-none"
//         />
//         <button
//           className="w-full bg-green-500 text-white py-2 mt-3 rounded-lg hover:bg-green-600 transition"
//           onClick={handleClick}
//         >
//           Add Category
//         </button>
//       </div>

//       {/* User Pharmacies Section */}
//       <div className="w-full max-w-4xl bg-white p-6 rounded-lg shadow-md mt-6">
//         <h3 className="text-lg font-medium text-gray-700 mb-3">
//           Your Pharmacies
//         </h3>
//         <button
//           className="w-full bg-blue-500 text-white py-2 mb-3 rounded-lg hover:bg-blue-600 transition"
//           onClick={handleGetPhar}
//         >
//           Get all pharmacies
//         </button>

//         {loading && <p className="text-gray-500">Loading...</p>}
//         {error && <p className="text-red-500">{error}</p>}

//         {pharmacies && pharmacies.length > 0 ? (
//           <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-6">
//             {pharmacies.map((pharmacy) => (
//               <div
//                 key={pharmacy.pharmacyDto.pharmacyId}
//                 className="bg-gray-100 shadow-md rounded-lg p-4 flex flex-col items-center"
//               >
//                 <img
//                   src={`https://localhost:7298${pharmacy.pharmacyDto.logoURL}`}
//                   alt="Pharmacy Logo"
//                   className="w-24 h-24 rounded-full object-cover mb-3 border border-gray-300"
//                 />
//                 <h4 className="text-lg font-semibold text-gray-800">
//                   {pharmacy.pharmacyDto.name}
//                 </h4>
//                 <p className="text-gray-600 text-sm">
//                   {pharmacy.pharmacyDto.location || "Assiut "}
//                 </p>
//                 <p className="text-gray-500 text-sm">
//                   📞 {pharmacy.pharmacyDto.contactNumber}
//                 </p>
//                 <p className="text-gray-500 text-sm">
//                   🕒 {pharmacy.pharmacyDto.openingTime} -{" "}
//                   {pharmacy.pharmacyDto.closingTime}
//                 </p>
//                 <p className="text-gray-500 text-sm">
//                   🗓️ {pharmacy.pharmacyDto.daysOpen}
//                 </p>

//                 <button
//                   className="mt-4 px-4 py-2 bg-blue-500 text-white rounded-lg hover:bg-blue-600 transition"
//                   onClick={() =>
//                     handleGoToPharmacy(pharmacy.pharmacyDto.pharmacyId)
//                   }
//                 >
//                   Manage Pharmacy
//                 </button>
//               </div>
//             ))}
//           </div>
//         ) : (
//           !loading && (
//             <p className="text-gray-500">No pharmacies registered yet.</p>
//           )
//         )}
//       </div>
//     </div>
//   );
// };

// export default UserSettingMain;
