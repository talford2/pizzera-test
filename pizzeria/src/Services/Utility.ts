export class Utility {
  static formatCurrency = (amount: number): string =>
    new Intl.NumberFormat("en-AU", {
      style: "currency",
      currency: "AUD",
    }).format(amount);
}
