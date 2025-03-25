import img from '../MainPage/images/image copy.png'

const OnePharmacy = () => {
  return (
    <div>
       <div
        // key={pharmacy.pharmacyDto.pharmacyId}
        className="bg-gray-50 shadow-md rounded-lg p-4 flex flex-col items-center w-70 hover:scale-103 duration-150"
      >
        <img
          //   src={`https://localhost:7298${pharmacy.pharmacyDto.logoURL}`}
          src={img}
          alt="Pharmacy Logo"
          className="w-24 h-24 rounded-full object-cover mb-3 border border-gray-300"
        />
        <h4 className="text-lg font-semibold text-gray-800">
          {/* {pharmacy.pharmacyDto.name} */}✨ Pharmacy Name
        </h4>
        <p className="text-gray-600 text-sm">
          {/* {pharmacy.pharmacyDto.location || "Assiut "} */}
          🪧Location
        </p>
        <p className="text-gray-500 text-sm">
          {/* 📞 {pharmacy.pharmacyDto.contactNumber} */}
          📞 Contact Number
        </p>
        <p className="text-gray-500 text-sm">
          {/* 🕒 {pharmacy.pharmacyDto.openingTime} -{" "} */}
          {/* {pharmacy.pharmacyDto.closingTime} */}
          🕒 Open and closing time
        </p>
        <p className="text-gray-500 text-sm">
          {/* 🗓️ {pharmacy.pharmacyDto.daysOpen} */}
          Open Days
        </p>

        <button
          className="mt-4 px-4 py-2 bg-blue-500 text-white rounded-lg hover:bg-blue-600 transition"
          //   onClick={() =>
          //     handleGoToPharmacy(pharmacy.pharmacyDto.pharmacyId)
          //   }
        >
          Access Pharmacy
        </button>
      </div>
    </div>
  )
}

export default OnePharmacy
