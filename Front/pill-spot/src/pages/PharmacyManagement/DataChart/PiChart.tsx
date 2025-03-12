
import { PieChart } from '@mui/x-charts/PieChart';
import { mobileOS } from './webUsageStats';

export default function PiChart() {
  return (
    <PieChart className="w-full md:w-1/2 min-w-[300px]"
  series={[
    {
      data: [ ...mobileOS ],
      innerRadius: 30,
      outerRadius: 100,
      paddingAngle: 5,
      cornerRadius: 5,
      startAngle: -68,
      endAngle: 290,
      cx: 100,
      cy: 150,
    }
  ]}
/>
  );
}
