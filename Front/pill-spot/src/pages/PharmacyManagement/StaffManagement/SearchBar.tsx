import { ChangeEvent, Dispatch, SetStateAction, useState } from "react";
import { BiSearchAlt } from "react-icons/bi";
import { IoMdAdd } from "react-icons/io";
import FormModal from "../EditAddModal";
import { addEmployee } from "../EditAddModal/data";
import axios from "axios";
import { useSelector } from "react-redux";
import { RootState } from "../../../app/store";
import { toast } from "sonner";

interface Iprops{
    setSearchStaff : Dispatch<SetStateAction<string>> ;
}
const SearchBar = ({setSearchStaff}:Iprops) => {

  const [invitedEmail,setEmail] = useState('') ;
  const curPharId = useSelector((state:RootState)=>state.currentPharmacy.pharmacy?.pharmacyId) ;
  console.log(curPharId)


  function handleChange(e: ChangeEvent<HTMLInputElement> | ChangeEvent<HTMLSelectElement>){
    const {value} = e.target ;
    setEmail(value);
  } 

  async function handleSubmitFormData() {
    const data = {
      email: invitedEmail,
      pharmacyId: curPharId,
    };
  
    try {
      const response = await axios.post(
        'https://localhost:7298/api/pharmacy-employees/SendRequest',
        data,
        {
          withCredentials: true,
        }
      );
      console.log(response.data)
      toast.success("Request sent Successfully");

    } catch (error) {
      toast.error("User Not Found | Request already sent");
      if (axios.isAxiosError(error)) {
        console.error('Error sending request:', error.response || error.message);
      } else {
        console.error('Unexpected error:', error);
      }
    }
  }

  console.log(invitedEmail)



  return (
    <div className="flex justify-between">
        <div className="flex items-center gap-2">
          <BiSearchAlt className="text-2xl text-[#666666D9] " />
          <input
            type="text"
            className="outline-none border-gray-200 rounded-2xl h-7 indent-3"
            placeholder="Search..."
            onChange={(e)=>{setSearchStaff(e.target.value)}}
          />
        </div>
        <div className="flex items-center bg-[#ACD9FD] rounded-2xl p-[5px] px-3 gap-2 cursor-pointer hover:scale-102 duration-200 text-[#026BBE]">

          <FormModal 
          buttonText="Add Employee" 
          buttonStyle="" 
          inputData={addEmployee} 
          handleChange={handleChange}
          closeButonTitle="Invite"
          handleSubmitFormData={handleSubmitFormData}
          >
          

          <IoMdAdd />
          </FormModal>

          {/* <button className="cursor-pointer">Add Employee </button> */}
        </div>
      </div>
  )
}

export default SearchBar
