import React from 'react';
import { FiSearch } from 'react-icons/fi';
import { IoArrowBack } from 'react-icons/io5';

interface SearchHeaderProps {
  searchInput: string;
  onInputChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  onInputKeyDown: (e: React.KeyboardEvent<HTMLInputElement>) => void;
  searchType: 'products' | 'pharmacies';
  onTypeChange: (type: 'products' | 'pharmacies') => void;
  onBack: () => void;
}

const SearchHeader: React.FC<SearchHeaderProps> = ({
  searchInput,
  onInputChange,
  onInputKeyDown,
  searchType,
  onTypeChange,
  onBack,
}) => (
  <header className="w-full bg-[#334c83] text-[#1e2c41] shadow-md rounded-b-2xl px-4 py-6 flex flex-col items-center mb-4 relative">
    <button
      className="absolute left-4 top-1/2 -translate-y-1/2 flex items-center gap-2 bg-white/80 hover:bg-white text-[#334c83] px-3 py-1.5 rounded-full shadow transition-all border border-[#e3eaf6]"
      onClick={onBack}
    >
      <IoArrowBack size={20} />
      <span className="font-semibold text-sm">Back to Home</span>
    </button>
    <div className="w-full max-w-3xl flex flex-col sm:flex-row items-center gap-2">
      <div className="flex-1 w-full flex items-center glassmorphism rounded-full shadow-xl px-6 py-2 min-h-[44px] border border-[#e3eaf6] focus-within:border-[#334c83] focus-within:ring-2 focus-within:ring-[#334c83] transition-all bg-white/60 backdrop-blur-md">
        <FiSearch size={22} className="text-[#1e2c41] mr-2" />
        <input
          type="text"
          className="flex-1 bg-transparent outline-none border-none text-base py-1 text-[#1e2c41] placeholder:text-[#1e2c41]"
          placeholder={searchType === 'products' ? 'Search for products...' : 'Search for pharmacies...'}
          value={searchInput}
          onChange={onInputChange}
          onKeyDown={onInputKeyDown}
        />
      </div>
      <div className="flex gap-2 w-full sm:w-auto mt-2 sm:mt-0">
        <button
          className={`px-5 py-1.5 rounded-full font-semibold transition-colors w-full sm:w-auto text-sm shadow-md ${searchType==='products' ? 'bg-[#616e8a] text-white' : 'bg-[#fafafa] text-[#334c83] hover:bg-[#dbeafe]'}`}
          onClick={()=>onTypeChange('products')}
        >
          Products
        </button>
        <button
          className={`px-5 py-1.5 rounded-full font-semibold transition-colors w-full sm:w-auto text-sm shadow-md ${searchType==='pharmacies' ? 'bg-[#616e8a] text-white' : 'bg-[#e3eaf6] text-[#334c83] hover:bg-[#dbeafe]'}`}
          onClick={()=>onTypeChange('pharmacies')}
        >
          Pharmacies
        </button>
      </div>
    </div>
  </header>
);

export default SearchHeader; 