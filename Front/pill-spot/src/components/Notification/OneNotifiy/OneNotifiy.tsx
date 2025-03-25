import { FaLink, FaThumbtack, FaTrash } from "react-icons/fa6";

const OneNotifiy = () => {
  return (
    <>
      <div className="bg-gray-200 h-35 p-2 py-4 shadow-xs rounded-2xl flex justify-between items-center overflow-hidden relative group">
       
        <div className="flex flex-col w-full pr-3">
          <span className="text-xl font-bold">Notification Title</span>
          <span className="text-sm">
            Notification content Notification content Notification content
            Notification content Notification content
          </span>
        </div>

       
        <div className="flex flex-col items-center justify-center px-3 bg-blue-900 rounded-2xl text-white h-20 mt-10">
          action
          <FaLink className="text-white text-3xl" />
        </div>

        
        <div className="absolute right-3 top-3 flex gap-2 opacity-100 transition-opacity ">
          <button className="text-gray-700 hover:text-gray-900 cursor-pointer">
            <FaThumbtack className="text-xl" />
          </button>
          <button className="text-red-500 hover:text-red-700 cursor-pointer">
            <FaTrash className="text-xl" />
          </button>
        </div>
      </div>

      <div className="divider"></div>
    </>
  );
};

export default OneNotifiy;
