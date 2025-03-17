import Rating from "../../../../../UI/Rating";
import { AiFillSchedule } from "react-icons/ai";


const OneDoctor = () => {
  return (
    <div className="container flex flex-col gap-6 max-w-md bg-white shadow-xl rounded-2xl p-6 hover:scale-105 duration-200">
      <div className="flex gap-5">
        <div>
          <div className="avatar">
            <div className="w-50 rounded-2xl">
              <img src="https://img.daisyui.com/images/profile/demo/2@94.webp" />
            </div>
          </div>
        </div>

        <div className="flex flex-col items-start m-1">
          <div>
            <span className="text-2xl font-bold">Doctor El Doctor</span>
          </div>

          <div className="flex m-1">
            <Rating w="2" value={8} />
            <span className="font-bold text-gray-400">(200)</span>
          </div>

          <div className="flex items-center gap-1 flex-wrap m-1">
            <span className="bg-blue-100 text-blue-800 text-xs font-medium px-2.5 py-0.5 rounded">
              Specialization
            </span>
            <span className="bg-blue-100 text-blue-800 text-xs font-medium px-2.5 py-0.5 rounded">
              Specia
            </span>
            <span className="bg-blue-100 text-blue-800 text-xs font-medium px-2.5 py-0.5 rounded">
              lization
            </span>
          </div>
        </div>
      </div>

      <div className="mx-auto mt-2">
      <button
            className="flex items-center bg-[#334c83] text-white px-5 py-2.5 text-sm font-medium rounded-lg hover:bg-blue-800 focus:ring-4 focus:ring-blue-300"
           
          >
            <AiFillSchedule className="text-2xl mr-2" />
            Schedule Consultation
          </button>
      </div>
    </div>
  );
};

export default OneDoctor;
