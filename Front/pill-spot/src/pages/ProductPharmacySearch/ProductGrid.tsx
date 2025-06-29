import React from 'react';
import OneProduct from '../HomePage/Body/Products/oneProduct';

interface ProductGridProps {
  products: any[];
  loading: boolean;
  currentPage: number;
  totalPages: number;
  onPageChange: (page: number) => void;
}

const ProductGrid: React.FC<ProductGridProps> = ({ products, loading, currentPage, totalPages, onPageChange }) => {
  if (loading) {
    return (
      <div className="flex justify-center items-center h-40">
        <span className="loading loading-ring w-20 h-20"></span>
      </div>
    );
  }
  return (
    <>
      <div className="grid grid-cols-2 sm:grid-cols-3 md:grid-cols-4 lg:grid-cols-5 gap-4 my-6 w-full">
        {products.length > 0 ? products.map(product => {
          // Map backend product to OneProduct expected shape
          const productDto = {
            ...product.productDto,
            usageInstructions: 'usageInstructions' in product.productDto ? (product.productDto as unknown as { usageInstructions: string }).usageInstructions : '',
            manufacturer: 'manufacturer' in product.productDto ? (product.productDto as unknown as { manufacturer: string }).manufacturer : '',
            subCategoryDto: product.productDto.subCategoryDto || { categoryDto: { categoryId: '', name: '' }, subCategoryId: '', name: '' },
          };
          const pharmacyDto = product.pharmacyDto
            ? {
                ...product.pharmacyDto,
                locationDto: product.pharmacyDto.locationDto || { longitude: 0, latitude: 0, additionalInfo: '', cityDto: null },
              }
            : {
                pharmacyId: '',
                name: '',
                logoURL: '',
                logo: null,
                locationDto: { longitude: 0, latitude: 0, additionalInfo: '', cityDto: null },
                contactNumber: '',
                openingTime: '',
                closingTime: '',
                isOpen24: false,
                daysOpen: '',
              };
          const mappedProduct = {
            ...product,
            productDto,
            pharmacyDto,
          };
          return (
            <div className="w-full max-w-xs mx-auto" key={product.productDto.productId}>
              <OneProduct {...mappedProduct} hover={false} />
            </div>
          );
        }) : <p className="col-span-full text-center text-[#334c83]">No products found.</p>}
      </div>
      {/* Modern Pagination Section */}
      <div className="flex justify-center gap-2 mt-12 mb-8">
        {Array.from({ length: totalPages }).map((_, idx) => (
          <button
            key={idx}
            className={`px-4 py-2 rounded-full font-semibold border-2 transition-all duration-150 shadow-sm ${currentPage === idx + 1 ? 'bg-[#334c83] text-white border-[#334c83] scale-110' : 'bg-white/80 text-[#334c83] border-[#e3eaf6] hover:bg-[#e3eaf6] hover:border-[#334c83]'}`}
            onClick={() => onPageChange(idx + 1)}
          >
            {idx + 1}
          </button>
        ))}
      </div>
    </>
  );
};

export default ProductGrid; 