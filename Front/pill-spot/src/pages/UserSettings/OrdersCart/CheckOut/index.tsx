

const CheckOutComp = () => {
  return (
    <div className="flex-1 border-1 text-[#0a2c6b] min-h-[24vh] p-5 sm:p-6 md:p-8 m-5 rounded-2xl flex flex-col justify-start items-center w-full max-w-lg mx-auto">
      <div className="font-logo text-xl sm:text-2xl text-[#0a2c6b]">Order Summary</div>

      <div className="w-full px-5 mt-4 sm:mt-5">
        <hr className="border-gray-300 text-[#1C8DC9]" />
      </div>

      <div className="w-full flex flex-col sm:flex-row justify-between px-4 sm:px-5 py-6 sm:py-9 text-lg sm:text-2xl rounded-lg text-[#0a2c6b]">
        <div className="flex gap-2">
          <span>Items</span>
          <span>5</span>
        </div>
        <div>500 EGP</div>
      </div>

      <div className="mt-4 sm:mt-6 w-full flex justify-center">
        <button className="w-full sm:w-50 bg-[#1C8DC9] text-white rounded-2xl py-3 text-lg cursor-pointer">
          Check Out
        </button>
      </div>
    </div>
  );
};

export default CheckOutComp;
