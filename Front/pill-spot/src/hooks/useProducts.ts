import { useState, useEffect, useMemo } from 'react';
import { FilterState, PaginationState } from '../pages/ProductsPage/types';
import { products as allProducts } from '../pages/ProductsPage/products';

export const useProducts = () => {
  const [filters, setFilters] = useState<FilterState>({
    categories: [],
    priceRange: [0, 1000],
    searchQuery: '',
    sortBy: 'featured',
  });

  const [pagination, setPagination] = useState<PaginationState>({
    currentPage: 1,
    totalPages: 1,
    itemsPerPage: 8,
  });

  const [loading, setLoading] = useState(false);

  // Filter and sort products
  const filteredProducts = useMemo(() => {
    const filtered = allProducts.filter((product) => {
      // Filter by price
      if (
        product.price < filters.priceRange[0] ||
        product.price > filters.priceRange[1]
      ) return false;

      // Filter by categories
      if (
        filters.categories.length > 0 &&
        !filters.categories.includes(product.category)
      ) return false;

      // Search query filtering
      if (filters.searchQuery) {
        const query = filters.searchQuery.toLowerCase();
        const matchesName = product.name.toLowerCase().includes(query);
        const matchesDescription = product.description.toLowerCase().includes(query);
        const matchesCategory = product.category.toLowerCase().includes(query);
        const matchesTags = product.tags.some(tag => tag.toLowerCase().includes(query));
        if (!(matchesName || matchesDescription || matchesCategory || matchesTags)) {
          return false;
        }
      }

      return true;
    });

    console.log(filtered)

    // Sorting
    switch (filters.sortBy) {
      case 'nearest':
        filtered.sort((a, b) => (a.distance || 0) - (b.distance || 0));
        break;
      case 'farthest':
        filtered.sort((a, b) => (b.distance || 0) - (a.distance || 0));
        break;
      case 'price-low-high':
        filtered.sort((a, b) => a.price - b.price);
        break;
      case 'price-high-low':
        filtered.sort((a, b) => b.price - a.price);
        break;
      case 'rating':
        filtered.sort((a, b) => b.rating - a.rating);
        break;
      default:
        break;
    }

    return filtered;
  }, [filters]);

  // Safely update pagination when filtered products change
  useEffect(() => {
    const newTotalPages = Math.max(1, Math.ceil(filteredProducts.length / pagination.itemsPerPage));
    setPagination((prev) => {
      if (prev.currentPage !== 1 || prev.totalPages !== newTotalPages) {
        return {
          ...prev,
          currentPage: 1,
          totalPages: newTotalPages,
        };
      }
      return prev;
    });
  }, [filteredProducts]);



  // here we should call the back endpoint 
  const paginatedProducts = useMemo(() => {
    const startIndex = (pagination.currentPage - 1) * pagination.itemsPerPage;
    const endIndex = startIndex + pagination.itemsPerPage;
    return filteredProducts.slice(startIndex, endIndex);
  }, [filteredProducts, pagination.currentPage, pagination.itemsPerPage]);

  useEffect(() => {
    setLoading(true);
    const timer = setTimeout(() => {
      setLoading(false);
    }, 500);
    return () => clearTimeout(timer);
  }, [filters, pagination.currentPage]);

  // Safe filter update
  const updateFilters = (newFilters: Partial<FilterState>) => {
    setFilters((prev) => {
      const updated = { ...prev, ...newFilters };
      const isEqual = JSON.stringify(prev) === JSON.stringify(updated);
      return isEqual ? prev : updated;
    });
  };


  const updatePagination = (newPagination: Partial<PaginationState>) => {
    console.log(pagination) ;
    setPagination((prev) => {
      const updated = { ...prev, ...newPagination };
      const isEqual = JSON.stringify(prev) === JSON.stringify(updated);
      return isEqual ? prev : updated;
    });
  };

  return {
    products: paginatedProducts,
    totalProducts: filteredProducts.length,
    loading,
    filters,
    pagination,
    updateFilters,
    updatePagination,
  };
};
