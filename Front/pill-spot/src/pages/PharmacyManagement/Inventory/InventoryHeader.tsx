import { IoIosSearch } from "react-icons/io";
import { LuFilter } from "react-icons/lu";
import { IoAdd } from "react-icons/io5";
import { Dispatch, SetStateAction, useState } from "react";
import { addMedicine, InputNames } from "../EditAddModal/data";
import AddProductModal from "./AddProductModal";

interface IProps {
  setSearchItem: Dispatch<SetStateAction<string>>;
}

type KeyType = keyof typeof InputNames;
const DefaultData: Record<KeyType, string> = {
  [InputNames.MedicineName]: "",
  [InputNames.Manufacturer]: "",
  [InputNames.Quantity]: "",
  [InputNames.Category]: "",
  [InputNames.exp]: "",
  [InputNames.price]: "",
};

console.log(DefaultData);

const InventoryHeader = ({ setSearchItem }: IProps) => {
  const [medecineData, setData] = useState(DefaultData);

  function handleChange(
    e:
      | React.ChangeEvent<HTMLInputElement>
      | React.ChangeEvent<HTMLSelectElement>
  ) {
    const { value, name } = e.target;
    setData((prev) => ({
      ...prev,
      [name]: value,
    }));
  }

  console.log(medecineData);

  return (
    <div className="flex items-start justify-start m-10">
      <div className="flex items-center justify-start left-23 top-15 absolute gap-3">
        <div>
          <IoIosSearch className="text-2xl text-gray-400" />
        </div>
        <input
          type="text"
          className="border border-white outline-none focus:border-gray-300 rounded-2xl indent-3 h-10"
          placeholder="Enter item to search"
          onChange={(e) => setSearchItem(e.target.value)}
        />
      </div>
      <div className="flex items-center justify-start left-[1000px] top-15 absolute gap-18">
        <div className="flex gap-2 ">
          <LuFilter className="text-2xl text-gray-400" />
          <span className="text-gray-400">Filter</span>
        </div>

        <AddProductModal
          buttonText="Add Medicine"
          buttonStyle="btn bg-[#78b5ee] text-blue-800 font-bold border-white outline-none rounded-2xl h-10"
          inputData={addMedicine}
          handleChange={handleChange}
        >
          <IoAdd className="text-blue-800 font-bold text-xl" />
        </AddProductModal>
      </div>
    </div>
  );
};

export default InventoryHeader;
