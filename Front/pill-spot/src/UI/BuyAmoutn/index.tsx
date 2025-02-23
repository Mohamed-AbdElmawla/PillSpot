import { CiSquarePlus , CiSquareMinus  } from "react-icons/ci";


import { useState } from "react";

const BuyAmount = () => {
  const [count, setCount] = useState(0);

    function handleInc(){
        setCount(count+1) ;
    }

    function handleDec(){
        if(count>0){
            setCount(count-1) ;
        }
    }

  return (
    <div className="flex items-center gap-3">
      <span onClick={handleInc}><CiSquarePlus className="w-6 h-6 cursor-pointer" /></span>
      {count}
      <span onClick={handleDec}><CiSquareMinus className="w-6 h-6 cursor-pointer" /></span>
    </div>
  );
};

export default BuyAmount;
