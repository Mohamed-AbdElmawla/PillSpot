import { medicines } from "./tempData";
import InventoryRow from "./InventoryRow";
import InventoryHeader from "./InventoryHeader";
import { useState } from "react";
import { MdErrorOutline } from "react-icons/md";


const InventoryPage = () => {
  const [searchItem, setSearchItem] = useState("");

  const filteredMedicines = medicines.filter((p) =>
    p.name.toLowerCase().startsWith(searchItem.toLowerCase()) 
  );

  
  const renderedRows = filteredMedicines.map((p) => (
    <InventoryRow
      key={p.id}
      id={p.id}
      name={p.name}
      catetory={p.catetory}
      exp={p.exp}
      manfactr={p.manfactr}
      price={p.price}
      quantity={p.quantity}
      stksts={p.stksts}
    />
  ));

  return (
    <>
      <InventoryHeader setSearchItem={setSearchItem} />
      {(renderedRows.length>0) ?  
      <div className="m-10 absolute top-20 left-14">
        <table className="table table-lg">
        <thead className="sticky top-0 bg-gradient-to-r from-[#99cbf3] to-[#8abaf0] z-10">

            <tr className="text-gray-900 ">
              <th></th>
              <th></th>
              <th>Name</th>
              <th></th>
              <th>Manufacturer</th>
              <th>Quantity</th>
              <th>Category</th>
              <th>Expiration Date</th>
              <th>Price</th>
              <th>Stock Status</th>
              <th></th>
              <th></th>
            </tr>
          </thead>
          <tbody>{renderedRows}</tbody>
          <tfoot>
            <tr></tr>
          </tfoot>
        </table>
      </div>
      : <div className="flex items-center flex-col absolute gap-20 text-gray-400">
        <h1 className="text-4xl font-bold">No Items Found !</h1>
        <MdErrorOutline className="text-9xl" />

      </div>

}
    </>
  );
};

export default InventoryPage;
