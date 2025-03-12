import { useState } from "react";
import OrderTable from "./OrderTable";
import { DayPicker } from "react-day-picker";
import "react-day-picker/dist/style.css";
import FilterRows from "./search";

const OrderManagementHome = () => {
  const [selected, setSelected] = useState<Date | undefined>(undefined);
  // const [filterData, setFilterData] = useState({
  //   data: "",
  //   lower: false,
  //   upper: false,
  // });

  return (
    <>
      <div className="flex w-full absolute inset-0 overflow-x-hidden">
        <div className="flex-[3] top-0">
          <OrderTable />
        </div>
        <div className="flex-1  mt-10 mr-10 flex flex-col justify-around sticky top-0">
          <div>
            <FilterRows />
          </div>
          <div className="bg-[#CBE8FF] p-5 rounded-3xl">
            <DayPicker
              mode="single"
              selected={selected}
              onSelect={setSelected}
              classNames={{
                caption: "bg-red-400",
                day: "text-[#666666] font-bold",
                day_selected: "bg-blue-600 text-white",
              }}
            />
          </div>
        </div>
      </div>
    </>
  );
};

export default OrderManagementHome;
