import { useState } from "react";
import { CiSquarePlus } from "react-icons/ci";
import { CiSquareMinus } from "react-icons/ci";
import { MdOutlineDelete } from "react-icons/md";


const OneOrderRow = () => {
  const [qtn, setQtn] = useState(0);

  function decCount() {
    if (qtn === 0) return;
    setQtn(qtn - 1);
  }
  function incCount() {
    setQtn(qtn + 1);
  }

  return (
    <tr className="text-xl text-[#1C8DC9] hover:scale-102 duration-500 hover:bg-amber-50">
      <th></th>
      <td>
        <div className="flex items-center gap-3">
          <div className="avatar">
            <div className="mask mask-squircle h-12 w-12">
              <img
                src="https://img.daisyui.com/images/profile/demo/2@94.webp"
                alt="Avatar Tailwind CSS Component"
              />
            </div>
          </div>
          <div>
            <div className="font-bold">Medecine </div>
            <div className="text-sm opacity-50">Pharmacy</div>
          </div>
        </div>
      </td>
      <td>
        <span className="font-bold">50$</span>
      </td>
      <td className="flex items-center">
        <button onClick={decCount}>
          <CiSquareMinus className="text-3xl mx-2" />
        </button>
        <span className="text-xl">{qtn}</span>
        <button onClick={incCount}>
          <CiSquarePlus className="text-3xl mx-2" />
        </button>
      </td>
      <th>
        <span className="text-xl">150</span>
      </th>
      <th>
        <MdOutlineDelete  className="text-3xl hover:scale-105 duration-150 cursor-pointer"/>
      </th>
    </tr>
  );
};

export default OneOrderRow;
