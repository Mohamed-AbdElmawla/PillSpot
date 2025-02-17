import { DetailedHTMLProps, InputHTMLAttributes } from "react";

export interface Iprops extends DetailedHTMLProps<InputHTMLAttributes<HTMLInputElement>, HTMLInputElement> {
    name: string;
    type: string;
    title?: string;
}
