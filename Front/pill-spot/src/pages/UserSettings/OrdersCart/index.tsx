import CheckOutComp from "./CheckOut";
import OrdersRows from "./OrdersTable";
// import img from "../MainPage/images/image copy 5.png"
const OrdersCartPage = () => {
  return (
    <div className="mt-0 flex flex-col lg:flex-row gap-6 w-full px-4 lg:px-8 h-[89vh] rounded-2xl"
    // style={{
    //   backgroundImage: `url(${img})`,
    //   backgroundRepeat: "no-repeat",
    //   backgroundSize: "cover",
    //   backgroundPosition: "center",
    // }}
    >

      <div className="w-full lg:flex-[4]">
        <OrdersRows />
      </div>
      
      <div className="w-full lg:flex-1 max-w-lg mx-auto">
        <CheckOutComp />
      </div>
    </div>
  );
};

export default OrdersCartPage;
