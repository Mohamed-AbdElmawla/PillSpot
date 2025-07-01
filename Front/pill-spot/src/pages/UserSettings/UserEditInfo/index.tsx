import React, { ReactNode, useState } from "react";
import { BiCamera } from "react-icons/bi";
import { FiPhone, FiUser } from "react-icons/fi";
import { HiOutlineMail } from "react-icons/hi";
import { MdOutlineEdit } from "react-icons/md";
import { CiFlag1 } from "react-icons/ci";
import { PiCityLight } from "react-icons/pi";
import { FaBarcode } from "react-icons/fa";
import { GrContactInfo } from "react-icons/gr";
import { PiPasswordBold } from "react-icons/pi";
import { CgUserRemove } from "react-icons/cg";
import img from "./image copy.png";
import { Input } from "antd";
import { IcurUser } from "../../../features/User/types";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../../app/store";
import Swal from "sweetalert2";
import {
  editCurUser,
  editCurUserPassword,
  getCurUser,
} from "../../../features/User/UserSlcie";
import { validateInput } from "../../../helper/Validation";
import { deleteAccount , logout } from "../../../features/auth/authLogin";

interface IInputs {
  label: string;
  icon: ReactNode;
  value: string;
  name: string;
  type?: string;
}

const inputNames = {
  FirstName: "FirstName",
  LastName: "LastName",
  DateOfBirth: "DateOfBirth",
  Info: "PhoneNumber",
  Country: "Country",
  City: "City",
  PostaCode: "PostaCode",
  password: "Password",
  newPassword: "NewPassword",
  phoneNumber: "PhoneNumber",
};

const PersonalInfo: IInputs[] = [
  {
    label: "First Name",
    icon: <FiUser className="text-2xl" />,
    value: "Mohamed Ramadfdasan",
    name: inputNames.FirstName,
    type: "text",
  },
  {
    label: "Last Name",
    icon: <FiUser className="text-2xl" />,
    value: "0123456789",
    name: inputNames.LastName,
    type: "text",
  },
  {
    label: "Date Of Birth",
    icon: <HiOutlineMail className="text-2xl" />,
    value: "email@example.com",
    name: inputNames.DateOfBirth,
    type: "date",
  },
  {
    label: "Phone Number",
    icon: <FiPhone className="text-2xl" />,
    value: "email@example.com",
    name: inputNames.phoneNumber,
    type: "text",
  },
];

// const AddressInfo: IInputs[] = [
//   {
//     label: "Country",
//     icon: <CiFlag1 className="text-2xl" />,
//     value: "Mohamed Ramadfdasan",
//     name: inputNames.Country,
//   },
//   {
//     label: "City",
//     icon: <PiCityLight className="text-2xl" />,
//     value: "0123456789",
//     name: inputNames.City,
//   },
//   {
//     label: "Posta Code",
//     icon: <FaBarcode className="text-2xl" />,
//     value: "email@example.com",
//     name: inputNames.PostaCode,
//   },
// ];

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
    name: "confirmPassword",
  },
];

const UserEditInofPage = () => {
  const curUser: IcurUser | string | null = useSelector(
    (state: RootState) => state.CurUserSlice.curUser
  );

  const editUserState = useSelector(
    (state: RootState) => state.CurUserSlice.isLoading
  );

  const userNm = curUser!.userName;

  console.log(curUser.dateOfBirth);

  const dateOfBirth = new Date(curUser.dateOfBirth);

  const formattedDate =
    dateOfBirth.getDate() +
    "-" +
    (Number(dateOfBirth.getMonth()) + 1).toString() +
    "-" +
    dateOfBirth.getFullYear();

  console.log(formattedDate);

  const defaultData: Record<string, string> = {
    [inputNames.FirstName]: curUser.firstName,
    [inputNames.LastName]: curUser.lastName,
    [inputNames.phoneNumber]: curUser.phoneNumber,
    [inputNames.DateOfBirth]: curUser.dateOfBirth,
    [inputNames.password]: "",
    [inputNames.newPassword]: "",
  };

  const defaultDataErrors: Record<string, string | null> = {
    [inputNames.FirstName]: null,
    [inputNames.LastName]: null,
    [inputNames.phoneNumber]: null,
    [inputNames.DateOfBirth]: null,
    [inputNames.password]: null,
    [inputNames.newPassword]: null,
  };

  const [UserData, setUserData] = useState(defaultData);
  const [UserDataErrors, setUserDataErrors] = useState(defaultDataErrors);
  const [activePage, setActivePage] = useState(1);
  const [selectedImage, setSelectedImage] = useState("");
  const [userImageFile, setFile] = useState<File | null>(null);
  const dispatch = useDispatch<AppDispatch>();

  
  console.log(userImageFile);

  const handleImageChange = (
    event: React.ChangeEvent<HTMLInputElement>
  ): void => {
    const file: File | null = event.target.files ? event.target.files[0] : null;
    if (file) {
      setFile(file);
      const imageUrl: string = URL.createObjectURL(file);
      setSelectedImage(imageUrl);
    }
  };

  console.log(curUser);

  console.log(curUser.profilePictureUrl);

  console.log(UserData);

  async function handleMainInfo() {
    console.log(userNm);


    const errors = {
      FirstName: validateInput(UserData.FirstName, "name"),
      LastName: validateInput(UserData.LastName, "name"),
      PhoneNumber: validateInput(UserData.PhoneNumber, "phoneNumber"),
    };

    setUserDataErrors((prev) => ({ ...prev, ...errors }));

    console.log(errors) ;

    if(errors.FirstName || errors.LastName || errors.PhoneNumber){
      console.log("Okay Sir 🫡");
      return ;
    }



    const dataToSend = {
      curUser: {
        FirstName: UserData.FirstName,
        LastName: UserData.LastName,
        DateOfBirth: UserData.DateOfBirth,
        PhoneNumber: UserData.PhoneNumber,
      },
      userImage: userImageFile,
      userName: userNm,
    };

    console.log(dataToSend);

    try {
      await dispatch(editCurUser(dataToSend));
      dispatch(getCurUser(userNm));
    } catch (error) {
      console.error("Error updating user:", error);
    }
  }

  console.log(UserDataErrors);
  async function handlePassword() {
    console.log(
      UserData.Password,
      UserData.NewPassword,
      UserData.confirmPassword
    );

    const errors = {
      Password: validateInput(UserData.Password, "password"),
      NewPassword: validateInput(UserData.NewPassword, "password"),
    };

    setUserDataErrors((prev) => ({ ...prev, ...errors }));

    const dataToSend = {
      oldPassword: UserData.Password,
      newPassword: UserData.NewPassword,
      confirmPassword: UserData.confirmPassword,
      userName: userNm,
    };

    if (errors.Password || errors.NewPassword) {
      console.log("Okay Sir 🫡");
      return;
    }

    try {
      const res = await dispatch(editCurUserPassword(dataToSend));
      console.log(res) ;
      if (res.type.endsWith('rejected') && res.payload) {
        console.log("Ok sir");
        return;
      }
      Swal.fire({
        title: "Password Reset Successful!",
        text: "Do you want to log out from all devices or continue?",
        icon: "success",
        showCancelButton: true,
        confirmButtonText: "Logout from all devices",
        cancelButtonText: "Continue without logout",
      }).then((result) => {
        if (result.isConfirmed) {
          // dispatch(logOut()) ;
          dispatch(logout()) ;
          console.log("User chose to stay logged in.");
        } else {
          console.log("User chose to stay logged in.");
        }
      });
      setUserData((prev) => ({
        ...prev,
        Password: "",
        NewPassword: "",
        confirmPassword: "",
      }));
    } catch (error) {
      console.error("Error updating user:", error);
    }
  }

  const mainInofComponent = (
    <>
      {/* {editUserState === true ? (
        <span className="loading loading-infinity w-30 text-blue-900"></span>
      ) : ( */}
      <>
        <div className="relative w-48 h-48 sm:w-60 sm:h-60">
          <div className="w-full h-full rounded-full overflow-hidden border-4 border-gray-300 shadow-md">
            <img
              src={
                selectedImage ||
                `${import.meta.env.VITE_BASE_URL}${curUser.profilePictureUrl}`
              }
              alt="Profile"
              className="w-full h-full object-cover"
            />
          </div>
          <input
            type="file"
            accept="image/*"
            className="hidden"
            id="fileInput"
            onChange={handleImageChange}
          />
          <label
            htmlFor="fileInput"
            className="absolute bottom-2 right-2 bg-blue-500 p-2 rounded-full border-2 border-white shadow-md cursor-pointer"
          >
            <BiCamera className="w-5 h-5 text-white" />
          </label>
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
              {item.type === "date" ? (
                <input
                  type={item.type}
                  className="h-8 sm:h-10 text-base sm:text-lg md:text-xl indent-2 rounded-xl border-gray-400 w-full bg-white border-0"
                  value={
                    UserData[item.name]
                      ? new Date(
                          new Date(UserData[item.name]).getTime() -
                            new Date(UserData[item.name]).getTimezoneOffset() *
                              60000
                        )
                          .toISOString()
                          .split("T")[0]
                      : ""
                  }
                  name={item.name}
                  onChange={handleChange}
                />
              ) : (
                <input
                  type={item.type}
                  className="h-8 sm:h-10 text-base sm:text-lg md:text-xl indent-2 rounded-xl border-gray-400 w-full bg-white border-0"
                  value={UserData[item.name]}
                  name={item.name}
                  onChange={handleChange}
                />
              )}
              {UserDataErrors[item.name] && (
                <span className="text-red-500 text-sm">
                  {UserDataErrors[item.name]}
                </span>
              )}
            </div>
          ))}
          <div className="flex justify-center md:justify-end gap-4">
            <button
              onClick={handleMainInfo}
              className="bg-[#02457A] hover:bg-green-600 transition rounded-xl w-40 text-white p-2 flex justify-center gap-2 items-center shadow-md"
            >
              <MdOutlineEdit className="text-white text-xl" />
              <span className="font-semibold">Save Changes</span>
            </button>
          </div>
        </div>
      </>
      {/* )} */}
    </>
  );

  // const addressInfo = (
  //   <>
  //     <div className="grid grid-cols-1 gap-5 w-full max-w-md p-2 sm:p-5">
  //       {AddressInfo.map((item, index) => (
  //         <div
  //           key={index}
  //           className="flex flex-col gap-1 items-start text-[#02457A] font-bold w-full"
  //         >
  //           <label className="flex items-center text-base sm:text-lg md:text-xl font-bold gap-2">
  //             {item.icon}
  //             {item.label}
  //           </label>
  //           <input
  //             type="text"
  //             className="h-8 sm:h-10 text-base sm:text-lg md:text-xl indent-2 rounded-xl border-gray-400 w-full bg-white border-0"
  //             value={UserData[item.name]}
  //             name={item.name}
  //             onChange={handleChange}
  //           />
  //         </div>
  //       ))}
  //       <div className="flex justify-center md:justify-end gap-4">
  //         <button className="bg-[#02457A] hover:bg-green-600 transition rounded-xl w-40 text-white p-2 flex justify-center gap-2 items-center shadow-md">
  //           <MdOutlineEdit className="text-white text-xl" />
  //           <span className="font-semibold">Save Changes</span>
  //         </button>
  //       </div>
  //     </div>
  //   </>
  // );

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
              allowClear
              placeholder="Input password"
              className="h-8 sm:h-10 text-base sm:text-lg md:text-xl indent-2 rounded-xl border-gray-400 w-full bg-white border-0"
              value={UserData[item.name]}
              name={item.name}
              onChange={handleChange}
            />
           
            {UserDataErrors[item.name] && (
              <span className="text-red-500 text-sm">
                {UserDataErrors[item.name]}
              </span>
            )}
          </div>
        ))}

        <div className="flex justify-center md:justify-end gap-4">
          <button
            onClick={handlePassword}
            className="bg-[#02457A] hover:bg-green-600 transition rounded-xl w-40 text-white p-2 flex justify-center gap-2 items-center shadow-md"
          >
            <MdOutlineEdit className="text-white text-xl" />
            <span className="font-semibold">Save Changes</span>
          </button>
        </div>
      </div>
    </>
  );


  function handleDelete(){
    Swal.fire({
      title: "Delete account!",
      text: "Are you sure to delete your account !?",
      icon: "question",
      showCancelButton: true,
      confirmButtonText: "Yes, Delete Account",
      cancelButtonText: "Cancle",
    }).then((result) => {
      if (result.isConfirmed) {
        dispatch(deleteAccount(userNm));
        dispatch(logout());
      } else {
        console.log("User chose to stay logged in.");
      }
    });
  }

  const deleteAccountPage =

    

    <div className="flex justify-center items-center flex-col gap-30">
 
      <div className="w-full max-w-xl h-60 flex flex-col items-center justify-center p-6 shadow-lg bg-blue-50 rounded-2xl text-center">
        <h2 className="text-xl font-semibold text-gray-800">Thinking of Deleting Your Account?</h2>
        <p className="text-gray-600 mt-2">
          If you delete your account, all your data will be permanently removed and cannot be recovered.
        </p>
        <button className="mt-4 bg-red-500 hover:bg-red-600 text-white px-4 py-2 rounded-lg" onClick={handleDelete}>
          Delete My Account
        </button>
      </div>
  
      
      <div className="w-full max-w-xl h-60 flex flex-col items-center justify-center p-6 shadow-lg bg-yellow-50 rounded-2xl text-center">
        <h2 className="text-xl font-semibold text-gray-800">Want to Deactivate Your Account?</h2>
        <p className="text-gray-600 mt-2">
          If you deactivate your account, your data will be saved, and you can reactivate it by logging in again.
        </p>
        <button className="mt-4 bg-yellow-500 hover:bg-yellow-600 text-white px-4 py-2 rounded-lg">
          Deactivate My Account
        </button>
      </div>
    </div>
  
  

  function handleChange(e: React.ChangeEvent<HTMLInputElement>) {
    const { name, value } = e.target;
    setUserData((prev) => ({
      ...prev,
      [name]: value,
    }));
  }

  const Pages = [mainInofComponent, passwordInfo, deleteAccountPage];

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
              <PiPasswordBold className="text-6xl sm:text-7xl md:text-9xl absolute left-1/2 transform -translate-x-1/2 transition-all duration-300 group-hover:left-20" />
              <span className="font-bold absolute opacity-0 transition-opacity duration-300 text-base sm:text-lg md:text-xl group-hover:opacity-100 group-hover:left-44">
                Password
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
          {editUserState === true ? (
            <span className="loading loading-infinity w-30 text-blue-900"></span>
          ) : (
            Pages[activePage - 1]
          )}
        </div>
      </div>
    </>
  );
};

export default UserEditInofPage;
