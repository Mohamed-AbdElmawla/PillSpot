import React, { ReactNode, useEffect, useState } from "react";
import { BiCamera } from "react-icons/bi";
import { FiPhone, FiUser } from "react-icons/fi";
import { HiOutlineMail } from "react-icons/hi";
import { MdOutlineEdit } from "react-icons/md";
import { CiFlag1 } from "react-icons/ci";
import { PiCityLight } from "react-icons/pi";
import { FaBarcode } from "react-icons/fa";
import { GrContactInfo } from "react-icons/gr";
import { RiUserLocationLine } from "react-icons/ri";
import { PiPasswordBold } from "react-icons/pi";
import { CgUserRemove } from "react-icons/cg";
import img from "./image copy.png";
import { Input } from "antd";

interface IInputs {
  label: string;
  icon: ReactNode;
  value: string;
  name: string;
}

const inputNames = {
  Name: "FirstName",
  PhoneNumber: "LastName",
  Email: "Email",
  Info: "PhoneNumber",
  Country: "Country",
  City: "City",
  PostaCode: "PostaCode",
  password: "Password",
  newPassword: "NewPassword",
};

const PersonalInfo: IInputs[] = [
  {
    label: "First Name",
    icon: <FiUser className="text-2xl" />,
    value: "Mohamed Ramadfdasan",
    name: inputNames.Name,
  },
  {
    label: "Last Name",
    icon: <FiUser className="text-2xl" />,
    value: "0123456789",
    name: inputNames.PhoneNumber,
  },
  {
    label: "Email",
    icon: <HiOutlineMail className="text-2xl" />,
    value: "email@example.com",
    name: inputNames.Email,
  },
  {
    label: "Phone Number",
    icon: <FiPhone className="text-2xl" />,
    value: "email@example.com",
    name: inputNames.Info,
  },
];

const AddressInfo: IInputs[] = [
  {
    label: "Country",
    icon: <CiFlag1 className="text-2xl" />,
    value: "Mohamed Ramadfdasan",
    name: inputNames.Country,
  },
  {
    label: "City",
    icon: <PiCityLight className="text-2xl" />,
    value: "0123456789",
    name: inputNames.City,
  },
  {
    label: "Posta Code",
    icon: <FaBarcode className="text-2xl" />,
    value: "email@example.com",
    name: inputNames.PostaCode,
  },
];

const PasswordInfo: IInputs[] = [
  {
    label: "Old Password",
    icon: <CiFlag1 className="text-2xl" />,
    value: "Mohamed Ramadfdasan",
    name: inputNames.password,
  },
  {
    label: "New Password",
    icon: <PiCityLight className="text-2xl" />,
    value: "0123456789",
    name: inputNames.newPassword,
  },
  {
    label: "Confirm New Password",
    icon: <FaBarcode className="text-2xl" />,
    value: "email@example.com",
    name: "newPasswordConfirmation",
  },
];

const defaultData: Record<string, string> = {
  [inputNames.Name]: "",
  [inputNames.PhoneNumber]: "",
  [inputNames.Email]: "",
  [inputNames.Info]: "",
  [inputNames.Country]: "",
  [inputNames.City]: "",
  [inputNames.PostaCode]: "",
  [inputNames.password]: "",
  [inputNames.newPassword]: "",
};

const UserEditInofPage = () => {
  const [UserData, setUserData] = useState(defaultData);
  const [activePage, setActivePage] = useState(1);
  
  


  console.log(UserData);
  
    const mainInofComponent = (
      <>
        <div className="relative w-48 h-48 sm:w-60 sm:h-60">
          <div className="w-full h-full rounded-full overflow-hidden border-4 border-gray-300 shadow-md">
            <img
              src="/src/pages/UserSettings/MainPage/images/455280085_515769004150965_1822829626503930280_n.jpg"
              alt="Profile"
              className="w-full h-full object-cover"
            />
          </div>
          <div className="absolute bottom-2 right-2 bg-blue-500 p-2 rounded-full border-2 border-white shadow-md">
            <BiCamera className="w-5 h-5 text-white" />
          </div>
        </div>
        <div className="grid grid-cols-1 gap-5 w-full max-w-3xl p-2 sm:p-5">
          {PersonalInfo.map((item, index) => (
            <div
              key={index}
              className="flex flex-col gap-1 items-start text-[#02457A] font-bold w-full"
            >
              <label className="flex items-center text-base sm:text-lg md:text-xl font-bold gap-2">
                {item.icon}
                {item.label}
              </label>
              <input
                type="text"
                className="h-8 sm:h-10 text-base sm:text-lg md:text-xl indent-2 rounded-xl border-gray-400 w-full bg-white border-0"
                value={UserData[item.name]}
                name={item.name}
                onChange={handleChange}
              />
            </div>
          ))}
          <div className="flex justify-center md:justify-end gap-4">
            <button className="bg-[#02457A] hover:bg-green-600 transition rounded-xl w-40 text-white p-2 flex justify-center gap-2 items-center shadow-md">
              <MdOutlineEdit className="text-white text-xl" />
              <span className="font-semibold">Save Changes</span>
            </button>
          </div>
        </div>
      </>
    );
  
    const addressInfo = (
      <>
        <div className="grid grid-cols-1 gap-5 w-full max-w-md p-2 sm:p-5">
          {AddressInfo.map((item, index) => (
            <div
              key={index}
              className="flex flex-col gap-1 items-start text-[#02457A] font-bold w-full"
            >
              <label className="flex items-center text-base sm:text-lg md:text-xl font-bold gap-2">
                {item.icon}
                {item.label}
              </label>
              <input
                type="text"
                className="h-8 sm:h-10 text-base sm:text-lg md:text-xl indent-2 rounded-xl border-gray-400 w-full bg-white border-0"
                value={UserData[item.name]}
                name={item.name}
                onChange={handleChange}
              />
            </div>
          ))}
          <div className="flex justify-center md:justify-end gap-4">
            <button className="bg-[#02457A] hover:bg-green-600 transition rounded-xl w-40 text-white p-2 flex justify-center gap-2 items-center shadow-md">
              <MdOutlineEdit className="text-white text-xl" />
              <span className="font-semibold">Save Changes</span>
            </button>
          </div>
        </div>
      </>
    );
  
    const passwordInfo = (
      <>
        <div className="grid grid-cols-1 gap-5 w-full max-w-md p-2 sm:p-5">
          {PasswordInfo.map((item, index) => (
            <div
              key={index}
              className="flex flex-col gap-1 items-start text-[#02457A] font-bold w-full"
            >
              <label className="flex items-center text-base sm:text-lg md:text-xl font-bold gap-2">
                {item.icon}
                {item.label}
              </label>
              <Input.Password
                placeholder="input password"
                className="h-8 sm:h-10 text-base sm:text-lg md:text-xl indent-2 rounded-xl border-gray-400 w-full bg-white border-0"
                value={UserData[item.name]}
                name={item.name}
                onChange={handleChange}
              />
            </div>
          ))}
          <div className="flex justify-center md:justify-end gap-4">
            <button className="bg-[#02457A] hover:bg-green-600 transition rounded-xl w-40 text-white p-2 flex justify-center gap-2 items-center shadow-md">
              <MdOutlineEdit className="text-white text-xl" />
              <span className="font-semibold">Save Changes</span>
            </button>
          </div>
        </div>
      </>
    );

    const deleteAccountPage = (
      <div>Do nott delete your account please</div>
    )
 

  function handleChange(e: React.ChangeEvent<HTMLInputElement>) {
    const { name, value } = e.target;
    setUserData((prev) => ({
      ...prev,
      [name]: value,
    }));
  }


  const Pages = [mainInofComponent,addressInfo,passwordInfo,deleteAccountPage];

  const notActive = "bg-blue-50 text-[#02457A]";
  const active = "bg-[#02457A] text-white";

  return (
    <>
      <div className="flex w-full h-[80vh] my-auto">
        <div className="flex-1 card rounded-box grid grow place-items-center h-[85vh] px-4">
          <div className="flex flex-col w-full items-center justify-center gap-6 sm:gap-8 md:gap-10">

            
            <button
              className={`${
                activePage === 1 ? active : notActive
              } group relative flex rounded-2xl w-full max-w-xs h-28 sm:h-32 md:h-40 
                items-center justify-center p-3 overflow-hidden hover:scale-105 cursor-pointer
                hover:text-white hover:bg-[#02457A] duration-200`}
              onClick={() => {
                setActivePage(1);
               
              }}
            >
              <GrContactInfo className="text-6xl sm:text-7xl md:text-9xl absolute left-1/2 transform -translate-x-1/2 transition-all duration-300 group-hover:left-20" />
              <span className="font-bold absolute opacity-0 transition-opacity duration-300 text-base sm:text-lg md:text-xl group-hover:opacity-100 group-hover:left-34">
                Main Information
              </span>
            </button>

            <button
              className={`${
                activePage === 2 ? active : notActive
              } group relative flex rounded-2xl w-full max-w-xs h-28 sm:h-32 md:h-40 
                items-center justify-center p-3 overflow-hidden hover:scale-105 cursor-pointer
                hover:text-white hover:bg-[#02457A] duration-200`}
              onClick={() => {
                setActivePage(2);
                
              }}
            >
              <RiUserLocationLine className="text-6xl sm:text-7xl md:text-9xl absolute left-1/2 transform -translate-x-1/2 transition-all duration-300 group-hover:left-20" />
              <span className="font-bold absolute opacity-0 transition-opacity duration-300 text-base sm:text-lg md:text-xl group-hover:opacity-100 group-hover:left-34">
                Address
              </span>
            </button>

            <button
              className={`${
                activePage === 3 ? active : notActive
              } group relative flex rounded-2xl w-full max-w-xs h-28 sm:h-32 md:h-40 
                items-center justify-center p-3 overflow-hidden hover:scale-105 cursor-pointer
                hover:text-white hover:bg-[#02457A] duration-200`}
              onClick={() => {
                setActivePage(3);
              
              }}
            >
              <PiPasswordBold className="text-6xl sm:text-7xl md:text-9xl absolute left-1/2 transform -translate-x-1/2 transition-all duration-300 group-hover:left-20" />
              <span className="font-bold absolute opacity-0 transition-opacity duration-300 text-base sm:text-lg md:text-xl group-hover:opacity-100 group-hover:left-44">
                Password
              </span>
            </button>

            <button
              className={`${
                activePage === 4 ? active : notActive
              } group relative flex rounded-2xl w-full max-w-xs h-28 sm:h-32 md:h-40 
                items-center justify-center p-3 overflow-hidden hover:scale-105 cursor-pointer
                hover:text-white hover:bg-[#02457A] duration-200`}
              onClick={() => {
                setActivePage(4);
              
              }}
            >
              <CgUserRemove className="text-6xl sm:text-7xl md:text-9xl absolute left-1/2 transform -translate-x-1/2 transition-all duration-300 group-hover:left-20" />
              <span className="font-bold absolute opacity-0 transition-opacity duration-300 text-base sm:text-lg md:text-xl group-hover:opacity-100 group-hover:left-40">
                Delete Account
              </span>
            </button>
          

          </div>
        </div>

        <div className="divider divider-horizontal"></div>
        <div
          className="flex-[4] card bg-base-300 rounded-box grid place-items-center h-[85vh]"
          style={{
            backgroundImage: `url(${img})`,
            backgroundRepeat: "no-repeat",
            backgroundSize: "cover",
            backgroundPosition: "center",
          }}
        >
          {Pages[activePage-1]}
        </div>
      </div>
    </>
  );
};

export default UserEditInofPage;
