import { useState, useEffect, useMemo } from "react";
import {v4 as uuid} from "uuid" ;


// here ther are two problems 1- the name of each component , 2- the key of each half star

interface Iprops {
    value : number ; 
    w? : string ;
}
function Rating({ value , w="2" }: Iprops) {
  const [rating, setRating] = useState(value); 
  const uniqueId = useMemo(() => uuid(), []);

  useEffect(() => {
    setRating(value); 
  }, [value]);

  function halfNumber(index: number): string {
    return index % 2 === 0
      ? `mask mask-star-2 mask-half-1 bg-orange-400 w-${w} h-10`
      : `mask mask-star-2 mask-half-2 bg-orange-400 w-${w} h-10`;
  }

  const starIds = useMemo(() => Array.from({ length: 10 }, () => uuid()), []);

  return (
    <div className="rating rating-half pointer-events-none">
      {starIds.map((id, index) => {
        const starValue = index + 1;
        return (
          <input
            key={id}
            type="radio"
            name={`star-rating-${uniqueId}`} 
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


