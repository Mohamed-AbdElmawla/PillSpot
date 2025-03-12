import { BiEdit } from "react-icons/bi";
import { MdOutlineRefresh } from "react-icons/md";
import { IoCartOutline } from "react-icons/io5";
import { FaRegCheckCircle } from "react-icons/fa";
import { useMemo } from "react";

interface Iprops {
  id?: string;
  customerName: string;
  orderPrice: string;
  date: string;
  status: string;
}
const OrderRow = (props: Iprops) => {
  const ButtonsMap = useMemo(() => {
    return new Map<string, JSX.Element>([
      [
        "complete",
        <>
          <td className="">
            <div className="flex items-center gap-2 bg-orange-200 h-10 rounded-2xl p-3 hover:scale-105 duration-300 cursor-pointer">
              <span className="text-[14px]">To Progress </span>
              <button>
                <IoCartOutline className="text-xl" />
              </button>
            </div>
          </td>
          <td className="">
            <div className="flex items-center gap-2 bg-yellow-200 h-10 rounded-2xl p-3 hover:scale-105 duration-300 cursor-pointer">
              <p className="text-[14px]">To Pending </p>
              <button>
                <MdOutlineRefresh className="text-xl" />
              </button>
            </div>
          </td>
        </>,
      ],
      [
        "inprogress",
        <>
          <td className="">
            <div className="flex items-center gap-2 bg-yellow-200 h-10 rounded-2xl p-3 hover:scale-105 duration-300 cursor-pointer">
              <p className="text-[14px]">To Pending </p>
              <button>
                <MdOutlineRefresh className="text-xl" />
              </button>
            </div>
          </td>
          <td className="">
            <div className="flex items-center gap-2 bg-green-200 h-10 rounded-2xl p-3 hover:scale-105 duration-300 cursor-pointer">
              <p className="text-[14px]">To Complete </p>
              <button>
                <FaRegCheckCircle className="text-xl" />
              </button>
            </div>
          </td>
        </>,
      ],
      [
        "pending",
        <>
          <td className="">
            <div className="flex items-center gap-2 bg-orange-200 h-10 rounded-2xl p-3 hover:scale-105 duration-300 cursor-pointer">
              <p className="text-[14px]">To Progress </p>
              <button>
                <IoCartOutline className="text-xl" />
              </button>
            </div>
          </td>
          <td className="">
            <div className="flex items-center gap-2 bg-green-200 h-10 rounded-2xl p-3 hover:scale-105 duration-300 cursor-pointer">
              <p className="text-[14px]">To Complete </p>
              <button>
                <FaRegCheckCircle className="text-xl" />
              </button>
            </div>
          </td>
        </>,
      ],
    ]);
  }, []);

  return (
    <tr className="font-bold hover:scale-105 duration-300 hover:bg-blue-50">
      <th>{props.id}</th>
      <td title={props.customerName}>
        <div className="max-w-35 overflow-x-auto">
        {props.customerName}
        </div>
      </td>

      <td>{props.orderPrice}</td>
      <td>{props.date}</td>
      {ButtonsMap.get(props.status) ?? <td>Invalid Status</td>}
      <td className="text-gray-400 font-bold">
        <BiEdit />
      </td>
    </tr>
  );
};

export default OrderRow;
