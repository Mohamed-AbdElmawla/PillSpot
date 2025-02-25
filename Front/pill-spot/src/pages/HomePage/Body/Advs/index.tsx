interface Iprops{
  image : string ;
  title:string ;
  price : string ;
  oldPrice : string ; 
  className:string ;
}

const AdCard = ({ image, title, price, oldPrice, className }:Iprops) => {
  return (
    <div className={`relative rounded-2xl overflow-hidden shadow-lg group ${className}`}>
     
      <div className="overflow-hidden">
        <img
          src={image}
          alt={title}
          className="w-full object-cover transition-transform duration-300 group-hover:scale-105"
        />
      </div>

    
      <div className="absolute inset-0 bg-gradient-to-t from-black/50 to-transparent transition-transform duration-300 group-hover:scale-105"></div>

      
      <div className="absolute bottom-4 left-4 text-white">
        <p className="text-xs font-semibold">EVERYTHING YOU MAY NEED</p>
        <h2 className="text-2xl font-bold">{title}</h2>
        <p className="text-lg">
          <span className="line-through opacity-70">${oldPrice}</span>
          <span className="ml-2 font-semibold">${price}</span>
        </p>
      </div>
    </div>
  );
};

const Advs = () => {
  return (
    <div className="container mx-auto ">
   
      <div className="grid grid-cols-1 md:grid-cols-1 lg:grid-cols-3 gap-5">
        
        <AdCard
          image="https://img.daisyui.com/images/stock/photo-1559703248-dcaaec9fab78.webp"
          title="Category"
          oldPrice="150"
          price="99"
          className="h-[600px]"
        />
        <AdCard
          image="https://img.daisyui.com/images/stock/photo-1559703248-dcaaec9fab78.webp"
          title="Category Set"
          oldPrice="150"
          price="99"
          className="h-[600px]"
        />

       
        <div className="flex flex-col gap-5">
          <div className="grid grid-cols-2 gap-5">
            <AdCard
              image="https://img.daisyui.com/images/stock/photo-1559703248-dcaaec9fab78.webp"
              title="Category Set"
              oldPrice="150"
              price="99"
              className="h-[300px]"
            />
            <AdCard
              image="https://img.daisyui.com/images/stock/photo-1559703248-dcaaec9fab78.webp"
              title="Category Set"
              oldPrice="150"
              price="99"
              className="h-[300px]"
            />
          </div>

          <AdCard
            image="https://img.daisyui.com/images/stock/photo-1559703248-dcaaec9fab78.webp"
            title="Category Set"
            oldPrice="150"
            price="99"
            className="h-[280px] w-full"
          />
        </div>
      </div>
    </div>
  );
};

export default Advs;
