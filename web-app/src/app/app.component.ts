import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

import { Order } from '../models/Order';

@Component({
  standalone: true,
  imports: [CommonModule, RouterModule],
  selector: 'web-app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  orders: Order[] = [];
  title: string;
  year = new Date().getFullYear();

  constructor(http: HttpClient) {
    this.title = 'web-app';
    http.get<Order[]>('/api/order/1').subscribe((orders) => {
      this.orders = orders;
    });
  }
}
