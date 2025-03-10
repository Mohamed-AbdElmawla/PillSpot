import { ChangeEvent, useState } from "react";

const FilterRows = () => {
  const [inpt, setInpt] = useState("");
  const [curPage, setCurPage] = useState("");

  function handleChange(e: ChangeEvent<HTMLInputElement>) {
    const { value } = e.target;
    setInpt(value); // Ensure setInpt is defined
  }
  console.log(inpt);

  return (
    <div className="flex flex-col bg-gray-100 p-5 rounded-2xl ">
      <span className="font-bold mt-3">Filter Rows By : </span>
      <div className="flex gap-1 text-sm font-bold mt-3">
        <button
          className="bg-[#CBE8FF] p-2 rounded-2xl hover:bg-blue-400 duration-200 cursor-pointer"
          onClick={() => setCurPage("cn")}
        >
          Customer Name
        </button>
        <button
          className="bg-[#CBE8FF] p-2 rounded-2xl hover:bg-blue-400 duration-200 cursor-pointer"
          onClick={() => setCurPage("op")}
        >
          Order Price
        </button>
        <button
          className="bg-[#CBE8FF] p-2 rounded-2xl hover:bg-blue-400 duration-200 cursor-pointer"
          onClick={() => setCurPage("od")}
        >
          Order Date
        </button>
      </div>
      <div className="rounded-2xl p-5 flex flex-col gap-3">
        <span className="ml-1 font-bold">Enter Name : </span>
        <input
          type="text"
          className="rounded-2xl indent-3 border-0 outline-none bg-[#CBE8FF] h-10"
          onChange={handleChange}
          value={inpt}
        />
        {curPage !== "cn" && (
          <div className="flex justify-around">
            <div className="items-start flex flex-col font-bold">
              {curPage === "op" ? (
                <>
                  <p>Filter by higher price</p>
                  <p>Filter by lower price</p>
                </>
              ) : (
                <>
                  <p>Filter by date after</p>
                  <p>Filter by date before</p>
                </>
              )}
            </div>
            <div className="items-center justify-around flex flex-col">
              <input type="radio" name="radioBtn" />
              <input type="radio" name="radioBtn" />
            </div>
          </div>
        )}
      </div>
    </div>
  );
};

export default FilterRows;
