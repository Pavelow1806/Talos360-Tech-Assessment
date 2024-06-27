import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { BehaviorSubject } from 'rxjs';
import { BasketItem, BasketResponse, AddToBasketResponse, RemoveFromBasketResponse, ClearBasketResponse } from './basket.types';

@UntilDestroy()
@Injectable({
  providedIn: 'root'
})
export class BasketService {
  private $basket: BehaviorSubject<BasketItem[]> = new BehaviorSubject<BasketItem[]>([]);

  constructor(private httpClient: HttpClient) { }

  get() {
    this.httpClient.get<BasketResponse>("api/basket/get")
    .pipe(untilDestroyed(this))
    .subscribe(response => {
      if (response && response.success) {
        this.$basket.next(response.basketItems);
      } else {
        // Let the user know there has been an issue
      }
    });
    return this.$basket.asObservable();
  }
  add(productId: number) {
    return this.httpClient.post<AddToBasketResponse>("api/basket/add", {productId});
  }
  remove(basketItemId: string) {
    return this.httpClient.post<RemoveFromBasketResponse>("api/basket/remove", {basketItemId});
  }
  clear() {
    return this.httpClient.get<ClearBasketResponse>("api/basket/clear");
  }
}
