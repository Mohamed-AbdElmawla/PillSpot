import { BarChart } from "@mui/x-charts/BarChart";
import { axisClasses } from "@mui/x-charts/ChartsAxis";
import { dataset, valueFormatter } from "./dataset";
import { toast } from "sonner";
import { IoMdCart } from "react-icons/io";
import DataCard from "./DataCard";
import { FaMoneyBillTrendUp } from "react-icons/fa6";
import { FaMoneyBillWave } from "react-icons/fa";
import { FaCoins } from "react-icons/fa6";
import MedcineCard from "./medcineCard";
import Chart from "./Chart";
import PiChart from "./PiChart";

const chartSetting = {
  yAxis: [
    {
      label: "Revenue (EGP)",
    },
  ],
  series: [
    {
      dataKey: "price",
      label: "Monthly Revenue",
      valueFormatter,
      color: "#BFDBFE",
    },
  ],
  height: 370,
  sx: {
    [`& .${axisClasses.directionY} .${axisClasses.label}`]: {
      transform: "translateX(-10px)",
    },
  },
};

export default function DataChart() {
  const handleBarClick = (
    _event: React.MouseEvent<SVGElement>,
    data: { dataIndex?: number }
  ) => {
    if (typeof data?.dataIndex === "number") {
      const monthNumber = data.dataIndex + 1;
      toast.success(`Month Number: ${monthNumber}`);
    }
  };

  return (
    <div style={{ width: "100%" }} className="px-10">
      <div>
        <BarChart
          dataset={dataset}
          xAxis={[{ scaleType: "band", dataKey: "month" }]}
          {...chartSetting}
          onItemClick={handleBarClick}
        />
      </div>

      <div>
        <div className="flex justify-around flex-wrap gap-y-2 ">
          <DataCard title="Average Daily Orders" data="20">
            <IoMdCart className="bg-[#FFF1CB] w-15 h-15 p-3 rounded-2xl hover:scale-110 duration-300" />
          </DataCard>
          <DataCard title="Total Revenue" data="20,000">
            <FaMoneyBillTrendUp className="bg-[#CBFFE8] w-15 h-15 p-3 rounded-2xl hover:scale-110 duration-300" />
          </DataCard>
          <DataCard title="Total Cost" data="20,000">
            <FaMoneyBillWave className="bg-[#FFD7D7] w-15 h-15 p-3 rounded-2xl hover:scale-110 duration-300" />
          </DataCard>
          <DataCard title="Net Profit" data="20">
            <FaCoins className="bg-[#ACD9FD] w-15 h-15 p-3 rounded-2xl hover:scale-110 duration-300" />
          </DataCard>
        </div>
      </div>

      <div>
        <div className="flex w-full flex-col md:flex-row mt-5 gap-5">
          <div className="bg-blue-50 flex flex-col md:flex-row p-4 rounded-2xl h-auto md:h-91 items-center justify-center gap-4">
            <Chart />
           

           <PiChart/>
          </div>

          <div className="bg-blue-200 flex-1 p-4 h-91 overflow-auto rounded-2xl flex flex-col gap-5 items-center">
            <span className="text-[#1C8DC9] font-bold text-2xl">
              Best seling
            </span>
            <MedcineCard />
            <MedcineCard />
            <MedcineCard />
            <MedcineCard />
            <MedcineCard />
            <MedcineCard />
          </div>
        </div>
      </div>
    </div>
  );
}
