import { useMemo, useState } from "react";
import { Pharmcs } from "../data";
import TableRow from "../TableRow/TableRow";
import { IoPricetagsOutline } from "react-icons/io5";
import { FaSortAlphaDown } from "react-icons/fa";
import { FaSortAlphaUpAlt } from "react-icons/fa";
import { LuMap } from "react-icons/lu";
import { toast } from "sonner";
import {v4 as uuid} from "uuid" ;





const ResultTable = () => {
  const [resPhar, setResPhar] = useState(Pharmcs);
  const [priceIsAscending, setpriceIsAscending] = useState(true);
  const [distanceIsAscending, setdistanceIsAscending] = useState(true);

  function sortDistance() {
    setResPhar((prev) =>
      [...prev].sort((a, b) =>
        distanceIsAscending
          ? Number(a.distance) - Number(b.distance)
          : Number(b.distance) - Number(a.distance)
      )
    );
    setdistanceIsAscending((prev) => !prev);
  }

  function sortPrice() {
    setResPhar((prev) =>
      [...prev].sort((a, b) =>
        priceIsAscending
          ? Number(a.price) - Number(b.price)
          : Number(b.price) - Number(a.price)
      )
    );
    setpriceIsAscending((prev) => !prev);
    toast('My first toast')
  }

  //________________Render___________________//

  // it is a good use of useMemo,it will generate new UUID only when there is new resPhars
  const UniuqePharmaciesKey = useMemo(() => 
    resPhar.map((p) => ({ ...p, id: uuid() })), 
    [resPhar] 
  );

  const Pharmacies = UniuqePharmaciesKey.map((p) => (
    <TableRow
      key={p.id} 
      name={p.name}
      price={p.price}
      distance={p.distance}
      rating={p.rating}
      imgSrc={p.imgSrc}
    />
  ));

  return (
    <div className="overflow-x-auto ">
         Available in these pharmacies
      <div className="flex justify-end gap-2">
        <button className="btn " onClick={sortPrice}>
        <IoPricetagsOutline />
        {priceIsAscending?<FaSortAlphaDown />:<FaSortAlphaUpAlt />}
        </button>
        <button className="btn" onClick={sortDistance}>
        <LuMap />
        {distanceIsAscending?<FaSortAlphaDown />:<FaSortAlphaUpAlt />}
        </button>
      </div>
      <div>
        <table className="table">
          <thead className="text-[#02457a]">
            <tr>
              <th>Name</th>
              <th>Price</th>
              <th>Location</th>
              <th>Amount</th>
              <th></th>
            </tr>
          </thead>
          <tbody>{Pharmacies}</tbody>
        </table>
      </div>
    </div>
  );
};

export default ResultTable;
