import styled from "styled-components";

export const StyledButton = styled("button")<{ color?: string }>`
  background: ${(p) => p.color || "#02457a"};
  color: ${(p) => (p.color ? "#2E186A" : "#fff")};
  font-size: 1rem;
  font-weight: 700;
  width: 100%;
  border: 1px solid #edf3f5;
  border-radius: 5px;
  padding: 13px 0;
  cursor: pointer;
  margin-top: 0.625rem;
  max-width: 180px;
  transition: all 0.3s ease-in-out;
  box-shadow: 0 16px 30px rgb(23 31 114 / 20%);

  &:hover,
  &:active,
  &:focus {
    color: #fff;
    border: 1px solid rgb(40, 40, 241);
    background-color: rgb(78, 75, 231);
  }
`;
