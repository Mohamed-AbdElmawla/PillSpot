import { FaRegHeart } from "react-icons/fa6";
import { TbShoppingCartPlus } from "react-icons/tb";
import Rating from "../../../../../UI/Rating";
import { toast } from "sonner";
import { useState, useRef, useEffect } from "react";
import img from "./image.png";
import ContextMenu from "./ContextMenu";

interface CategoryDto {
  categoryId: string;
  name: string;
}

interface SubCategoryDto {
  categoryDto: CategoryDto;
  subCategoryId: string;
  name: string;
}

interface LocationDto {
  longitude: number;
  latitude: number;
  additionalInfo: string;
  cityDto: null;
}

interface IProduct extends React.HTMLAttributes<HTMLDivElement>  {
  quantity: number;
  productDto?: {
    productId: string;
    subCategoryDto: SubCategoryDto;
    name: string;
    description: string;
    usageInstructions: string;
    price: number;
    imageURL: string;
    manufacturer: string;
    createdDate: string;
  };
  pharmacyDto?: {
    pharmacyId: string;
    name: string;
    logoURL: string;
    logo: null;
    locationDto: LocationDto;
    contactNumber: string;
    openingTime: string;
    closingTime: string;
    isOpen24: boolean;
    daysOpen: string;
  };
  hover:boolean
}

const OneProduct = ({
  productDto = {
    productId: "",
    subCategoryDto: {
      categoryDto: {
        categoryId: "",
        name: "Unknown Category"
      },
      subCategoryId: "",
      name: "Unknown Subcategory"
    },
    name: "Unknown Product",
    description: "No description available.",
    usageInstructions: "No usage instructions available.",
    price: 0,
    imageURL: "", // Fallback image
    manufacturer: "Unknown Manufacturer",
    createdDate: "",
  },
  pharmacyDto = {
    pharmacyId: "",
    name: "Unknown Pharmacy",
    logoURL: "",
    logo: null,
    locationDto: {
      longitude: 0,
      latitude: 0,
      additionalInfo: "",
      cityDto: null
    },
    contactNumber: "N/A",
    openingTime: "00:00",
    closingTime: "00:00",
    isOpen24: false,
    daysOpen: "N/A",
  },
  hover = false,
  quantity,
}: IProduct) => {
  const [contextMenu, setContextMenu] = useState<{ x: number; y: number; visible: boolean }>({
    x: 0,
    y: 0,
    visible: false,
  });
  const productRef = useRef<HTMLDivElement>(null);

  useEffect(() => {
    const handleClickOutside = (event: MouseEvent) => {
      if (productRef.current && !productRef.current.contains(event.target as Node)) {
        setContextMenu(prev => ({ ...prev, visible: false }));
      }
    };

    document.addEventListener('mousedown', handleClickOutside);
    return () => document.removeEventListener('mousedown', handleClickOutside);
  }, []);

  const handleContextMenu = (event: React.MouseEvent) => {
    event.preventDefault();
    setContextMenu({
      x: event.clientX,
      y: event.clientY,
      visible: true,
    });
  };

  const handleAddToCart = () => {
    toast.success("Added to cart");
  };

  const handleCloseContextMenu = () => {
    setContextMenu(prev => ({ ...prev, visible: false }));
  };

  return (
    <div ref={productRef}>
      {hover ? (
        <div 
          className="flex items-center justify-center relative w-full max-w-xs sm:max-w-sm lg:max-w-md xl:max-w-lg border h-90 text-gray-600 border-gray-200 rounded-lg shadow-md p-5 overflow-hidden mt-20 hover:scale-105 duration-200"
        >
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
        <div 
          className="relative w-full max-w-xs sm:max-w-sm lg:max-w-md xl:max-w-lg bg-white border border-gray-200 rounded-lg shadow-md p-5"
          onContextMenu={handleContextMenu}
        >
          {quantity === 0 && (
            <div className="absolute top-3 right-3 bg-red-500 text-white text-xs font-bold px-3 py-1 rounded-full z-20 shadow-lg">
              Not Available
            </div>
          )}
          <div className="w-full h-56 flex justify-center">
            <img
              className="object-cover w-80 h-59 rounded-tl-3xl rounded-br-3xl"
              src={`${import.meta.env.VITE_BASE_URL}${productDto.imageURL}`}
              alt="Product"
            />
          </div>

          <div className="mt-4">
            <div className="flex justify-between items-center mb-3">
              <span className="bg-blue-100 text-blue-800 text-xs font-medium px-2.5 py-0.5 rounded">
                {productDto.subCategoryDto.categoryDto.name}
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
                className={`flex items-center px-5 py-2.5 text-sm font-medium rounded-lg duration-100 focus:ring-4 focus:ring-blue-300 ${quantity === 0 ? 'bg-gray-300 text-gray-400 cursor-not-allowed' : 'bg-[#334c83] text-white hover:bg-[#99aeda] hover:text-[#334c83] cursor-pointer'}`}
                onClick={handleAddToCart}
                disabled={quantity === 0}
              >
                <TbShoppingCartPlus className="text-xl mr-2" />
                Add to Cart
              </button>
            </div>
          </div>
        </div>
      )}

      <ContextMenu
        x={contextMenu.x}
        y={contextMenu.y}
        visible={contextMenu.visible}
        productDto={productDto}
        pharmacyDto={pharmacyDto}
        onClose={handleCloseContextMenu}
      />
    </div>
  );
};

export default OneProduct;

