import React from 'react';
import ProductCard from './ProductCard';
import { Product } from './types';

interface ProductGridProps {
  products: Product[];
  loading?: boolean;
}

const ProductGrid: React.FC<ProductGridProps> = ({ products, loading = false }) => {
  if (loading) {
    return (

      // skeleton
      <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
        {[...Array(8)].map((_, index) => (
          <div key={index} className="bg-white rounded-lg shadow-md p-4 animate-pulse">
            <div className="w-full h-48 bg-gray-200 rounded mb-4"></div>
            <div className="h-4 bg-gray-200 rounded w-1/4 mb-2"></div>
            <div className="h-6 bg-gray-200 rounded w-3/4 mb-3"></div>
            <div className="flex mb-3">
              <div className="h-4 w-4 bg-gray-200 rounded-full mr-1"></div>
              <div className="h-4 w-4 bg-gray-200 rounded-full mr-1"></div>
              <div className="h-4 w-4 bg-gray-200 rounded-full mr-1"></div>
              <div className="h-4 w-4 bg-gray-200 rounded-full mr-1"></div>
              <div className="h-4 w-4 bg-gray-200 rounded-full mr-1"></div>
            </div>
            <div className="flex justify-between items-center">
              <div className="h-6 bg-gray-200 rounded w-1/4"></div>
              <div className="h-8 bg-gray-200 rounded w-1/3"></div>
            </div>
          </div>
        ))}
      </div>
    );
  }

  if (products.length === 0) {
    return (
      <div className="flex flex-col items-center justify-center py-12">
        <div className="text-6xl mb-4">🔍</div>
        <h3 className="text-xl font-medium text-gray-700 mb-2">No products found</h3>
        <p className="text-gray-500">Try adjusting your search or filter criteria</p>
      </div>
    );
  }


  // send product by product 
  return (
    
    <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
      {products.map((product) => (
        <ProductCard key={product.id} product={product} />
      ))}
    </div>
  );
};

export default ProductGrid;