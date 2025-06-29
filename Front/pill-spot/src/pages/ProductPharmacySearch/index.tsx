import React, { useState, useEffect } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { FetchHomeProducts } from '../../features/HomePage/Products/fetchProdcuts';
import { RootState, AppDispatch } from '../../app/store';
import SearchHeader from './SearchHeader';
import FilterSidebar from './FilterSidebar';
import ProductGrid from './ProductGrid';
import SearchByDistance from '../SearchByDistance';

const PAGE_SIZE = 15; // 5 per row, 3 rows

const ProductPharmacySearch: React.FC = () => {
  const location = useLocation();
  const params = new URLSearchParams(location.search);
  const initialSearch = params.get('medecinetosearch') || '';

  const [searchInput, setSearchInput] = useState(initialSearch);
  const [search, setSearch] = useState(initialSearch);
  const [searchType, setSearchType] = useState<'products' | 'pharmacies'>('products');
  const [priceRange, setPriceRange] = useState<[number, number]>([0, 100]);
  const [currentPage, setCurrentPage] = useState(1);

  const navigate = useNavigate();
  const dispatch = useDispatch<AppDispatch>();

  const products = useSelector((state: RootState) => state.fetchHomeProductSlice.Products);
  const loadingProducts = useSelector((state: RootState) => state.fetchHomeProductSlice.LoadingProducts);

  useEffect(() => {
    if (searchType === 'products') {
      if (search.trim()) {
        dispatch(FetchHomeProducts({ PageNumber: String(currentPage), PageSize: String(PAGE_SIZE), Name: search.trim() }));
      } else {
        dispatch(FetchHomeProducts({ PageNumber: String(currentPage), PageSize: String(PAGE_SIZE) }));
      }
    }
  }, [dispatch, currentPage, search, searchType]);

  const paginatedProducts = products || [];
  const totalProducts = products ? products.length : 0;
  const totalPages = Math.ceil(totalProducts / PAGE_SIZE);

  // Handlers
  const handleSearchInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearchInput(e.target.value);
  };
  const handleSearchInputKeyDown = (e: React.KeyboardEvent<HTMLInputElement>) => {
    if (e.key === 'Enter') {
      setSearch(searchInput);
      setCurrentPage(1);
    }
  };
  const handlePriceChange = (e: React.ChangeEvent<HTMLInputElement>, idx: 0 | 1) => {
    const val = Number(e.target.value);
    setPriceRange(prev => idx === 0 ? [val, prev[1]] : [prev[0], val]);
    setCurrentPage(1);
  };
  const handleTypeChange = (type: 'products' | 'pharmacies') => {
    setSearchType(type);
    setCurrentPage(1);
  };
  const handlePageChange = (page: number) => setCurrentPage(page);
  const handleBack = () => navigate('/homepage');

  return (
    <main className="min-h-screen bg-gradient-to-br from-[#f7f9fb] to-[#e3eaf6] py-0 w-full">
      <SearchHeader
        searchInput={searchInput}
        onInputChange={handleSearchInputChange}
        onInputKeyDown={handleSearchInputKeyDown}
        searchType={searchType}
        onTypeChange={handleTypeChange}
        onBack={handleBack}
      />
      <div className="w-full px-2 md:px-8 max-w-full">
        <div className="flex flex-col md:flex-row gap-8 mt-10 w-full">
          <FilterSidebar priceRange={priceRange} onPriceChange={handlePriceChange} />
          <div className="flex-1">
            {searchType === 'products' ? (
              <ProductGrid
                products={paginatedProducts}
                loading={loadingProducts}
                currentPage={currentPage}
                totalPages={totalPages}
                onPageChange={handlePageChange}
              />
            ) : (
              <SearchByDistance searchTerm={searchInput} />
            )}
          </div>
        </div>
      </div>
    </main>
  );
};

export default ProductPharmacySearch;
