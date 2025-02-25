import { FiSearch } from "react-icons/fi";
import OneProduct from "./oneProduct";

const Products = () => {
  const categories = [
    "Category 1",
    "Category 2",
    "Category 3",
    "Category 4",
    "Category 5",
  ];
  const products = [
    {
      name: "Product 1",
      category: "Category A",
      price: "$20",
      img: "https://img.daisyui.com/images/stock/photo-1559703248-dcaaec9fab78.webp",
    },
    {
      name: "Product 2",
      category: "Category B",
      price: "$30",
      img: "https://img.daisyui.com/images/stock/photo-1559703248-dcaaec9fab78.webp",
    },
    {
      name: "Product 2",
      category: "Category B",
      price: "$30",
      img: "https://img.daisyui.com/images/stock/photo-1559703248-dcaaec9fab78.webp",
    },
    {
      name: "Product 2",
      category: "Category B",
      price: "$30",
      img: "https://img.daisyui.com/images/stock/photo-1559703248-dcaaec9fab78.webp",
    },
  ];

  return (
    <div className="container w-full flex gap-3 m-auto my-10">
      <aside className="flex-[1] bg-gray-100 rounded-2xl h-screen p-5 hidden sm:block">
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

        <div className="mt-20 space-y-5">
          {products.map((product, index) => (
            <div
              key={index}
              className="bg-white rounded-2xl shadow-md p-4 flex items-center gap-4"
            >
              <img
                className="size-20 rounded-lg"
                src={product.img}
                alt={product.name}
              />
              <div>
                <div className="font-semibold">{product.name}</div>
                <div className="text-xs uppercase opacity-60">
                  {product.category} - {product.price}
                </div>
              </div>
            </div>
          ))}
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
      </div>
    </div>
  );
};

export default Products;
