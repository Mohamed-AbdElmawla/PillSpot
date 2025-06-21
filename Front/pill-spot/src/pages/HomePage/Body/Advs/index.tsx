
import img1 from './Untitled-2.jpg'
import img2 from './Untitled-3.jpg'
import img3 from './Untitled-1.jpg'
import img4 from './Untitled-4.jpg'
import img5 from './Untitled-5.jpg'

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
          className="w-full h-full object-fill transition-transform duration-300 group-hover:scale-105"
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
    <div className="container mx-auto p-5 rounded-2xl ">
   
      <div className="grid grid-cols-1 md:grid-cols-1 lg:grid-cols-3 gap-5">
        
        <AdCard
          image={img1}
          title="Analgesic"
          oldPrice="150"
          price="78"
          className="h-[600px]"
        />
        <AdCard
          image={img2}
          title="Category Set"
          oldPrice="50"
          price="20"
          className="h-[600px]"
        />

       
        <div className="flex flex-col gap-5">
          <div className="grid grid-cols-2 gap-5">
            <AdCard
              image={img3}
              title="Baby Set"
              oldPrice="150"
              price="99"
              className="h-[300px]"
            />
            <AdCard
              image={img4}
              title="Cosmatics"
              oldPrice="150"
              price="90"
              className="h-[300px]"
            />
          </div>

          <AdCard
            image={img5}
            title="ToothSet"
            oldPrice="50"
            price="45"
            className="h-[280px] w-full"
          />
        </div>
      </div>
    </div>
  );
};

export default Advs;
