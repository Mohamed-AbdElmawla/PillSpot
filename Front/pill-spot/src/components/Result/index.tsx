import { useEffect, useState } from "react";
import MedicineDetails from "./DetailsCard";
import ResultTable from "./ResultTable";
import axios from "axios";
import { Pagination } from "antd";
import { useLocation } from "react-router-dom";

const ResultPageDetails = () => {
  const [curPage,setPage] = useState(1);
  const location = useLocation();
  const data = location.state?.data || "";




  useEffect(() =>{

    async function fetchData() {
      console.log(curPage,"  "  , data)
      try{
        const response = await axios.get(`https://localhost:7298/api/pharmacyproducts?SearchTerm=${data}f&PageNumber=${curPage}&PageSize=5`) ;
        console.log(response.data) ;
      } catch(e){
        console.log(e) ;
      }
    }

    fetchData();
  },[curPage]);

  return (
    <>
      <div className="flex flex-col gap-5 mt-10">
        <MedicineDetails />

        <div>
          <ResultTable />
          {/* <div>
            {data}
          </div> */}
          <div className="m-10">
            <Pagination align="center" defaultCurrent={1} total={50} onChange={(page)=>{setPage(page)}} />
          </div>
        </div>
      </div>
    </>
  );
};

export default ResultPageDetails;
