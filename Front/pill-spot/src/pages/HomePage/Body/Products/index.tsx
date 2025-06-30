import { FiSearch } from "react-icons/fi";
import OneProduct from "./oneProduct";
import Marquee from "react-fast-marquee";
import OneCategory from "./oneCategory";
import img from "../Products/oneCategory/image.png";
import { useSelector } from "react-redux";
import { RootState } from "../../../../app/store";
import { useNavigate } from "react-router-dom";

const Products = () => {
  // const dispatch = useDispatch<AppDispatch>();
  const navigate = useNavigate() ;
  let products = useSelector(
    (state: RootState) => state.fetchHomeProductSlice.Products
  );
  const cate = useSelector(
    (state: RootState) => state.fetchHomeProductSlice.Categories
  );

  const loadingProducts = useSelector((state:RootState)=>state.fetchHomeProductSlice.LoadingProducts) ; 

  const handleGoToProductPage = ()=>{
      navigate('/productpage',{replace:true}) ;
  }

  console.log(products);
  products = products!.slice(0, 11);
  console.log(cate) ;

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
        {cate &&
          cate.map((category) => (
            <div className="flex gap-10 mx-5" key={category.categoryId}>
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
              {cate &&
                cate.map((category) => (
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

{

       loadingProducts ? 
       <span className="loading loading-ring w-50"></span>
       :
       <>       
        <div className="flex-[4] grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-4">
          {products &&
            (products.length > 0) &&
            products.map((p) => (
              <OneProduct
                key={p.productDto.productId}
                quantity={p.quantity}
                productDto={p.productDto}
                pharmacyDto={p.pharmacyDto}
                hover={false}
              />
            ))}

          <div onClick={handleGoToProductPage}>
            
            <OneProduct
                key={12}
                quantity={12}
                hover={true}
              />
              </div>
        </div>
       </>
}
      </div>
    </div>
  );
};

export default Products;
