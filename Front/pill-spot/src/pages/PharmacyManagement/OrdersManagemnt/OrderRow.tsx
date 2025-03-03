import { BiEdit } from "react-icons/bi";


interface Iprops{
    id?:string ;
    customerName : string ; 
    orderPrice : string ;
    date : string ; 
    status? : string ;
}
const OrderRow = (props:Iprops) => {
 
  return (
    <tr className="font-bold ">
      <th>{props.id}</th>
      
      <td>{props.customerName}</td>
     
      <td>{props.orderPrice}</td>
    
      
      <td>{props.date}</td>
      <td>Icon</td>
      <td>Icon</td>
      
      
      <td className="text-gray-400 font-bold">
        <BiEdit />
      </td>
    </tr>
  );
};

export default OrderRow;
