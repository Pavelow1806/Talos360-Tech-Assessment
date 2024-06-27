import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, concatMap, delay, retry, retryWhen, take, throwError } from 'rxjs';
import { Product } from 'src/app/shared/shared.types';
import { ItemsResponse } from './store.types';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';

@UntilDestroy()
@Injectable({
  providedIn: 'root'
})
export class StoreService {
  private $products: BehaviorSubject<Product[] | undefined | "error"> = new BehaviorSubject<Product[] | undefined | "error">(undefined);

  constructor(private httpClient: HttpClient) { }

  get() {
    this.httpClient.get<ItemsResponse>("api/store")
    .pipe(
      untilDestroyed(this),
      retryWhen(errors => errors.pipe(delay(1000), take(10), concatMap(throwError)))
    )
    .subscribe(response => {
      if (response && response.success) {
        this.$products.next(response.products);
      } else {
        this.$products.next("error");
      }
    });
    return this.$products.asObservable();
  }
}
