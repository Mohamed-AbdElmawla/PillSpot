import { Dispatch, SetStateAction } from "react";
import { BiSearchAlt } from "react-icons/bi";
import { IoMdAdd } from "react-icons/io";

interface Iprops{
    setSearchStaff : Dispatch<SetStateAction<string>> ;
}
const SearchBar = ({setSearchStaff}:Iprops) => {
  return (
    <div className="flex justify-between">
        <div className="flex items-center gap-2">
          <BiSearchAlt className="text-2xl text-[#666666D9] " />
          <input
            type="text"
            className="outline-none border-gray-200 rounded-2xl h-7 indent-3"
            placeholder="Search..."
            onChange={(e)=>{setSearchStaff(e.target.value)}}
          />
        </div>
        <div className="flex items-center bg-[#ACD9FD] rounded-2xl p-[5px] px-3 gap-2 cursor-pointer hover:scale-102 duration-200 text-[#026BBE]">
          <IoMdAdd />

          <button className="cursor-pointer">Add Employee </button>
        </div>
      </div>
  )
}

export default SearchBar
