import InventoryRow from "./InventoryRow";
import InventoryHeader from "./InventoryHeader";
import { useEffect, useState } from "react";
import { MdErrorOutline } from "react-icons/md";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../../app/store";
import { FetchInventoryData } from "../../../features/Pharmacy/AddInventoryProduct/AddInventoryProductSlice";

interface IData {
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

const InventoryPage = () => {
  const [searchItem, setSearchItem] = useState("");
  const [PharmacyInventory, setInventory] = useState<IData[]>([]);
  const dispatch = useDispatch<AppDispatch>();
  const [filteredMedicines, setFilteredMedicines] = useState(PharmacyInventory);
  const id = useSelector(
    (state: RootState) => state.currentPharmacy.pharmacy?.pharmacyId
  );

  useEffect(() => {
    if (id) {
      dispatch(FetchInventoryData(id));
    }
  }, [id, dispatch]);

  const data = useSelector(
    (state: RootState) => state.FetchInventoryDataSlice.inventoryData
  );

  useEffect(() => {
    setInventory(data);
  }, [data]);

  useEffect(() => {
    const filtered = PharmacyInventory.filter((p) =>
      p.productDto.name.toLowerCase().startsWith(searchItem.toLowerCase())
    );

    setFilteredMedicines(filtered);
  }, [searchItem, PharmacyInventory]);

  const renderedRows = filteredMedicines.map((p) => (
    <InventoryRow key={p.productDto.productId} data={p} />
  ));

  return (
    <>
      <InventoryHeader setSearchItem={setSearchItem} />
      {renderedRows.length > 0 ? (
        <div className="m-10 absolute top-20 left-14">
          <table className="table table-lg">
            <thead className="sticky top-0 bg-gradient-to-r from-[#99cbf3] to-[#8abaf0] z-10">
              <tr className="text-gray-900">
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
      ) : (
        <div className="flex items-center flex-col gap-20 text-gray-400">
          <h1 className="text-4xl font-bold">No Items Found!</h1>
          <MdErrorOutline className="text-9xl" />
        </div>
      )}
    </>
  );
};

export default InventoryPage;
