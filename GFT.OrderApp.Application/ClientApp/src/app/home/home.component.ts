import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OrderService } from './services/order.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  requestedOrders = new Array<string>();
  lastRequestedOrder: string;
  errors = new Array<string>();
  
  orderForm: FormGroup;

  constructor(
    private orderService: OrderService,
    private fb: FormBuilder,) { 
  }

  ngOnInit() {
    this.buldForm();
  }

reset(){  
  this.errors = new Array<string>();
  this.buldForm();
}

  buldForm() {
    this.orderForm = this.fb.group({
      input: ['morning, 1, 2, 3', Validators.required]
    });
  }

  sendOrder() {

    if (this.orderForm.invalid)
      return;

    this.orderService.sendOrder(this.orderForm.value)
      .subscribe((response) => {
        this.requestedOrders.push(response.output);     
        
        this.lastRequestedOrder = response.output;
        this.reset();
      },
      error  => {
        
        error.error.forEach(element => {
          this.errors.push(element.ErrorMessage);
        });
        
      });
  }
}
