import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { BasketResponse, AddToBasketResponse, RemoveFromBasketResponse, ClearBasketResponse, AddToBasketRequest, GroupedBasketItem, RemoveFromBasketRequest, DispatchDateResponse, EstimateDispatchDateRequest } from './basket.types';
import { StoreService } from '../store/store.service';

@UntilDestroy()
@Injectable({
  providedIn: 'root'
})
export class BasketService {
  private $basket: BehaviorSubject<GroupedBasketItem[]> = new BehaviorSubject<GroupedBasketItem[]>([]);
  get basket(): Observable<GroupedBasketItem[]> {
    return this.$basket.asObservable();
  }

  constructor(private httpClient: HttpClient, private storeService: StoreService) { }

  get() {
    this.httpClient.get<BasketResponse>("api/basket/get")
    .pipe(untilDestroyed(this))
    .subscribe(response => {
      if (response && response.success) {
        this.$basket.next(response.basketItems);
      }
    });
    return this.$basket.asObservable();
  }
  add(request: AddToBasketRequest) {
    var observable = this.httpClient.post<AddToBasketResponse>("api/basket/add", request)
    .pipe(
      untilDestroyed(this),
      tap(response => {
        if (response && response.success) {
          const basket = this.$basket.value;
          const group = basket.find(g => g.productId === request.productId);
          if (group) {
            group.quantity = group.quantity + 1;
          } else {
            const product = this.storeService.product(request.productId);
            if (product) {
              basket.push({...product, quantity: 1});
            }
          }
          this.$basket.next(basket);
        }
      })
    )
    return observable;
  }
  remove(request: RemoveFromBasketRequest) {
    var observable = this.httpClient.post<RemoveFromBasketResponse>("api/basket/remove", request)
    .pipe(
      untilDestroyed(this),
      tap(response => {
        if (response && response.success) {
          var basket = this.$basket.value;
          const group = basket.find(g => g.productId === request.productId);
          if (group) {
            if (group.quantity > 1)
              group.quantity--;
            else
              basket = basket.filter(g => g.productId !== request.productId);
            this.$basket.next(basket);
          }
        }
      })
    )
    return observable;
  }
  clear() {
    return this.httpClient.get<ClearBasketResponse>("api/basket/clear");
  }
  calculateEstimatedDeliveryDate(request: EstimateDispatchDateRequest) {
    return this.httpClient.post<DispatchDateResponse>("api/dispatchdate", request)
  }
}
