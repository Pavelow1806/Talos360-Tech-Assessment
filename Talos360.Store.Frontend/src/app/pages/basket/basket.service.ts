import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { BasketItem, BasketResponse, AddToBasketResponse, RemoveFromBasketResponse, ClearBasketResponse, AddToBasketRequest } from './basket.types';

@UntilDestroy()
@Injectable({
  providedIn: 'root'
})
export class BasketService {
  private $basket: BehaviorSubject<BasketItem[]> = new BehaviorSubject<BasketItem[]>([]);
  get basket(): Observable<BasketItem[]> {
    return this.$basket.asObservable();
  }

  constructor(private httpClient: HttpClient) { }

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
          this.$basket.next([...this.$basket.value, response.item]);
        }
      })
    )
    return observable;
  }
  remove(basketItemId: string) {
    var observable = this.httpClient.post<RemoveFromBasketResponse>("api/basket/remove", {basketItemId})
    
    return observable;
  }
  clear() {
    return this.httpClient.get<ClearBasketResponse>("api/basket/clear");
  }
}
