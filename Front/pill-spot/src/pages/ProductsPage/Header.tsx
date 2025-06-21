import React, { useState } from 'react';
import { Search, ArrowLeft } from 'lucide-react';

interface HeaderProps {
  onSearch: (query: string) => void;
}

const Header: React.FC<HeaderProps> = ({ onSearch }) => {
  const [searchQuery, setSearchQuery] = useState('');

  const handleSearch = (e: React.FormEvent) => {
    e.preventDefault();
    onSearch(searchQuery);
  };

  return (
    <header className="z-10 bg-white shadow-sm">
      <div className="container mx-auto px-4 py-4">
        <div className="flex items-center justify-between">
          <button 
            className="flex items-center text-gray-600 hover:text-blue-500 transition-colors duration-200"
            onClick={() => window.history.back()}
          >
            <ArrowLeft size={24} />
          </button>
          
          <form onSubmit={handleSearch} className="w-full max-w-xl mx-auto">
            <div className="relative mx">
              <input
                type="text"
                placeholder="Search for products..."
                className="w-full px-4 py-2 pl-10 pr-4 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent transition-all duration-200"
                value={searchQuery}
                onChange={(e) => setSearchQuery(e.target.value)}
              />
              <div className="absolute inset-y-0 left-0 flex items-center pl-3 pointer-events-none">
                <Search size={18} className="text-gray-400" />
              </div>
              <button
                type="submit"
                className="absolute inset-y-0 right-0 flex items-center px-4 bg-blue-900 text-white rounded-r-lg hover:bg-blue-600 transition-colors duration-200"
              >
                Search
              </button>
            </div>
          </form>
        </div>
      </div>
    </header>
  );
};

export default Header;