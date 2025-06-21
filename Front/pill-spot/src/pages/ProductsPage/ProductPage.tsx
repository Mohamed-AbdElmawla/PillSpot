import React, { useEffect } from 'react';
import Header from './Header';
import FilterSidebar from './FilterSidebar';
import ProductGrid from './ProductGrid';
import Pagination from './Pagination';
import { useProducts } from '../../hooks/useProducts';

const ProductPage: React.FC = () => {
  const {
    products,
    totalProducts,
    loading,
    filters,
    pagination,
    updateFilters,
    updatePagination,
  } = useProducts();


  useEffect(()=>{
    console.log(filters)
  },[])




     const handleSearch = (query: string) => {
      updateFilters({ searchQuery: query });
    };
  
     const handleFilterChange = (newFilters: {
      categories: string[];
      priceRange: [number, number];
    }) => {
      updateFilters(newFilters);
    };
  
     const handlePageChange = (page: number) => {
      updatePagination({ currentPage: page });
      window.scrollTo({
        top: document.getElementById('products-section')?.offsetTop || 0,
        behavior: 'smooth',
      });
    };



  return (
    <div className="min-h-screen bg-gray-50">
      <Header onSearch={handleSearch} />
      
      <main className="container mx-auto px-4 py-8">
        <div className="flex flex-col md:flex-row gap-8">

          <FilterSidebar
            onFilterChange={handleFilterChange}
            className="md:w-64  sticky top-0"
          />
          
        
          <div className="flex-1" id="products-section">
            <div className="mb-6 flex flex-col sm:flex-row sm:items-center justify-between">
              <div>
                <h2 className="text-2xl font-bold text-gray-800">Products</h2>
                <p className="text-gray-600 mt-1">
                  {loading ? 'Loading...' : `Showing ${products.length} of ${totalProducts} products`}
                </p>
              </div>
              
              <div className="mt-4 sm:mt-0">
                <select 
                  className="p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:outline-none"
                  defaultValue="featured"
                >
                  <option value="featured">Featured</option>
                  <option value="newest">Newest</option>
                  <option value="price-low-high">Price: Low to High</option>
                  <option value="price-high-low">Price: High to Low</option>
                  <option value="rating">Highest Rated</option>
                </select>
              </div>
            </div>
            

            {/* // here we will send the products to be previewd 
            // implementation of calling back should be at this page  */}
            <ProductGrid products={products} loading={loading} />
            
            {pagination.totalPages > 1 && (
              <Pagination
                currentPage={pagination.currentPage}
                totalPages={pagination.totalPages}
                onPageChange={handlePageChange}
                className="mt-10"
              />
            )}
          </div>
        </div>
      </main>

    </div>
  );
};

export default ProductPage;