import { ReactNode } from "react";


interface Iprops {
  title: string;
  data: string;
  children: ReactNode;
}

const DataCard = ({ title, data, children }: Iprops) => {
  return (
    <div>
     
        <div className="bg-blue-200 w-full min-w-3xs max-w-3xs h-25 rounded-2xl p-5 flex items-center justify-start gap-2 hover:scale-105 duration-300">
          {children}
          <div className="flex flex-col gap-2">
            <span className="text-[#1C8DC9] font-bold">{title}</span>
            <span className="text-[#02457A] font-bold">{data}</span>
          </div>
        </div>
      
    </div>
  );
};

export default DataCard;
