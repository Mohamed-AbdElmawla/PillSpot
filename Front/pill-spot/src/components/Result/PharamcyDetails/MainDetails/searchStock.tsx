import { FaSearch } from "react-icons/fa";

import { Dispatch, SetStateAction, useState } from "react";

interface IProps {
  setSearchValue: Dispatch<SetStateAction<string>>;
}

const SearchInStock = ({ setSearchValue }: IProps) => {
  const [inpt, setInpt] = useState("");
  function handleChange(e: React.ChangeEvent<HTMLInputElement>) {
    const value = e.target.value;
    setInpt(value);
    if(!value) setSearchValue('');
  }

  function handleClick() {
    setSearchValue(inpt);
  }

  return (
    <div className="card bg-base-300 rounded-box grid place-items-center p-5 gap-5">
      <div className="flex items-center text-xl gap-2 m-auto">
        <FaSearch />
        <span className="font-semibold">Search in our stock</span>
      </div>
      <label className="floating-label">
        <span>Medicine Name</span>
        <div className="flex gap-1">
          <input
            type="text"
            placeholder="Your name"
            className="input input-md focus:outline-none focus:border-[#49708f]"
            onChange={handleChange}
          />
          <button className="btn btn-outline" onClick={handleClick}>
            <FaSearch />
          </button>
        </div>
      </label>
    </div>
  );
};

export default SearchInStock;
