import { BiEdit } from "react-icons/bi";
import { useState } from "react";
import { useDispatch } from "react-redux";
import type { AppDispatch } from "../../../app/store";
import { UpdateProductQuantity, FetchInventoryData } from "../../../features/Pharmacy/AddInventoryProduct/AddInventoryProductSlice";
import EditQuantityModal from "./EditQuantityModal";
import type { AnyAction } from "@reduxjs/toolkit";


interface IProduct {
  quantity: number;
  productDto: {
    productId: string;
    subCategoryDto: null | object; 
    name: string;
    description: string;
    price: number;
    imageURL: string;
    createdDate: string;
  };
  pharmacyDto: {
    pharmacyId: string;
    name: string;
    logoURL: string;
    logo: null | string; 
    locationDto: null | object; 
    contactNumber: string;
    openingTime: string;
    closingTime: string;
    isOpen24: boolean;
    daysOpen: string;
  };
}

interface IProps {
   data : IProduct;
}


const InventoryRow = (props:IProps) => {
    const myMap = new Map();
    myMap.set("In Stock", "badge badge-soft badge-accent");
    myMap.set("Low Stock", "badge badge-soft badge-warning");
    myMap.set("No Stock", "badge badge-soft badge-error");
    const dispatch = useDispatch<AppDispatch>();
    const [modalOpen, setModalOpen] = useState(false);
    const [quantity, setQuantity] = useState(props.data.quantity);
    const [minStock, setMinStock] = useState(1);
    const [isAvailable, setIsAvailable] = useState(true);

    const handleEditClick = () => setModalOpen(true);
    const handleClose = () => setModalOpen(false);
    const handleModalSubmit = ({ quantity, minStock, isAvailable }: { quantity: number; minStock: number; isAvailable: boolean }) => {
      dispatch(
        UpdateProductQuantity({
          pharmacyId: props.data.pharmacyDto.pharmacyId,
          productId: props.data.productDto.productId,
          body: {
            quantity: Number(quantity),
            isAvailable,
            minimumStockThreshold: Number(minStock),
          },
        })
      ).then((action: AnyAction) => {
        if (action.type.endsWith('/fulfilled')) {
          dispatch(FetchInventoryData(props.data.pharmacyDto.pharmacyId));
        }
      });
      setQuantity(quantity);
      setMinStock(minStock);
      setIsAvailable(isAvailable);
    };

  return (
    <tr className="font-bold ">
      <th></th>
        <th></th>
      <td>{props.data.productDto.name}</td>
        <th></th>
      <td>{props.data.productDto.description}</td>
      <td>{props.data.quantity}</td>
      <td>
        <div className="badge badge-soft badge-primary">Soon</div>
      </td>
      <td>{props.data.productDto.createdDate}</td>
      <td>{props.data.productDto.price}</td>
      <td>
        <div className="badge badge-soft badge-accent">Soon</div>
      </td>
      <td className="text-gray-400 font-bold">
        <span onClick={handleEditClick} style={{ cursor: "pointer" }}>
          <BiEdit />
        </span>
        <EditQuantityModal
          open={modalOpen}
          onClose={handleClose}
          onSubmit={handleModalSubmit}
          initialQuantity={quantity}
          initialMinStock={minStock}
          initialIsAvailable={isAvailable}
          productName={props.data.productDto.name}
        />
      </td>
    </tr>
  );
};

export default InventoryRow;
