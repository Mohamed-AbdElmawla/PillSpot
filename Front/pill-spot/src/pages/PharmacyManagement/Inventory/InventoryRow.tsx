import { BiEdit } from "react-icons/bi";


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
        <BiEdit />
      </td>
    </tr>
  );
};

export default InventoryRow;
