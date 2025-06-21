import React from 'react';
import { ChevronLeft, ChevronRight } from 'lucide-react';

interface PaginationProps {
  currentPage: number;
  totalPages: number;
  onPageChange: (page: number) => void;
  className?: string;
}

const Pagination: React.FC<PaginationProps> = ({
  currentPage,
  totalPages,
  onPageChange,
  className = '',
}) => {
  const pageNumbers = getPageNumbers(currentPage, totalPages);

  function getPageNumbers(current: number, total: number) {
    if (total <= 7) {
      return Array.from({ length: total }, (_, i) => i + 1);
    }


    if (current <= 3) {
      return [1, 2, 3, 4, 5, '...', total];
    } else if (current >= total - 2) {
      return [1, '...', total - 4, total - 3, total - 2, total - 1, total];
    } else {
      return [1, '...', current - 1, current, current + 1, '...', total];
    }
  }

  return (
    <div className={`flex items-center justify-center ${className}`}>
      <button
        onClick={() => onPageChange(currentPage - 1)}
        disabled={currentPage === 1}
        className="flex items-center justify-center p-2 rounded-md mr-2 disabled:opacity-50 disabled:cursor-not-allowed text-gray-700 hover:bg-gray-100 transition-colors duration-200"
        aria-label="Previous page"
      >
        <ChevronLeft size={20} />
      </button>

      <div className="flex items-center space-x-1">
        {pageNumbers.map((page, index) => (
          <React.Fragment key={index}>
            {page === '...' ? (
              <span className="px-3 py-1.5 text-gray-500">...</span>
            ) : (
              <button
                onClick={() => onPageChange(page as number)}
                className={`px-3 py-1.5 rounded-md transition-colors duration-200 ${
                  currentPage === page
                    ? 'bg-blue-500 text-white font-medium'
                    : 'text-gray-700 hover:bg-gray-100'
                }`}
              >
                {page}
              </button>
            )}
          </React.Fragment>
        ))}
      </div>

      <button
        onClick={() => onPageChange(currentPage + 1)}
        disabled={currentPage === totalPages}
        className="flex items-center justify-center p-2 rounded-md ml-2 disabled:opacity-50 disabled:cursor-not-allowed text-gray-700 hover:bg-gray-100 transition-colors duration-200"
        aria-label="Next page"
      >
        <ChevronRight size={20} />
      </button>
    </div>
  );
};

export default Pagination;