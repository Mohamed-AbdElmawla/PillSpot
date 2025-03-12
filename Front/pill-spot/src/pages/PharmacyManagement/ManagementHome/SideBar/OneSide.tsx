import { ReactNode } from "react";
import { IoIosArrowForward } from "react-icons/io";

interface Iprops{
    name : string , 
    data : string , 
    color: string ,
    children : ReactNode,
}

const OneSide = ({name,data,children,color}:Iprops) => {
  return (
    <div>
      <div className="flex items-center gap-4 min-w-2xs w-full p-5 relative">
        <div className={`w-15 h-15 ${color} rounded-2xl flex items-center justify-center`}>
          {children}
        </div>
        <div className="flex flex-col gap-2 items-start flex-1">
          <span className="text-md font-bold text-blue-400">
            {name}
          </span>
          <span className="text-sm text-blue-900 font-bold">{data}</span>
        </div>
        <div className="absolute right-0">
          <IoIosArrowForward className="text-2xl ml-10" />
        </div>
      </div>
    </div>
  );
};

export default OneSide;
