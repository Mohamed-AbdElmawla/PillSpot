import { Iprops } from "./typs"
const InputIcon = ({...rest}:Iprops) => {

  // function handleChange(event: ChangeEvent<HTMLInputElement>) {
  //   const { name,  value } = event.target;
  //   console.log("Changing:", name, value);
  //   setSignUpData((prev)=>({
  //     ...prev , 
  //     [name] : value
  //   })) ;
  // }

  return (
    <>
      <input
        className="text-[#02457A] font-bold pl-10 border border-gray-300 rounded-md p-2 w-full focus:outline-none focus:ring-2 focus:ring-[#02457A] indent-9 p-9"
        {...rest}
      />
  </>
  
  )
}

export default InputIcon
