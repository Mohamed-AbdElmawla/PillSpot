import { TbRefresh } from "react-icons/tb";

const ProductPopular = () => {
  return (
    <div className="flex flex-col bg-white shadow-md border-1 border-gray-200 h-80 px-4 rounded-xl justify-start">
      <img src="/src/pages/UserSettings/MainPage/images/image copy 2.png" className="w-50 h-50 rounded-xl mt-3" />
      <div className="flex justify-between text-xl mt-5 items-center">
        <span className="p-2 text-sm font-bold">Panadol Extra</span>
        <button className="bg-[#1C8DC9] text-white px-2 rounded-2xl text-md flex items-center gap-2 h-8 btn border-0">
          <TbRefresh />
          Reorder
        </button>
      </div>

      <span className="text-[12px] mt-2">You have purchased this 3 times</span>
    </div>
  );
};

export default ProductPopular;
