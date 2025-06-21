import { FaRegHeart } from "react-icons/fa6";
import { TbShoppingCartPlus } from "react-icons/tb";
import Rating from "../../../../../UI/Rating";
import { toast } from "sonner";
import { useDispatch } from "react-redux";
import { useEffect } from "react";
import { setColor } from "../../../../../features/Toasts/toastSlice";
import img from "./image.png";


interface IProduct extends React.HTMLAttributes<HTMLDivElement>  {
  quantity: number;
  productDto?: {
    productId: string;
    subCategoryDto: null;
    name: string;
    description: string;
    price: number;
    imageURL: string;
    createdDate: string;
  };
  pharmacyDto?: {
    pharmacyId: string;
    name: string;
    logoURL: string;
    logo: null;
    locationDto: null;
    contactNumber: string;
    openingTime: string;
    closingTime: string;
    isOpen24: false;
    daysOpen: string;
  };
  hover:boolean
}





const OneProduct = ({
  quantity = 0,
  productDto = {
    productId: "",
    subCategoryDto: null,
    name: "Unknown Product",
    description: "No description available.",
    price: 0,
    imageURL: "", // Fallback image
    createdDate: "",
  },
  pharmacyDto = {
    pharmacyId: "",
    name: "Unknown Pharmacy",
    logoURL: "",
    logo: null,
    locationDto: null,
    contactNumber: "N/A",
    openingTime: "00:00",
    closingTime: "00:00",
    isOpen24: false,
    daysOpen: "N/A",
  },
  hover = false,
  ...rest
}: IProduct) => {

  return (
    <div>
      {hover ? (
        <div className="flex items-center justify-center relative w-full max-w-xs sm:max-w-sm lg:max-w-md xl:max-w-lg border h-90 text-gray-600 border-gray-200 rounded-lg shadow-md p-5 overflow-hidden mt-20 hover:scale-105 duration-200">
          <div className="absolute inset-0 bg-cover bg-center opacity-50">
            <img src={img} alt="Product background" className="w-100 h-90" />
          </div>
          <div className="absolute inset-0 bg-[#00000050] bg-opacity-40 hover:bg-[#00000013] duration-300 hover:cursor-pointer"></div>
          <div className="relative z-10 text-xl font-bold">
            <button className="bg-blue-50 p-2 rounded-2xl cursor-pointer hover:scale-110 duration-300">
              See More Products ...
            </button>
          </div>
        </div>
      ) : (
        <div className="w-full max-w-xs sm:max-w-sm lg:max-w-md xl:max-w-lg bg-white border border-gray-200 rounded-lg shadow-md p-5">
          <div className="w-full h-56 flex justify-center">
            <img
              className="object-cover w-80 h-59 rounded-tl-3xl rounded-br-3xl"
              src={`https://localhost:7298${productDto.imageURL}`}
              alt="Product"
            />
          </div>

          <div className="mt-4">
            <div className="flex justify-between items-center mb-3">
              <span className="bg-blue-100 text-blue-800 text-xs font-medium px-2.5 py-0.5 rounded">
                Category
              </span>
              <button className="p-2 text-gray-500 hover:bg-gray-100 rounded-lg">
                <FaRegHeart />
              </button>
            </div>

            <a
              href="#"
              className="block text-lg font-semibold text-[#334c83] hover:underline"
            >
              {productDto.name}
            </a>

            <div className="mt-2 flex items-center gap-2">
              <Rating w="2" value={5} />
              <p className="text-sm font-medium text-gray-900">5.0</p>
              <p className="text-sm font-medium text-gray-500">(455)</p>
            </div>

            <ul className="mt-2 space-y-2">
              <li className="flex items-center gap-2 text-sm font-medium text-gray-500">
                <svg
                  className="h-4 w-4 text-gray-500"
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                >
                  <path
                    stroke="currentColor"
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    strokeWidth="2"
                    d="M13 7h6l2 4m-8-4v8m0-8V6a1 1 0 0 0-1-1H4a1 1 0 0 0-1 1v9h2m8 0H9m4 0h2m4 0h2v-4m0 0h-5m3.5 5.5a2.5 2.5 0 1 1-5 0 2.5 2.5 0 0 1 5 0Zm-10 0a2.5 2.5 0 1 1-5 0 2.5 2.5 0 0 1 5 0Z"
                  />
                </svg>
                {pharmacyDto.name}
              </li>
              <li className="flex items-center gap-2 text-sm font-medium text-gray-500">
                <svg
                  className="h-4 w-4 text-gray-500"
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                >
                  <path
                    stroke="currentColor"
                    strokeLinecap="round"
                    strokeWidth="2"
                    d="M8 7V6c0-.6.4-1 1-1h11c.6 0 1 .4 1 1v7c0 .6-.4 1-1 1h-1M3 18v-7c0-.6.4-1 1-1h11c.6 0 1 .4 1 1v7c0 .6-.4 1-1 1H4a1 1 0 0 1-1-1Zm8-3.5a1.5 1.5 0 1 1-3 0 1.5 1.5 0 0 1 3 0Z"
                  />
                </svg>
                {pharmacyDto.contactNumber}
              </li>
            </ul>

            <div className="mt-4 flex items-center justify-between">
              <p className="text-2xl font-extrabold text-[#334c83]">${productDto.price}</p>
              <button
                className="flex items-center bg-[#334c83] text-white px-5 py-2.5 text-sm font-medium rounded-lg hover:bg-[#99aeda] duration-100 cursor-pointer hover:text-[#334c83] focus:ring-4 focus:ring-blue-300"
                onClick={() => toast.success("Added to cart")}
              >
                <TbShoppingCartPlus className="text-xl mr-2" />
                Add to Cart
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default OneProduct;

