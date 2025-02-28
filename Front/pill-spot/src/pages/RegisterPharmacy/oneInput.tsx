import { DetailedHTMLProps, InputHTMLAttributes, useState } from "react";

import { GoEye, GoEyeClosed } from "react-icons/go";

interface Iprops
  extends DetailedHTMLProps<
    InputHTMLAttributes<HTMLInputElement>,
    HTMLInputElement
  > {
  name: string;
  placeHolder: string;
  type: string;
}

const OneInput = ({ children, ...rest }: Iprops) => {
  const [isPasswordVisible, setIsPasswordVisible] = useState(false);

  const togglePasswordVisibility = () => {
    setIsPasswordVisible((prevVisibility) => !prevVisibility);
  };

  const inputType = isPasswordVisible ? "text" : rest.type;

  return (
    <div className="flex items-center relative ">
      <input
        className="h-12 sm:h-14 w-full min-w-md border indent-5 border-gray-400 rounded-2xl pl-14 pr-4 placeholder:font-bold outline-none focus:border-gray-700 text-gray-500 text-base sm:text-lg font-bold"
        {...rest}
        type={inputType}
      />
      {children}
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
  );
};

export default OneInput;
