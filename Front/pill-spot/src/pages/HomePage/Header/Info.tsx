import { IoMdArrowDropdown } from "react-icons/io";

const InfoOptions = () => {
  return (
    <div className="dropdown dropdown-hover w-full">
    {/* Dropdown Button */}
    <div
      tabIndex={0} 
      className="flex items-center gap-2 font-bold cursor-pointer hover:underline underline-offset-4 p-2 rounded-lg"
    >
      Hello Mohamed Elaraby
      <IoMdArrowDropdown className="text-2xl" />
    </div>
  
    {/* Dropdown Content (Fix applied) */}
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
        <a href="#" className="block px-4 py-2 text-red-600 hover:bg-red-100">
          Log Out
        </a>
      </li>
    </ul>
  </div>
  

  );
};

export default InfoOptions;
