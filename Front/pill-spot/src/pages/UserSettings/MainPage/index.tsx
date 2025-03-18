import { FiUser, FiPhone } from "react-icons/fi";
import { HiOutlineMail } from "react-icons/hi";
import { MdOutlineEdit } from "react-icons/md";

const UserSettingsMain = () => {
  return (
    <div className="flex flex-col lg:flex-row justify-center gap-10 p-5">
      <div className="flex flex-col items-center justify-center gap-10 flex-[1] w-full">
        <div className="flex flex-col sm:flex-row w-full sm:w-fit justify-center items-center gap-5 sm:gap-10">
          <img
            src="/src/assets/image.png"
            alt="User Avatar"
            className="w-32 h-32 sm:w-40 sm:h-40 rounded-full object-cover"
          />
          <div className="flex flex-col gap-3">
            <button className="bg-[#1C8DC9] text-white p-2 rounded-2xl cursor-pointer w-full sm:w-auto btn">
              Change Photo
            </button>
            <button className="bg-[#1C8DC9] text-white p-2 rounded-2xl cursor-pointer w-full sm:w-auto btn">
              Delete Photo
            </button>
          </div>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 gap-5 md:gap-10 w-full max-w-3xl">
          {[
            { label: "Name", icon: <FiUser />, value: "Mohamed Ramadan" },
            { label: "Phone Number", icon: <FiPhone />, value: "0123456789" },
            { label: "Email", icon: <HiOutlineMail />, value: "email@example.com" },
            { label: "Email", icon: <HiOutlineMail />, value: "email@example.com" }
          ].map((item, index) => (
            <div
              key={index}
              className="flex flex-col gap-1 items-start text-[#02457A] font-bold w-full"
            >
              <label className="flex items-center text-lg md:text-xl font-bold gap-2">
                {item.icon}
                {item.label}
              </label>
              <input
                type="text"
                className="h-10 text-lg md:text-xl border indent-2 rounded-xl border-gray-400 w-full"
                value={item.value}
              />
            </div>
          ))}
        </div>

        <div className="flex justify-end w-full max-w-3xl">
          <button className="bg-[#1C8DC9] rounded-2xl w-full sm:w-32 text-white p-2 cursor-pointer flex justify-center gap-3 items-center btn">
            <MdOutlineEdit className="text-white text-xl" />
            <span className="font-bold">Edit</span>
          </button>
        </div>
      </div>

      <div className="flex flex-col items-center justify-center gap-5 flex-1 bg-blue-200 p-5 rounded-xl w-full sm:max-w-md">
        <img
          src="/src/assets/image.png"
          alt="User Avatar"
          className="w-32 h-32 sm:w-40 sm:h-40 rounded-full object-cover"
        />
        <span className="font-bold text-xl md:text-2xl">Name</span>
      </div>
    </div>
  );
};

export default UserSettingsMain;
