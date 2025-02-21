

import { Pharmcs } from "../data";
import TableRow from "../TableRow/TableRow";

const ResultTable = () => {



    const Pharmacies = Pharmcs.map((p)=>(
        <TableRow name={p.name} price={p.price} distance={p.distance} rating={p.rating} imgSrc={p.imgSrc} />
      )) ; 
      
  return (
    <div className="overflow-x-auto">
      <table className="table">
        {/* head */}
        <thead className="text-[#02457a]" >
          <tr>
            <th>Name</th>
            <th>Price</th>
            <th>Location</th>
            <th>Amount</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {Pharmacies}
        </tbody>
      </table>
    </div>
  );
};

export default ResultTable;
