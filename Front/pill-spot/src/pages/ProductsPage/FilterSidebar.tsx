import React, { useState, useEffect } from 'react';
import { getAllCategories, getPriceRange } from './products';

interface FilterSidebarProps {
  onFilterChange: (filters: {
    categories: string[];
    priceRange: [number, number];
    sortBy: string;
  }) => void;
  className?: string;
}

const FilterSidebar: React.FC<FilterSidebarProps> = ({
  onFilterChange,
  className = '',
}) => {
  const allCategories = getAllCategories();
  const [minMaxPrice] = useState<[number, number]>(getPriceRange());
  
  const [selectedCategories, setSelectedCategories] = useState<string[]>([]);
  const [priceRange, setPriceRange] = useState<[number, number]>(minMaxPrice);
  const [currentPriceInput, setCurrentPriceInput] = useState<[number, number]>(minMaxPrice);
  const [sortBy, setSortBy] = useState<string>('featured');

  useEffect(() => {
    onFilterChange({
      categories: selectedCategories,
      priceRange,
      sortBy,
    });
  }, [selectedCategories, priceRange, sortBy, onFilterChange]);

  const handleCategoryChange = (category: string) => {
    setSelectedCategories((prev) => {
      if (prev.includes(category)) {
        return prev.filter((cat) => cat !== category);
      } else {
        return [...prev, category];
      }
    });
  };

  const handlePriceInputChange = (index: number, value: string) => {
    const numValue = parseInt(value, 10) || 0;
    const newPriceInput = [...currentPriceInput] as [number, number];
    newPriceInput[index] = numValue;
    setCurrentPriceInput(newPriceInput);
  };

  const applyPriceFilter = () => {
    const sortedPrices: [number, number] = [
      Math.min(currentPriceInput[0], currentPriceInput[1]),
      Math.max(currentPriceInput[0], currentPriceInput[1])
    ];
    setPriceRange(sortedPrices);
  };

  const resetFilters = () => {
    setSelectedCategories([]);
    setPriceRange(minMaxPrice);
    setCurrentPriceInput(minMaxPrice);
    setSortBy('featured');
  };

  return (
    <aside className={`bg-white p-6 rounded-lg shadow-md ${className}`}>
      <div className="flex justify-between items-center mb-6">
        <h2 className="text-xl font-semibold text-gray-800">Filters</h2>
        <button
          onClick={resetFilters}
          className="text-sm text-blue-500 hover:text-blue-700 transition-colors duration-200"
        >
          Reset All
        </button>
      </div>

      {/* Sort Options */}
      <div className="mb-8">
        <h3 className="text-lg font-medium text-gray-700 mb-4">Sort By</h3>
        <select
          value={sortBy}
          onChange={(e) => setSortBy(e.target.value)}
          className="w-full p-2 border border-gray-300 rounded focus:ring-2 focus:ring-blue-500 focus:outline-none"
        >
          <option value="featured">Featured</option>
          <option value="nearest">Nearest Pharmacy</option>
          <option value="farthest">Farthest Pharmacy</option>
          <option value="price-low-high">Price: Low to High</option>
          <option value="price-high-low">Price: High to Low</option>
          <option value="rating">Highest Rated</option>
        </select>
      </div>

      {/* Price Range Filter */}
      <div className="mb-8">
        <h3 className="text-lg font-medium text-gray-700 mb-4">Price Range</h3>
        <div className="flex items-center space-x-4 mb-4">
          <div className="w-full">
            <label htmlFor="min-price" className="block text-sm text-gray-600 mb-1">Min ($)</label>
            <input
              type="number"
              id="min-price"
              min={minMaxPrice[0]}
              max={minMaxPrice[1]}
              value={currentPriceInput[0]}
              onChange={(e) => handlePriceInputChange(0, e.target.value)}
              className="w-full p-2 border border-gray-300 rounded focus:ring-2 focus:ring-blue-500 focus:outline-none"
            />
          </div>
          <div className="w-full">
            <label htmlFor="max-price" className="block text-sm text-gray-600 mb-1">Max ($)</label>
            <input
              type="number"
              id="max-price"
              min={minMaxPrice[0]}
              max={minMaxPrice[1]}
              value={currentPriceInput[1]}
              onChange={(e) => handlePriceInputChange(1, e.target.value)}
              className="w-full p-2 border border-gray-300 rounded focus:ring-2 focus:ring-blue-500 focus:outline-none"
            />
          </div>
        </div>
        <button
          onClick={applyPriceFilter}
          className="w-full bg-blue-500 text-white py-2 rounded hover:bg-blue-600 transition-colors duration-200"
        >
          Apply
        </button>
        <div className="mt-2 text-sm text-gray-500 text-center">
          Current: ${priceRange[0]} - ${priceRange[1]}
        </div>
      </div>

      {/* Category Filter */}
      <div>
        <h3 className="text-lg font-medium text-gray-700 mb-4">Categories</h3>
        <div className="space-y-2">
          {allCategories.map((category) => (
            <div key={category} className="flex items-center">
              <input
                type="checkbox"
                id={`category-${category}`}
                checked={selectedCategories.includes(category)}
                onChange={() => handleCategoryChange(category)}
                className="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 rounded focus:ring-blue-500"
              />
              <label
                htmlFor={`category-${category}`}
                className="ml-2 text-gray-700 cursor-pointer select-none"
              >
                {category}
              </label>
            </div>
          ))}
        </div>
      </div>
    </aside>
  );
};

export default FilterSidebar;