
import { MdEdit } from "react-icons/md";

const StaffCard = () => {
  return (
    <div className="flex flex-col gap-5 w-fit p-5 rounded-2xl shadow-md hover:scale-105 duration-300 hover:bg-gray-100 overflow-hidden">
  
      <div className="flex items-center gap-5 flex-wrap">
        <img
          src="/src/assets/5559852.jpg"
          className="w-[100px] h-[100px] rounded-[50%] object-cover"
        />
        <div className="flex flex-col">
          <span className="text-[#1C8DC9] font-bold text-2xl break-words">Name ElName Bob</span>
          <span className="text-[#666666D9] text-sm">Inventory Mangement</span>
        </div>
      </div>

      <div className="flex gap-2 flex-wrap">
        <div className="bg-[#CBE8FF] px-3 py-1 rounded-4xl text-sm break-words">
          1231231231
        </div>
        <div className="bg-[#CBE8FF] px-3 py-1 rounded-4xl text-sm break-words">
          asdfas@gmail.com
        </div>
        <div className="bg-[#CBE8FF] w-7 h-7 flex items-center justify-center rounded-full text-xl">
          <button className="cursor-pointer">
            <MdEdit />
          </button>
        </div>
        <div className="border-red-400 border px-2 rounded-2xl text-red-400 cursor-pointer">
          <button className="cursor-pointer">remove</button>
        </div>
      </div>
    </div>

  );
};

export default StaffCard;
