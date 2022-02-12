import React from "react";
import Link from "next/link";
const menuItems = [
  {
    name: "Upcomings",
    to: "/upcomings",
  },
  {
    name: "Sports",
    to: "/sports",
  },
  {
    name: "Events",
    to: "/events",
  },
  {
    name: "Contact",
    to: "/contact",
  },
];
export default function Header() {
  return (
    <div className="w-full px-44 h-28 flex flex-col justify-center py-6 z-50 fixed">
      <div className="w-full flex justify-between  h-full">
        <div className="w-40 h-full flex items-center justify-start font-bold text-xl text-black">
          ikincibilet
        </div>
        <div className="flex items-center gap-x-8 text-xl font-bold text-black">
          {menuItems.map((item, index) => (
            <Link className="" href={item.to} key={index}>
              {item.name}
            </Link>
          ))}
        </div>
      </div>
      <div className="w-full h-1 mt-4 rounded bg-white">
      </div>
    </div>
  );
}
