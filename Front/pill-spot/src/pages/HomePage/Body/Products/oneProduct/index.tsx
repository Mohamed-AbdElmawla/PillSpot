import { FaRegHeart } from "react-icons/fa6";
import { TbShoppingCartPlus } from "react-icons/tb";
import Rating from "../../../../../UI/Rating";
import { toast } from "sonner";
import { useDispatch } from "react-redux";
import { useEffect } from "react";
import { setColor } from "../../../../../features/Toasts/toastSlice";

const OneProduct = () => {
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(setColor());
  }, [dispatch]);

  return (
    <div className="w-full max-w-xs sm:max-w-sm lg:max-w-md xl:max-w-lg bg-white border border-gray-200 rounded-lg shadow-md p-5">
    
      <div className="w-full h-56 flex justify-center">
        <img
          className="object-cover w-full h-full rounded-tl-3xl rounded-br-3xl"
          src="https://img.daisyui.com/images/stock/photo-1559703248-dcaaec9fab78.webp"
          alt="Product Image"
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

       
        <a href="#" className="block text-lg font-semibold text-[#334c83] hover:underline">
          Product Name Lorem ipsum dolor sit amet.
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
            Pharmacy
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
            Pharmacy
          </li>
        </ul>

       
        <div className="mt-4 flex items-center justify-between">
          <p className="text-2xl font-extrabold text-[#334c83]">$16</p>
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
  );
};

export default OneProduct;
