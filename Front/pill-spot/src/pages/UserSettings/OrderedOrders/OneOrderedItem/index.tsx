
import img from "../../MainPage/images/455280085_515769004150965_1822829626503930280_n.jpg";
import { Link } from "react-router-dom";
import { FaExternalLinkAlt } from "react-icons/fa";

const OneOrderItem = () => {
  return (
    <div className="flex flex-wrap md:flex-nowrap gap-5 w-full bg-gray-50 shadow-md p-3 rounded-2xl text-[#02457A] max-h-40 overflow-auto hover:scale-101 duration-300
        hover:bg-amber-50
    ">
    <img
      src={img}
      alt="image"
      className="w-32 h-32 sm:w-40 sm:h-30 rounded-tl-2xl rounded-br-2xl object-cover"
    />
    <div className="flex flex-col gap-2 w-full justify-around text-center md:text-left">
      <span className="text-xl sm:text-2xl font-bold">
        Name Name Name Name
      </span>
      <span className="text-lg sm:text-xl font-bold flex items-center justify-center md:justify-start gap-3">
        Pharmacy Pharmacy <FaExternalLinkAlt className="text-sm" />
      </span>
      <div className="badge badge-outline badge-info self-center md:self-start">
        Order Date
      </div>
    </div>
    <div className="hidden md:flex divider divider-horizontal"></div>

    <div className="flex flex-col justify-around items-center md:items-center w-full md:w-auto">
      <div className="text-2xl sm:text-3xl font-bold mx-10 items-center justify-center">50$</div>
      <div>
        <Link
          to={"/"}
          className="flex items-center justify-center gap-1 text-[#02457A]"
        >
          View Product <FaExternalLinkAlt />
        </Link>
      </div>
    </div>
  </div>
  )
}

export default OneOrderItem
