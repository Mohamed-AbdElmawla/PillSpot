import { Dialog, DialogPanel } from "@headlessui/react";
import Search, { SearchProps } from "antd/es/input/Search";
import { ChangeEvent, ReactNode, useEffect, useState } from "react";
import OneProduct from "./OneProduct";
import axios from "axios";
import { toast } from "sonner";
import { MdErrorOutline } from "react-icons/md";
import { Pagination } from "antd";

interface IInputsData {
  name: string;
  type: string;
  title: string;
  options?: string[];
}

interface IProps<T extends IInputsData[]> {
  buttonText: string;
  buttonStyle: string;
  children: ReactNode;
  handleChange: (
    e: ChangeEvent<HTMLInputElement> | ChangeEvent<HTMLSelectElement>
  ) => void;
  inputData: T;
}

interface Imedcine {
  manufacturer: string;
  dosage: string;
  productId: string;
  name: string;
  description: string;
  imageURL: string;
  createdDate: string;
  subCategoryDto: {
    subCategoryId: string;
    name: string;
  };
}

export default function AddProductModal<T extends IInputsData[]>({
  buttonText,
  buttonStyle,
  children,
}: IProps<T>) {
  const [isOpen, setIsOpen] = useState(false);
  const [isActive, setActive] = useState<"medicines" | "cosmetics">(
    "medicines"
  );

  const [Medecines, setMedecines] = useState<Imedcine[]>([]);
  const [Cosmatics, setCosmatics] = useState<Imedcine[]>([]);
  const [DataToSHow, setDataToShow] = useState<Imedcine[]>([]);
  const [pagenation, setPagenation] = useState({page:1,pageSize:10}) ;
  const [searchItem, setSearchItem] = useState('');



  useEffect(() => {

    async function fetchData(){
      if (!searchItem.trim()) {
        setMedecines([]);
        setCosmatics([]);
        setDataToShow([]);
        return;
      }
      try {
        const [medResponse, cosResponse] = await Promise.all([
          axios.get(`${import.meta.env.VITE_BASE_URL}api/medicines?SearchTerm=${searchItem}&PageNumber=${pagenation.page}&PageSize=${pagenation.pageSize}`),
          axios.get(`${import.meta.env.VITE_BASE_URL}api/cosmetics?SearchTerm=${searchItem}&PageNumber=${pagenation.page}&PageSize=${pagenation.pageSize}`),
        ]);
    
        setMedecines(medResponse.data || []);
        setCosmatics(cosResponse.data || []);
        setDataToShow(medResponse.data || []);
        
      } catch{
        toast.error("Something went wrong");
      }
    }

    fetchData()
    
  } , [pagenation,searchItem] )
  
  console.log(Medecines)
  console.log(Cosmatics)
  console.log(pagenation)



  function open() {
    setIsOpen(true);
  }
  function close() {
    setIsOpen(false);
  }




  const onSearch: SearchProps["onSearch"] =  (value) => {
    setSearchItem(value);
  };
  
// console.log(Medecines[0].subCategoryDto.name);

  const handleActive = (type: "medicines" | "cosmetics") => {
    setActive(type);
    setDataToShow(type === "medicines" ? Medecines : Cosmatics);
  };

  function handlePageChange(page : number ,pageSize : number){
    // console.log(page, " " , pageSize)
    setPagenation({page,pageSize}) ;
  }
  console.log(pagenation);

  return (
    <>
      <button className={`${buttonStyle} flex items-center`} onClick={open}>
        {children}
        {buttonText}
      </button>

      <Dialog
        open={isOpen}
        as="div"
        className="relative z-10 focus:outline-none"
        onClose={close}
      >
        {isOpen && (
          <div className="fixed inset-0 bg-opacity-50 backdrop-brightness-70 backdrop-blur-xs"></div>
        )}

        <div className="fixed inset-0 z-10 w-full mx-auto overflow-y-auto">
          <div className="flex min-h-full items-center justify-center p-4">
            <DialogPanel className="w-full max-w-7xl rounded-[48px] p-6 bg-gray-50 duration-300 ease-out flex flex-col md:flex-row">
              <div className="md:w-1/4 p-4 border-r border-gray-200">
                <h2 className="text-lg font-semibold mb-4">Categories</h2>
                <button
                  onClick={() => handleActive("medicines")}
                  className={`block w-full text-left p-2 rounded-lg cursor-pointer hover:scale-105 duration-150 ${
                    isActive === "medicines"
                      ? "bg-blue-600 text-white"
                      : "bg-transparent text-blue-900"
                  }`}
                >
                  Medicines
                </button>
                <button
                  onClick={() => handleActive("cosmetics")}
                  className={`block w-full text-left p-2 rounded-lg cursor-pointer hover:scale-105 duration-150  ${
                    isActive === "cosmetics"
                      ? "bg-blue-600 text-white"
                      : "bg-transparent text-blue-900"
                  }`}
                >
                  Cosmetics
                </button>
              </div>

              <div className="md:w-3/4 p-4 overflow-y-auto max-h-[80vh]">
                <Search
                  placeholder="Search for a product"
                  onSearch={onSearch}
                  enterButton
                  allowClear
                  maxLength={50}
                  size="large"
                  className="mb-4"
                />

                <div className="my-5 text-gray-300 w-sm mx-auto">
                  <hr />
                </div>

                <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-2 gap-4 ">
                  {DataToSHow.length ? (
                    DataToSHow.map((medicine) => (
                      <>
                        <OneProduct
                          key={medicine.productId}
                          medicine={medicine}
                        />
                      </>
                    ))
                  ) : (
                    <div className="flex justify-center items-center flex-col gap-20 text-gray-400 w-4xl my-20">
                      <h1 className="text-4xl font-bold">
                        No Items Found! See Other Categories!
                      </h1>
                      <MdErrorOutline className="text-9xl" />
                    </div>
                  )}
                </div>
                  <Pagination align="center" defaultCurrent={1} total={500} onChange={handlePageChange} />
              </div>
            </DialogPanel>
          </div>
        </div>
      </Dialog>
    </>
  );
}
