import { Currency } from "./Currency";

export type Balance = {
    userId: number;
    currency: Currency;
    amount: number;
}