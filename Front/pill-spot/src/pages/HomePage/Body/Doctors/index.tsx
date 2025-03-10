// import { FiSearch } from "react-icons/fi";
import OneDoctor from "./oneDoctor/OneDoctor";
import Marquee from "react-fast-marquee";

const DoctorsCons = () => {
  // const categories = [
  //   "Category 1",
  //   "Category 2",
  //   "Category 3",
  //   "Category 4",
  //   "Category 5",
  // ];
  return (
    <div className="container mt-5">
      <div className="flex justify-center items-center py-8 bg-gradient-to-r text-[#334c83] font-bold rounded-5xl my-5">
        <h1 className="text-3xl md:text-4xl font-bold tracking-wide">
          Connect Our Doctors
        </h1>
      </div>

      <div className="flex">
        {/* <div className="flex-1">
          <aside className="flex-[1] bg-gray-100 rounded-2xl p-5 hidden sm:block sticky top-5">
            <div className="hidden sm:flex justify-center">
              <div className="relative w-full max-w-3xl">
                <input
                  type="text"
                  placeholder="Search Products..."
                  className="w-full placeholder:text-black border-0 bg-gray-300 shadow-sm focus:border-gray-400 outline-none rounded-2xl indent-6 h-11 pr-12"
                />
                <FiSearch className="absolute right-4 top-1/2 transform -translate-y-1/2 text-gray-500" />
              </div>
            </div>

            <div className="mt-6">
              <h2 className="text-2xl font-bold mb-4">Categories</h2>
              <ul className="space-y-2">
                {categories.map((category, index) => (
                  <li
                    key={index}
                    className="relative text-lg font-medium cursor-pointer group"
                  >
                    {category}
                    <span className="absolute left-0 bottom-0 w-0 h-[2px] bg-black transition-all duration-300 ease-out group-hover:w-[40px]"></span>
                  </li>
                ))}
              </ul>
            </div>

            
          </aside>
        </div> */}
        <div className="flex-4">
          <Marquee className="rounded-2xl" speed={50} pauseOnClick >

          <div className="flex flex-wrap justify-center gap-6 mb-10 mx-3">
            <OneDoctor />
            <OneDoctor />
            <OneDoctor />
            <OneDoctor />
            <OneDoctor />
          </div>
          </Marquee>
        </div>
      </div>


      <div className="flex mb-10">
        <div className="flex-4">
          <Marquee className="rounded-2xl" speed={100} pauseOnClick direction="right">

          <div className="flex flex-wrap justify-center gap-6 mb-10 mx-3">
            <OneDoctor />
            <OneDoctor />
            <OneDoctor />
            <OneDoctor />
            <OneDoctor />
          </div>
          </Marquee>
        </div>
      </div>

      

      
    </div>
  );
};

export default DoctorsCons;
