import { useState, useEffect } from "react";



// here ther are two problems 1- the name of each component , 2- the key of each half star

interface Iprops {
    value : number ; 
}

function Rating({ value }:Iprops) {
  const [rating, setRating] = useState(value); 

  useEffect(() => {
    setRating(value); 
  }, [value]);


  function halfNumber(index: number):string{
    if(index%2==0){
        return `mask mask-star-2 mask-half-1 bg-orange-400 w-2`
    } else {
        return `mask mask-star-2 mask-half-2 bg-orange-400 w-2`
    }
  }


  return (
    <div className="rating rating-half pointer-events-none">
    {[...Array(10)].map((_, index) => {
      const starValue = index + 1;
      return (
        <input
          key={value+index}
          type="radio"
          name={String(value)}
          className={halfNumber(index)}
          checked={rating === starValue}
          readOnly
        />
      );
    })}
  </div>
  
  );
}

export default Rating;


