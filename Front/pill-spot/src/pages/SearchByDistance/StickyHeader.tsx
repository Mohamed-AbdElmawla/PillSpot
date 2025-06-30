import React from 'react';
import LogoSVG from '../../UI/LogoSVG';
import { useNavigate } from 'react-router-dom';

const StickyHeader: React.FC = () => {
  const navigate = useNavigate();
  return (
    <div className="sticky top-0 z-20 bg-gradient-to-br from-[#f7f9fb] to-[#e3eaf6] py-4 px-4 md:px-16 border-b border-slate-200 shadow-sm">
      <div className="flex items-center justify-between w-full gap-4">
        {/* Pillspot name and logo at the start */}
        <div className="flex items-center gap-2">
          <span className="text-2xl md:text-3xl font-bold text-[#02457a] tracking-tight">Pillspot</span>
          <LogoSVG w="40" h="40" />
        </div>
        {/* Back to Home button at the end */}
        <button
          className="flex items-center gap-2 text-[#02457a] hover:text-blue-700 font-semibold px-4 py-2 rounded transition border border-blue-100 bg-white shadow-sm"
          onClick={() => navigate('/homepage')}
        >
          <svg className="w-5 h-5" fill="none" stroke="currentColor" strokeWidth="2" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" d="M3 12l9-9 9 9M4 10v10a1 1 0 0 0 1 1h3m10-11v10a1 1 0 0 1-1 1h-3" /></svg>
          <span>Back to Home</span>
        </button>
      </div>
    </div>
  );
};

export default StickyHeader; 