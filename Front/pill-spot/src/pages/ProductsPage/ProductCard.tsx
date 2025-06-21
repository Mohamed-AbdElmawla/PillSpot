import React, { useState } from 'react';
import { Star, Heart } from 'lucide-react';
import { Product } from './types';

interface ProductCardProps {
  product: Product;
}

const ProductCard: React.FC<ProductCardProps> = ({ product }) => {
  const [isFavorite, setIsFavorite] = useState(false);
  
  // Calculate full and partial stars for rating display
  const fullStars = Math.floor(product.rating);
  const hasHalfStar = product.rating % 1 >= 0.5;
  
  return (
    <div className="bg-white rounded-lg shadow-md overflow-hidden transition-transform duration-300 hover:shadow-lg hover:translate-y-[-4px]">
      <div className="relative">
        <img 
          src={product.image} 
          alt={product.name} 
          className="w-full h-48 object-cover"
        />
        <button 
          className="absolute top-2 right-2 p-1.5 rounded-full bg-white/80 hover:bg-white transition-colors duration-200"
          onClick={() => setIsFavorite(!isFavorite)}
          aria-label={isFavorite ? "Remove from favorites" : "Add to favorites"}
        >
          <Heart 
            size={20} 
            className={`transition-colors duration-200 ${isFavorite ? 'fill-red-500 text-red-500' : 'text-gray-400'}`} 
          />
        </button>
      </div>
      
      <div className="p-4">
        <div className="text-xs text-blue-600 font-semibold mb-1">
          {product.category}
        </div>
        
        <h3 className="font-medium text-gray-900 mb-2 line-clamp-2 h-12">
          {product.name}
        </h3>
        
        <div className="flex items-center mb-3">
          <div className="flex mr-2">
            {[...Array(5)].map((_, i) => (
              <Star 
                key={i} 
                size={16} 
                className={`${
                  i < fullStars 
                    ? 'text-yellow-400 fill-yellow-400' 
                    : i === fullStars && hasHalfStar 
                      ? 'text-yellow-400 fill-yellow-400' 
                      : 'text-gray-300'
                }`} 
              />
            ))}
          </div>
          <span className="text-sm text-gray-600">
            {product.rating.toFixed(1)} ({product.reviews})
          </span>
        </div>
        
        <div className="flex items-center justify-between mt-3">
          <div className="text-xl font-bold text-gray-900">${product.price}</div>
          <button className="bg-blue-500 text-white px-3 py-1.5 rounded-md hover:bg-blue-600 transition-colors duration-200 text-sm font-medium">
            Add to Cart
          </button>
        </div>
      </div>
    </div>
  );
};

export default ProductCard;