import { ProductItem } from "../types";
import TableRow from "../TableRow/TableRow";
import { useEffect, useState } from "react";
import useGeolocation from "../../../hooks/GetLocation";
import axios from "axios";


interface Iprops{
  data : string ; 
  curPage:number ;
}

const ResultTable = ({data,curPage}:Iprops) => {
 
  const [curData, setCurData] = useState<ProductItem[]>([]);
  const curLocation = useGeolocation();
  console.log(curLocation);

  useEffect(() => {
    if (!curLocation.lat || !curLocation.lng) return;
    setCurData([]); 
    async function fetchData() {
      try {
        const response = await axios.get(
          `${import.meta.env.VITE_BASE_URL}api/pharmacyproducts?SearchTerm=${data}&UserLatitude=${curLocation.lat}&UserLongitude=${curLocation.lng}&PageNumber=${curPage}&PageSize=5`
        );
        setCurData(response.data);
        console.log(response.data);
      } catch (e) {
        console.log(e);
      }
    }

    fetchData();
  }, [curLocation,curPage]);

  console.log(curData);

  return (
    <div className="overflow-x-auto">
      Available in these pharmacies
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
          <tbody>
            {curData.map((p) => (
              <TableRow
                key={p.pharmacyDto.pharmacyId}
                name={p.pharmacyDto.name}
                price={p.productDto.price}
                distance={p.formattedDistance}
                rating={"7"}
                imgSrc={p.pharmacyDto.logoURL}
                lng={p.pharmacyDto.locationDto.longitude}
                lat={p.pharmacyDto.locationDto.latitude}
              />
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default ResultTable;
