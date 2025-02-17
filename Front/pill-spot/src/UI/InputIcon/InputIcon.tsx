
import { defaultFromData } from "../../components/SignUpModel/data";
import { SvgIcon } from "../SvgIcon"
import { Iprops } from "./typs"
import { ChangeEvent } from "react";

const InputIcon = ({name,placeHolder,type,icon,setSignUpData}:Iprops) => {

  function handleChange(event: ChangeEvent<HTMLInputElement>) {
    const { value } = event.target;
    defaultFromData[name] = value ;
    setSignUpData(defaultFromData) ;
  }

  return (
    <>
  
   
    <div className="relative flex items-center m-5">
     
      <span className="absolute left-3 text-[#02457A]">
        <SvgIcon width="30" height="30" src={icon}/>
        
      </span>
      <input
        className="text-[#02457A] font-bold pl-10 border border-gray-300 rounded-md p-2 w-full focus:outline-none focus:ring-2 focus:ring-[#02457A] indent-9 p-9"
        type={type}
        name={name}
        id={name}
        placeholder={placeHolder}
        onChange={handleChange}
      />
    </div>
  </>
  
  )
}

export default InputIcon
