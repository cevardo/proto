import { AppValidators } from "./../../../shared/validators/app-validators";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Component, OnInit, Output, EventEmitter } from "@angular/core";

import * as fromOrder from "./../../reducers/order";
import { PayPal, PayPalPayment, PayPalConfiguration } from "@ionic-native/paypal/ngx";
import { Platform } from "@ionic/angular";
import { Store } from "@ngrx/store";
import * as cartActions from "./../../actions/cart.actions";
import * as fromCart from "./../../reducers"
import { Observable } from 'rxjs';
import { CartRow } from 'src/app/shop/core/models/cart-row';
import { map } from 'rxjs/operators';
import { CartService } from 'src/app/shop/core/services/cart.service';

declare var paypal: any;

@Component({
  selector: "app-order-form",
  templateUrl: "./order-form.component.html",
  styleUrls: ["./order-form.component.css"]
})
export class OrderFormComponent implements OnInit {

  submitted = false;

  total$: Observable<number>;
  cartRows: CartRow[];

  constructor(
    private store: Store<fromCart.State>,
    private payPal: PayPal,
    private platform: Platform,
    private cartService: CartService) {
  }

  ngOnInit() {
    let self = this;
    paypal.Buttons({
      createOrder(data, actions) {
        // Set up the transaction
        return actions.order.create({
          purchase_units: [{
            amount: {
              value: 0.01
            },
            items: [
              self.cartService.getCartRows().map(d => {
                return {
                  name: d.product.title,
                  quantity: d.amount(),
                  description: d.product.description
                }
              })
            ]
          }]
        });
      },
      onApprove: function (data, actions) {
        // Capture the funds from the transaction
        return actions.order.capture().then(function (details) {
          // Show a success message to your buyer
          alert('Transaction completed by ' + details.payer.name.given_name);
        });
      }
    }).render("#paypal-button-container");
  }
}
