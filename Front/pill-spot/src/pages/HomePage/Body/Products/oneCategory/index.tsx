import img from "./image.png";

interface Iprops {
   name : string ;
   id : string ;
}


const OneCategory = ({name}:Iprops) => {
  return (
    <div className="container bg-white rounded-3xl p-4 sm:p-6 lg:p-1 mx-auto max-w-sm sm:max-w-md lg:max-w-lg hover:scale-102 duration-300">
      <div className="flex flex-col items-center justify-center">
        <div className="rounded-2xl overflow-hidden">
          <img src={img} className="w-full sm:w-80 rounded-t-3xl" alt="Preview" />
        </div>
        <div className="capitalize text-2xl sm:text-3xl font-bold my-2 text-center">
          {name}
        </div>
        <div className="w-full flex justify-center hover:scale-105 duration-200">
          <button className="bg-[#334c83] text-white p-3 w-full sm:w-70 rounded-xl my-2 mb-5 font-bold tracking-widest cursor-pointer">
            Browse Products
          </button>
        </div>
      </div>
    </div>
  );
};

export default OneCategory;
