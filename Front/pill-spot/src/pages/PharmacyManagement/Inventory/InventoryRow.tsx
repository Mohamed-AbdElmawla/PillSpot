import { BiEdit } from "react-icons/bi";


interface Iprops{
    id?:string ;
    name : string ; 
    manfactr : string ;
    quantity : string ; 
    catetory:string ;
    exp : string ; 
    price : string ;
    stksts:string ;
}
const InventoryRow = (props:Iprops) => {
    const myMap = new Map();
    myMap.set("In Stock", "badge badge-soft badge-accent");
    myMap.set("Low Stock", "badge badge-soft badge-warning");
    myMap.set("No Stock", "badge badge-soft badge-error");
    
  return (
    <tr className="font-bold">
      <th>{props.id}</th>
        <th></th>
      <td>{props.name}</td>
        <th></th>
      <td>{props.manfactr}</td>
      <td>{props.quantity}</td>
      <td>
        <div className="badge badge-soft badge-primary">{props.catetory}</div>
      </td>
      <td>{props.exp}</td>
      <td>{props.price}</td>
      <td>
        <div className={myMap.get(props.stksts)}>{props.stksts}</div>
      </td>
      <td className="text-gray-400 font-bold">
        <BiEdit />
      </td>
    </tr>
  );
};

export default InventoryRow;
