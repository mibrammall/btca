export interface Order {
  description: string;
  orderTotal: number;
  orderProducts: OrderProduct[];
}

export interface OrderProduct {
  name: string;
  price: number;
  quantity: number;
}
