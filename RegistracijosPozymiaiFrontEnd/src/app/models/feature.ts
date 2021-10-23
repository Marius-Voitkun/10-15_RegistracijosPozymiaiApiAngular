import { DropDownOption } from "./drop-down-option";

export interface Feature {
  id: number;
  text: string;
  dropDownOptions: DropDownOption[];
  selectedOptionId: number;
}