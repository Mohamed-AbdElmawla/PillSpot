import React from 'react';
import { FiSliders, FiDollarSign } from 'react-icons/fi';

interface FilterSidebarProps {
  priceRange: [number, number];
  onPriceChange: (e: React.ChangeEvent<HTMLInputElement>, idx: 0 | 1) => void;
}

const FilterSidebar: React.FC<FilterSidebarProps> = ({ priceRange, onPriceChange }) => (
  <aside className="w-full md:w-72 bg-white/80 rounded-3xl shadow-xl p-8 h-fit border border-[#e3eaf6] glassmorphism">
    <div className="flex items-center gap-2 mb-6 text-[#334c83]">
      <FiSliders size={20} />
      <h3 className="text-xl font-bold">Filters</h3>
    </div>
    <div className="mb-8">
      <div className="flex items-center gap-2 mb-2 text-[#476ba1]">
        <FiDollarSign size={18} />
        <span className="font-semibold">Price Range</span>
      </div>
      <div className="flex items-center gap-2">
        <input
          type="number"
          min={0}
          max={priceRange[1]}
          value={priceRange[0]}
          onChange={e => onPriceChange(e, 0)}
          className="w-20 rounded-lg border border-[#e3eaf6] px-2 py-1 focus:ring-2 focus:ring-[#334c83] transition-all"
        />
        <span className="font-bold text-[#334c83]">-</span>
        <input
          type="number"
          min={priceRange[0]}
          max={1000}
          value={priceRange[1]}
          onChange={e => onPriceChange(e, 1)}
          className="w-20 rounded-lg border border-[#e3eaf6] px-2 py-1 focus:ring-2 focus:ring-[#334c83] transition-all"
        />
      </div>
    </div>
    {/* Add more filter sections here if needed */}
  </aside>
);

export default FilterSidebar; 