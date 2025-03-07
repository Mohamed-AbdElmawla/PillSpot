import { BarChart } from "@mui/x-charts/BarChart";
import { axisClasses } from "@mui/x-charts/ChartsAxis";
import { toast } from "sonner";

function valueFormatter(value: number | null) {
  return `${value} EGP`;
}

// at future the data set will be prop and come from the database

const Chart = () => {


  const chartSetting = {
    yAxis: [
      {
        label: "Revenue (EGP)",
      },
    ],
    series: [
      {
        dataKey: "price",
        label: "weekly Revenue",
        valueFormatter,
        color: "#BFDBFE",
      },
    ],
    height: 370,
    width: 400, // will come from props
    sx: {
      [`& .${axisClasses.directionY} .${axisClasses.label}`]: {
        transform: "translateX(-10px)",
      },
    },
  };

  const dataset = [
    { price: 34, week: "week1" },
    { price: 100, week: "week2" },
    { price: 50, week: "week3" },
    { price: 10, week: "week4" },
  ];

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
    <div style={{ width: "100%" }} className="w-full md:w-1/2">
      <div>
        <BarChart
          dataset={dataset}
          xAxis={[{ scaleType: "band", dataKey: "week" }]}
          {...chartSetting}
          onItemClick={handleBarClick}
        />
      </div>
    </div>
  );
};

export default Chart;
