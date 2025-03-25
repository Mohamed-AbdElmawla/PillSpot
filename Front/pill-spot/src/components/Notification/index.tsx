import { useState } from "react";
import { Drawer } from "antd";
import { IoNotificationsOutline } from "react-icons/io5";
import OneNotifiy from "./OneNotifiy/OneNotifiy";
const NotificationDrawer = () => {
  const [open, setOpen] = useState(false);

  const showDrawer = () => {
    setOpen(true);
  };

  const onClose = () => {
    setOpen(false);
  };

  return (
    <>
      <button onClick={showDrawer} className="text-3xl  text-[#02457A] cursor-pointer hover:scale-105 duration-100">
        <IoNotificationsOutline />
      </button>
      <Drawer title="Notification" onClose={onClose} open={open} className="rounded-tl-3xl rounded-bl-3xl">
        <OneNotifiy/>
        <OneNotifiy/>
        <OneNotifiy/>
        <OneNotifiy/>
        <OneNotifiy/>
        <OneNotifiy/>
        <OneNotifiy/>
        <OneNotifiy/>
        <OneNotifiy/>
        <OneNotifiy/>
        <OneNotifiy/>
        
      </Drawer>
    </>
  );
};

export default NotificationDrawer;
