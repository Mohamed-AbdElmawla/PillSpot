export interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  category: string;
  image: string;
  rating: number;
  reviews: number;
  tags: string[];
  distance?: number; // Added for distance sorting
}

export interface FilterState {
  categories: string[];
  priceRange: [number, number];
  searchQuery: string;
  sortBy: string;
}

export interface PaginationState {
  currentPage: number;
  totalPages: number;
  itemsPerPage: number;
}