import { IoMdArrowDropdown } from "react-icons/io";
import { logOut } from "../../../features/auth/authLogin";
import { useDispatch } from "react-redux";
import { toast } from "sonner";

const InfoOptions = () => {
  const dispatch = useDispatch();

  function handleLogOut(){
      dispatch(logOut());
      toast.success("good bye <3") ;
  }

  return (
    <div className="dropdown dropdown-hover w-full">
   
    <div
      tabIndex={0} 
      className="flex items-center gap-2 font-bold cursor-pointer hover:underline underline-offset-4 p-2 rounded-lg text-white"
    >
      Hello Mohamed Elaraby
      <IoMdArrowDropdown className="text-2xl" />
    </div>
  

    <ul
      tabIndex={0} 
      className="dropdown-content menu w-full mt-2 bg-white shadow-lg rounded-lg border border-gray-200 z-10 p-2"
    >
      <li className="px-4 py-2 text-gray-700 hover:bg-gray-100">email@email.com</li>
      <li>
        <a href="#" className="block px-4 py-2 text-gray-700 hover:bg-gray-100">
          Profile Settings
        </a>
      </li>
      <hr className="border-t border-gray-200 my-1" />
      <li>
        <button onClick={handleLogOut}  className="block px-4 py-2 text-red-600 hover:bg-red-100">
        Log Out

        </button>
        {/* <Link to={"/landing"} className="block px-4 py-2 text-red-600 hover:bg-red-100">
          Log Out
        </Link> */}
      </li>
    </ul>
  </div>
  

  );
};

export default InfoOptions;
