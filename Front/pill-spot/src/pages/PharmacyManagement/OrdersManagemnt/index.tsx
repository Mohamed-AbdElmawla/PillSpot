
import OrderTable from "./OrderTable";

const OrderManagementHome = () => {
  return (
    <div className=" flex w-full min-h-[86vh] h-auto max-h-[86vh] px-4 sm:px-8 md:px-16 lg:px-24 xl:px-32 items-center justify-center">
  
        <div className="w-2/3 h-full flex items-center justify-center">
         <OrderTable/>
        </div>
        <div className="bg-yellow-200 w-1/3 h-full flex items-center justify-center">
        <div className="m-10 absolute top-20 left-250">
        <table className="table table-lg">
        <thead className="sticky top-0 bg-gradient-to-r from-[#99cbf3] to-[#8abaf0] z-10">

            <tr className="text-gray-900 ">
             
              <th>Stock Status</th>
             
            </tr>
          </thead>
          <tbody>{}</tbody>
          <tfoot>
            <tr></tr>
          </tfoot>
        </table>
      </div>
        </div>
      
    </div>
  );
};

export default OrderManagementHome;
