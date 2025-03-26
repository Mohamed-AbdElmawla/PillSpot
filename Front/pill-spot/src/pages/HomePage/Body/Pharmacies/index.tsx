import { useSelector } from "react-redux";
import img1 from "../../../../assets/ph1.png";
import img2 from "../../../../assets/ph2.png";
import OneProduct from "../Products/oneProduct";
// import AUTOSLIDER from "../../../../components/animaged";
import "./carouselStyles.css";
import { Carousel } from "antd";
import Marquee from "react-fast-marquee";
import { RootState } from "../../../../app/store";

const contentStyle: React.CSSProperties = {
  height: "460px",
  color: "#eee",
  lineHeight: "160px",
  textAlign: "center",
  background: "#eee",
};

export default function PharmacyWithUs() {

  const products = useSelector(
    (state: RootState) => state.fetchHomeProductSlice.Products
  );
  const cate = useSelector(
    (state: RootState) => state.fetchHomeProductSlice.Categories
  );

  const photoMap = new Map();
  photoMap.set("slide1", img1);
  photoMap.set("slide2", img2);
  photoMap.set("slide3", img1);
  photoMap.set("slide4", img2);

  const slides = [
    {
      id: "slide1",
      src: "https://img.daisyui.com/images/stock/photo-1414694762283-acccc27bca85.webp",
      prev: 4,
      next: 2,
    },
    {
      id: "slide2",
      src: "https://img.daisyui.com/images/stock/photo-1609621838510-5ad474b7d25d.webp",
      prev: 1,
      next: 3,
    },
    {
      id: "slide3",
      src: "https://img.daisyui.com/images/stock/photo-1414694762283-acccc27bca85.webp",
      prev: 2,
      next: 4,
    },
    {
      id: "slide4",
      src: "https://img.daisyui.com/images/stock/photo-1665553365602-b2fb8e5d1707.webp",
      prev: 3,
      next: 1,
    },
  ];

  return (
    <>
      {/* <Marquee pauseOnHover={true} speed={100} direction="right">

      <div className="flex justify-center items-center py-5 bg-[#476ba1] text-white rounded-2xl my-5 w-310 px-5">
        <h1 className="text-3xl md:text-4xl font-bold tracking-wide ">
          Browse Our Pharmacyies 
        </h1>
      </div>

     </Marquee> */}
      <div className="container">
        <Carousel
          autoplay={{ dotDuration: true }}
          autoplaySpeed={2000}
          className="custom-carousel"
        >
          {slides.map((slide) => (
            <div key={slide.id} id={slide.id}>
              <img
                src={photoMap.get(slide.id)}
                style={contentStyle}
                className="w-full rounded-2xl "
              />
            </div>
          ))}
        </Carousel>
      </div>

      <div className="flex justify-center items-center py-5 text-[#476ba1] rounded-2xl my-5 px-5">
        <h1 className="text-3xl md:text-4xl font-bold tracking-wide ">
          Browse More Products
        </h1>
      </div>

      <div className="mt-10 mb-10">
        <Marquee pauseOnClick className="rounded-2xl" speed={100} direction="right">
          <div className="flex gap-10 mx-5">
          {products &&
            products.length > 0 &&
            products.map((p) => (
              <OneProduct
                key={p.productDto.productId}
                quantity={p.quantity}
                productDto={p.productDto}
                pharmacyDto={p.pharmacyDto}
                hover={false}
              />
            ))}
          </div>
        </Marquee>
      </div>

      <div className="mt-10 mb-10">
        <Marquee pauseOnClick className="rounded-2xl" speed={100}>
          <div className="flex gap-10 mx-5">
          {products &&
            products.length > 0 &&
            products.map((p) => (
              <OneProduct
                key={p.productDto.productId}
                quantity={p.quantity}
                productDto={p.productDto}
                pharmacyDto={p.pharmacyDto}
                hover={false}
              />
            ))}
          </div>
        </Marquee>
      </div>
    </>
  );
}
