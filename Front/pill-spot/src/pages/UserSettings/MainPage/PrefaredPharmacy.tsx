import Rating from "../../../UI/Rating"
import { MdOutlineKeyboardArrowRight } from "react-icons/md";


const PrefaredPharmacy = () => {
  return (
    <div className="flex bg-white w-full rounded-2xl p-2 items-center gap-5 relative shadow-lg hover:scale-105 duration-200 hover:cursor-pointer">
      <img src="/src/pages/UserSettings/MainPage/images/image copy.png" className="w-20 h-20 rounded-full" alt="" />
      <div className="flex flex-col items-center justify-center">
        <span className="font-bold text-blue-900">Name of pharmacy</span>
        <Rating value={5} />
      </div>
      <div className="absolute right-4 bottom-2 ">
        3,5KM
      </div>
      
      <MdOutlineKeyboardArrowRight className="absolute right-4 text-2xl " />

      
    </div>
  )
}

export default PrefaredPharmacy
