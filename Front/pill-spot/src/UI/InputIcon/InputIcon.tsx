import { useState } from "react";
import { Iprops } from "./typs";
import { GoEye, GoEyeClosed } from "react-icons/go";
const InputIcon = ({ ...rest }: Iprops) => {
  const [isPasswordVisible, setIsPasswordVisible] = useState(false);

  const togglePasswordVisibility = () => {
    setIsPasswordVisible((prevVisibility) => !prevVisibility);
  };

  const inputType = isPasswordVisible ? "text" : rest.type;

  return (
    <>
      <div className="container">
        <input
          className="text-[#02457A] font-bold pl-10 border border-gray-300 rounded-md  focus:outline-none focus:ring-2 focus:ring-[#02457A] indent-9 p-9"
          {...rest}
          type={inputType}
        />
        {rest.type === "password" &&
          (isPasswordVisible ? (
            <GoEyeClosed
              onClick={togglePasswordVisibility}
              className="absolute right-3 top-1/2 transform -translate-y-1/2 cursor-pointer text-gray-500 hover:text-[#02457A] transition-colors duration-200"
            />
          ) : (
            <GoEye
              onClick={togglePasswordVisibility}
              className="absolute right-3 top-1/2 transform -translate-y-1/2 cursor-pointer text-gray-500 hover:text-[#02457A] transition-colors duration-200"
            />
          ))}
      </div>
    </>
  );
};

export default InputIcon;
