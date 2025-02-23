import { toast } from "sonner";

interface Iprops {
  itemToSearch: string;
}

const StockItem = ({ itemToSearch }: Iprops) => {
  // effect will get all data soon
  if (!itemToSearch) {
    return (
      <div className="flex w-52 flex-col gap-4 m-auto">
        <div className="skeleton h-32 w-full"></div>
        <div className="skeleton h-4 w-28"></div>
        <div className="skeleton h-4 w-full"></div>
        <div className="skeleton h-4 w-full"></div>
      </div>
    );
  }

  return (
    <div className="card bg-base-100 w-96 shadow-sm">
      <figure>
        <img
          src="https://img.daisyui.com/images/stock/photo-1606107557195-0e29a4b5b4aa.webp"
          alt="Shoes"
        />
      </figure>

      <div className="flex gap-2 mx-5 mt-5">
        <div className="badge badge-ghost bg-gray-200">50 $</div>
        <div className="badge badge-ghost bg-gray-200">Tablets</div>
        <div className="badge badge-ghost bg-gray-200">only 3 in stock </div>
      </div>
      <div>
        <div className="flex items-center justify-between mx-5 my-3">
          <h2 className="card-title font-bold text-2xl">Card Title</h2>

          <div className="card-actions justify-end">
            <button
              className="btn btn-primary"
              onClick={() =>
                toast.success("Added to cart", {
                  action: {
                    label: "Undo",
                    onClick: () => console.log("Undo"), //, upadte state
                  },
                })
              }
            >
              Add to cart
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default StockItem;
