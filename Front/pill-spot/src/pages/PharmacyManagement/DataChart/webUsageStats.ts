// Data derived from https://gs.statcounter.com/os-market-share/desktop/worldwide/2023
// And https://gs.statcounter.com/os-market-share/mobile/worldwide/2023
// And https://gs.statcounter.com/platform-market-share/desktop-mobile-tablet/worldwide/2023
// For the month of December 2023


  
  export const mobileOS = [
    { label: 'Day1', value: Math.random() * 100 },
  { label: 'Day2', value: Math.random() * 100 },
  { label: 'Day3', value: Math.random() * 100 },
  { label: 'Day4', value: Math.random() * 100 },
  { label: 'Day5', value: Math.random() * 100 },
  { label: 'Day6', value: Math.random() * 100 },
  { label: 'Day7', value: Math.random() * 100 },
  ];
  
  export const platforms = [
    {
      label: 'Mobile',
      value: 59.12,
    },
    {
      label: 'Desktop',
      value: 40.88,
    },
  ];
  
 
  
  
  export const valueFormatter = (item: { value: number }) => `${item.value}%`;
  