import { Product } from './../models/product';
import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-catalog-item',
  template: `
    <mat-card>
      <mat-card-header> </mat-card-header>
      <img md-card-image [src]="'assets/img/' + product.imageUrl" alt="Photo of a product" />
      <mat-card-content>
        <p>
          <a (click)="productDetails.emit(product)">{{ product.title }}</a>
        </p>
      </mat-card-content>
      <mat-card-actions>
        <button mat-button (click)="addToCart.emit(product)">
          <i class="material-icons">add_shopping_cart</i>
        </button>
        <button mat-button (click)="productDetails.emit(product)">
          <i class="material-icons">search</i>
        </button>
      </mat-card-actions>
    </mat-card>
  `,
  styles: [
    `
      mat-card {
        flex: 1 1 25%;
      }
      @media only screen and (max-width: 768px) {
        mat-card {
          margin: 15px 0 !important;
        }
      }
      mat-card:hover {
        box-shadow: 3px 3px 16px -2px rgba(0, 0, 0, 0.5);
      }
      mat-card-title {
        margin-right: 10px;
      }
      mat-card-title-group {
        margin: 0;
      }
      a {
        color: inherit;
        text-decoration: none;
        cursor: pointer;
      }
      img {
        max-width: 160px;
        min-height: 160px
      }
      mat-card-content {
        margin-top: 15px;
        margin: 0px 0 0;
      }
      span {
        display: inline-block;
        font-size: 13px;
      }
      mat-card-footer {
        padding: 0 5px 5px;
      }

      mat-card-actions {
        margin-top: 10px;
      }
    `
  ]
})
export class CatalogItemComponent implements OnInit {
  @Input() product: Product;

  @Output() addToCart: EventEmitter<any> = new EventEmitter();
  @Output() productDetails: EventEmitter<any> = new EventEmitter();

  constructor() {}

  ngOnInit() {}
}
