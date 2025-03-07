import { useState } from "react";
import img1 from "../../../../assets/ph1.png";
import img2 from "../../../../assets/ph2.png";

export default function PharmacyWithUs() {
  const [currentSlide, setCurrentSlide] = useState(1);

  const goToSlide = (slideNumber: number) => {
    setCurrentSlide(slideNumber);
  };

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
    <div className="container">
      <div className="flex justify-center items-center py-8 bg-gradient-to-r from-gray-300  to-gray-400 text-white rounded-2xl my-5">
        <h1 className="text-3xl md:text-4xl font-bold tracking-wide">
          Pharmacies Deal with Us
        </h1>
      </div>

      <div className="carousel w-full rounded-2xl">
        {slides.map((slide, index) => (
          <div
            key={slide.id}
            id={slide.id}
            className={`carousel-item relative w-full ${
              currentSlide === index + 1 ? "block" : "hidden"
            }`}
          >
            <img src={photoMap.get(slide.id)} className="w-full" />
            <div className="absolute left-5 right-5 top-1/2 flex -translate-y-1/2 transform justify-between">
              <button
                className="btn btn-circle"
                onClick={() => goToSlide(slide.prev)}
              >
                ❮
              </button>
              <button
                className="btn btn-circle"
                onClick={() => goToSlide(slide.next)}
              >
                ❯
              </button>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}
