
import OneOrderRow from "./OneOrderRow";

const OrdersRows = () => {
  
  return (
    <div className="overflow-hidden">
      <table className="table">
        <thead>
          <tr className="text-[#02457A] font-bold text-xl">
            <th></th>
            <th>Item</th>
            <th>Price</th>
            <th>Quantity</th>
            <th>Total</th>
            <th></th>
          </tr> 
        </thead>
        <tbody>
          <OneOrderRow/>
          <OneOrderRow/>
          <OneOrderRow/>
          <OneOrderRow/>
         
        </tbody>
    
      </table>
    </div>
  );
};

export default OrdersRows;
