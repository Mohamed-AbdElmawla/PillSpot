import { useState } from "react";
import MedicineDetails from "./DetailsCard";
import ResultTable from "./ResultTable";

import { Pagination } from "antd";
import { useLocation } from "react-router-dom";


const ResultPageDetails = () => {
  const [curPage,setPage] = useState(1);
  const location = useLocation();
  const data = location.state?.data || "";
  
  const handlePageChange = (page:number , pageSize:number)=>{
    setPage(page);
    console.log(pageSize) ;
    console.log(curPage) ;
  }

  return (
    <>
      <div className="flex flex-col gap-5 mt-10">
        <MedicineDetails />

        <div>
          <ResultTable curPage={curPage} data={data} />
          <div>
            {data}
          </div>
          <div className="m-10">
            <Pagination align="center" defaultCurrent={1} total={13} pageSize={5} onChange={handlePageChange} />
          </div>
        </div>
      </div>
    </>
  );
};

export default ResultPageDetails;
