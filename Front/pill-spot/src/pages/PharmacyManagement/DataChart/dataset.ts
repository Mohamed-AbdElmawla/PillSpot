export const dataset = [
  {
    price: 34,
    month: "Jan",
  },
  {
    price: 100,
    month: "Feb",
  },
  {
    price: 50,
    month: "Mar",
  },
  {
    price: 10,
    month: "Apr",
  },
  {
    price: 40,
    month: "May",
  },
  {
    price: 102,
    month: "June",
  },
  {
    price: 43,
    month: "July",
  },
  {
    price: 26,
    month: "Aug",
  },
  {
    price: 1,
    month: "Sept",
  },
  {
    price: 84,
    month: "Oct",
  },
  {
    price: 27,
    month: "Nov",
  },
  {
    price: 85,
    month: "Dec",
  },
];

export function valueFormatter(value: number | null) {
  return `${value} EGP`;
}
