import { Component, Input, OnInit } from '@angular/core';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { BasketService } from 'src/app/pages/basket/basket.service';
import { Product } from 'src/app/shared/shared.types';

@UntilDestroy()
@Component({
  selector: 'app-store-product',
  templateUrl: './store-product.component.html',
  styleUrls: ['./store-product.component.scss']
})
export class StoreProductComponent implements OnInit {
  @Input("product") product!: Product;
  added = false;
  currentItemCount = 0;

  constructor(private basketService: BasketService) {}

  ngOnInit(): void {
    this.basketService.basket
    .pipe(untilDestroyed(this))
    .subscribe(basket => {
      this.currentItemCount = basket.filter(i => i.productId === this.product.productId).length
    });
  }

  addToBasket() {
    this.basketService.add({
      productId: this.product.productId
    })
    .pipe(untilDestroyed(this))
    .subscribe(response => {
      if (response && response.success) {
        this.added = true;
        setTimeout(() => {
          this.added = false;
        }, 1000);
      }
    });
    
  }
}
