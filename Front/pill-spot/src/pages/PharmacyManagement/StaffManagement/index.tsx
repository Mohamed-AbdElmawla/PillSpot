import { useState } from "react";
import FiltersButtons from "./FiltersButtons";
import SearchBar from "./SearchBar";
import StaffCard from "./StaffCard";


const StaffManagement = () => {
  const [selectedStaff, setSelectedStaff] = useState("1");
  const [searchStaff, setSearchStaff] = useState("");
  return (
    <div className="flex flex-col m-10 mt-10">
      <FiltersButtons setSelectedStaff={setSelectedStaff} />
      <SearchBar setSearchStaff={setSearchStaff} />

      <div className="grid grid-cols-1 lg:grid-cols-3 gap-5 mt-10">
        <StaffCard />
      </div>
      <div>{selectedStaff}</div>
      <div>{searchStaff}</div>
    </div>
  );
};

export default StaffManagement;
