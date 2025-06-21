import { Product } from './types';

// Using Pexels stock photos
export const products: Product[] = [
  {
    id: 1,
    name: 'Vanilla Ice Cream Cone',
    description: 'Classic vanilla ice cream in a crispy waffle cone.',
    price: 16,
    category: 'Desserts',
    image: 'https://images.pexels.com/photos/1352278/pexels-photo-1352278.jpeg',
    rating: 4.5,
    reviews: 455,
    tags: ['ice cream', 'dessert', 'summer']
  },
  {
    id: 2,
    name: 'Chocolate Chip Cookie',
    description: 'Freshly baked chocolate chip cookie with a soft center.',
    price: 12,
    category: 'Bakery',
    image: 'https://images.pexels.com/photos/230325/pexels-photo-230325.jpeg',
    rating: 4.7,
    reviews: 322,
    tags: ['cookie', 'chocolate', 'bakery']
  },
  {
    id: 3,
    name: 'Strawberry Smoothie',
    description: 'Refreshing strawberry smoothie made with fresh berries.',
    price: 18,
    category: 'Beverages',
    image: 'https://images.pexels.com/photos/161600/smoothie-fruit-vegetables-beetroot-161600.jpeg',
    rating: 4.2,
    reviews: 189,
    tags: ['smoothie', 'strawberry', 'drink']
  },
  {
    id: 4,
    name: 'Blueberry Muffin',
    description: 'Moist blueberry muffin packed with fresh blueberries.',
    price: 14,
    category: 'Bakery',
    image: 'https://images.pexels.com/photos/3731817/pexels-photo-3731817.jpeg',
    rating: 4.3,
    reviews: 211,
    tags: ['muffin', 'blueberry', 'bakery']
  },
  {
    id: 5,
    name: 'Caramel Latte',
    description: 'Rich espresso with steamed milk and caramel syrup.',
    price: 22,
    category: 'Beverages',
    image: 'https://images.pexels.com/photos/312418/pexels-photo-312418.jpeg',
    rating: 4.8,
    reviews: 387,
    tags: ['coffee', 'latte', 'caramel']
  },
  {
    id: 6,
    name: 'Chocolate Donut',
    description: 'Glazed chocolate donut with colorful sprinkles.',
    price: 10,
    category: 'Bakery',
    image: 'https://images.pexels.com/photos/2955820/pexels-photo-2955820.jpeg',
    rating: 4.1,
    reviews: 156,
    tags: ['donut', 'chocolate', 'dessert']
  },
  {
    id: 7,
    name: 'Fresh Fruit Salad',
    description: 'Assorted fresh fruits cut into bite-sized pieces.',
    price: 24,
    category: 'Healthy',
    image: 'https://images.pexels.com/photos/1092730/pexels-photo-1092730.jpeg',
    rating: 4.6,
    reviews: 278,
    tags: ['fruit', 'healthy', 'salad']
  },
  {
    id: 8,
    name: 'Avocado Toast',
    description: 'Whole grain toast topped with mashed avocado and spices.',
    price: 30,
    category: 'Healthy',
    image: 'https://images.pexels.com/photos/1351238/pexels-photo-1351238.jpeg',
    rating: 4.4,
    reviews: 201,
    tags: ['avocado', 'toast', 'breakfast']
  },
  {
    id: 9,
    name: 'Veggie Wrap',
    description: 'Fresh vegetables and hummus wrapped in a whole wheat tortilla.',
    price: 28,
    category: 'Healthy',
    image: 'https://images.pexels.com/photos/2067396/pexels-photo-2067396.jpeg',
    rating: 4.2,
    reviews: 143,
    tags: ['wrap', 'vegetarian', 'lunch']
  },
  {
    id: 10,
    name: 'Greek Yogurt Parfait',
    description: 'Greek yogurt layered with granola and fresh berries.',
    price: 20,
    category: 'Healthy',
    image: 'https://images.pexels.com/photos/1878241/pexels-photo-1878241.jpeg',
    rating: 4.5,
    reviews: 189,
    tags: ['yogurt', 'breakfast', 'healthy']
  },
  {
    id: 11,
    name: 'Cheese Pizza Slice',
    description: 'Classic cheese pizza slice with tomato sauce.',
    price: 15,
    category: 'Fast Food',
    image: 'https://images.pexels.com/photos/2233348/pexels-photo-2233348.jpeg',
    rating: 4.0,
    reviews: 312,
    tags: ['pizza', 'cheese', 'fast food']
  },
  {
    id: 12,
    name: 'Chocolate Milkshake',
    description: 'Thick and creamy chocolate milkshake topped with whipped cream.',
    price: 19,
    category: 'Beverages',
    image: 'https://images.pexels.com/photos/3727250/pexels-photo-3727250.jpeg',
    rating: 4.7,
    reviews: 233,
    tags: ['milkshake', 'chocolate', 'dessert']
  }
];

export const getAllCategories = (): string[] => {
  const categories = new Set<string>();
  products.forEach(product => categories.add(product.category));
  return Array.from(categories);
};

export const getPriceRange = (): [number, number] => {
  const prices = products.map(product => product.price);
  return [Math.min(...prices), Math.max(...prices)];
};