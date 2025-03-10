import { MdOutlineShoppingBag } from "react-icons/md";

const HomeCart = () => {
  return (
    <div className="drawer drawer-end w-15 z-100000">
      <input id="my-drawer-4" type="checkbox" className="drawer-toggle" />
      <div className="drawer-content mx-auto">
        
        <label htmlFor="my-drawer-4" className="drawer-button">
          <MdOutlineShoppingBag className="text-4xl hover:cursor-pointer hover:scale-140 duration-200 text-white" />
        </label>
      </div>
      <div className="drawer-side">
        <label
          htmlFor="my-drawer-4"
          aria-label="close sidebar"
          className="drawer-overlay"
        ></label>
        <ul className="menu bg-base-200 text-base-content min-h-full w-90 p-4 mr-[20px]">
          <li>
            <a>
              
              <span className="countdown font-mono text-6xl">
                <span style={{ "--value": 59 } as React.CSSProperties }>
                  59
                </span>
              </span>
            </a>
          </li>
          <li>
            <a>Sidebar Item 2</a>
          </li>
        </ul>
      </div>
    </div>
  );
};

export default HomeCart;
