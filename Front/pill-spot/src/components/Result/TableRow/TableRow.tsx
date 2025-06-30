import Rating from "../../../UI/Rating";
import Details from "../PharamcyDetails/Details";
import ImgIcon from "../../../UI/ImgIcon";
import BuyAmount from "../../../UI/BuyAmoutn";
import MapLocation from "../../MapModal";

interface Iprops {
  name: string;
  price: number;
  distance: string;
  rating: string;
  imgSrc: string;
  lng : number ; 
  lat : number ;
}

const TableRow = ({ name, price, distance, rating, imgSrc , lng,lat }: Iprops ) => {
  return (
    <tr className="hover:bg-gray-200 duration-300 transform text-[#02457a]">
      <td>
        <div className="flex items-center gap-3">
          <div className="avatar w-30">
            <ImgIcon src={`${import.meta.env.VITE_BASE_URL}${imgSrc}`} />
          </div>
          <div>
            <div className="font-bold">{name}</div>
            <div>
              <Rating value={Number(rating)} />
            </div>

            <span className="badge badge-ghost badge-sm">
              {distance} Away
            </span>
          </div>
        </div>
      </td>
      <td>{price} EGP</td>
      <td>
        <MapLocation
          modalName={name + distance}
          name={name}
          distance={distance}
          lng={lng}
          lat={lat}
        />
      </td>
      <td>
       <BuyAmount/>
      </td>
      <th>
        {/* // i id will be enouph and get the details from data base also do not forget to give it unique ID for each pharmacy */}
        <Details />
      </th>
    </tr>
  );
};

export default TableRow;
