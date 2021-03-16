import { Component } from '@angular/core';

@Component({
  selector: 'app-order-component',
  templateUrl: './order.component.html'
})
export class OrderComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
