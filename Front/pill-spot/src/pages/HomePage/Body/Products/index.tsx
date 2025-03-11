import { FiSearch } from "react-icons/fi";
import OneProduct from "./oneProduct";
import Marquee from "react-fast-marquee";
import OneCategory from "./oneCategory";
import img from "../Products/oneCategory/image.png";
import { useEffect, useState } from "react";
import axios from "axios";

interface Icategory {
  name: string;
  categoryId: string;
}

interface Iproduct {
  name: string;
  category: string;
  rating: number;
  rates: number | string;
  pharmacyName: string;
  additionalInfo: string;
  price: string;
}

const Products = () => {
  const [cate, setCat] = useState<Icategory[]>([]);
  const [product, setProduct] = useState<Iproduct[]>([]);

  useEffect(() => {
    const fetchCategory = async () => {
      try {
        const response = await axios.get(
          "https://localhost:7298/api/categories"
        );
        console.log(response.data);
        setCat(response.data);
      } catch (error) {
        console.error("Error fetching categories:", error);
      }
    };

    const fetchProducts = async () => {
      try {
        const response = await axios.get(
          "https://localhost:7298/api/pharmacyproducts?PageNumber=1&PageSize=11"
        );
        console.log(response.data);
        setProduct(response.data);
      } catch (error) {
        console.error("Error fetching categories:", error);
      }
    };
    fetchCategory();
    fetchProducts();
  }, []);
  console.log(cate);

  return (
    <div>
      <Marquee
        speed={100}
        direction="right"
        pauseOnClick
        gradient
        gradientColor="#334c8380"
        gradientWidth={100}
        className="rounded-2xl"
      >
        {cate.map((category) => (
          <div className="flex gap-10 mx-5">
            <OneCategory name={category.name} id={category.categoryId} />
          </div>
        ))}
      </Marquee>
      <div className="container w-full flex gap-3 m-auto my-10">
        <aside className="flex-[1] bg-gradient-to-r from-[#334c83] to-[#76a0df] bg-[length:200%_200%] bg-left transition-all duration-500 hover:bg-right rounded-2xl h-1/2 p-5 hidden sm:block sticky top-5">
          <div className="hidden sm:flex justify-center">
            <div className="relative w-full max-w-3xl">
              <input
                type="text"
                placeholder="Search Products..."
                className="w-full placeholder:text-black border-0 bg-blue-50 shadow-sm focus:border-gray-400 outline-none rounded-2xl indent-6 h-11 pr-12"
              />
              <FiSearch className="absolute right-4 top-1/2 transform -translate-y-1/2 text-gray-500" />
            </div>
          </div>

          <div className="mt-6">
            <h2 className="text-2xl font-bold mb-4 text-white">Categories</h2>
            <ul className="space-y-2">
              {cate.map((category) => (
                <div
                  key={category.categoryId}
                  className="flex items-center justify-start gap-5 bg-blue-50 p-1 rounded-2xl"
                >
                  <img src={img} className="w-20 rounded-xl" />
                  <li className="relative text-lg font-medium cursor-pointer group text-[#334c83]">
                    {category.name}{" "}
                    <span className="absolute left-0 bottom-0 w-0 h-[2px] bg-black transition-all duration-300 ease-out group-hover:w-[40px]"></span>
                  </li>
                </div>
              ))}
            </ul>
          </div>
        </aside>

        <div className="flex-[4] grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-4">
          <OneProduct />
          <OneProduct />
          <OneProduct />
          <OneProduct />
          <OneProduct />
          <OneProduct />
          <OneProduct />
          <OneProduct />
          <OneProduct />
          <OneProduct />
          <OneProduct />
          <div>
            <OneProduct hover={true} />
          </div>
        </div>
      </div>
    </div>
  );
};

export default Products;
