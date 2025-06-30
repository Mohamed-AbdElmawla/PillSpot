import { InputNumber, InputNumberProps } from "antd";
import { useDispatch, useSelector } from "react-redux";
import { toast } from "sonner";
import { AppDispatch, RootState } from "../../../app/store";
import { useState } from "react";
import { FetchInventoryData } from "../../../features/Pharmacy/AddInventoryProduct/AddInventoryProductSlice";
import { FetchHomeProducts } from "../../../features/HomePage/Products/fetchProdcuts";
import axiosInstance from "../../../features/axiosInstance";

interface IMedicine {
  manufacturer: string;
  dosage: string;
  productId: string;
  name: string;
  description: string;
  imageURL: string;
  createdDate: string;
  subCategoryDto: {
    subCategoryId: string;
    name: string;
  };
}

interface OneProductProps {
  medicine: IMedicine;
}

const OneProduct: React.FC<OneProductProps> = ({ medicine }) => {

    const [quantity,setQuantity] = useState(0) ;
    const PharmacyId = useSelector((state:RootState)=>state.currentPharmacy.pharmacy?.pharmacyId) ;
    const dispatch = useDispatch<AppDispatch>();

  const onChange: InputNumberProps["onChange"] = (value) => {
    setQuantity(Number(value));
  };



  console.log(quantity)

  const handleClick = () => {

    console.log({productId:medicine.productId,pharmacyId:PharmacyId,quantity:quantity})
    const fetchData = async () => {
      const response = await axiosInstance
            .post("api/pharmacyproducts" , {productId:medicine.productId,pharmacyId:PharmacyId,quantity:quantity});
        return response.data;
    };

    toast.promise(fetchData(), {
        loading: "Loading...",
        success: () => {
         
          dispatch(FetchInventoryData(PharmacyId));
          dispatch(FetchHomeProducts({PageNumber:"1",PageSize:"11"})) ;
    
          return "Medicines Added to Inventory";
        },
        error: (error) => error.message || "Something went wrong",
    });
  };

  return (
    <div className="flex flex-col flex-wrap m-4 justify-between items-center bg-gray-100 shadow-md p-3 rounded-lg gap-4 sm:gap-2">
      <div className="flex flex-col items-center">
        <img
          src={`${import.meta.env.VITE_BASE_URL}${medicine.imageURL}`}
          className="w-30 h-30 rounded-full"
          alt={medicine.name}
        />
        <div className="flex flex-col m-2 items-center justify-center">
          <span className="font-bold text-lg sm:text-xl text-blue-900">
            {medicine.name}
          </span>
          <span className="text-xl text-blue-900">{medicine.description}</span>
        </div>
      </div>

      <div className="flex items-center w-full sm:w-auto mb-3">
        <span className="mr-3 text-blue-900">Enter Quantity you have:</span>
        <InputNumber
          min={1}
          max={1000}
          defaultValue={0}
          onChange={onChange}
          changeOnWheel
          size="large"
          className="font-bold w-full sm:w-auto"
          placeholder="Quantity"
        />
      </div>

      <button
        className="btn btn-primary rounded-2xl bg-blue-600 px-4 py-2 w-full sm:w-auto"
        onClick={handleClick}
      >
        Add to inventory
      </button>
    </div>
  );
};

export default OneProduct;
