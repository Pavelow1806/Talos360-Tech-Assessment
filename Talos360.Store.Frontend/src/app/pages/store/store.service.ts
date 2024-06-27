import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Product } from 'src/app/shared/shared.types';
import { ItemsResponse } from './store.types';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';

@UntilDestroy()
@Injectable({
  providedIn: 'root'
})
export class StoreService {
  private $products: BehaviorSubject<Product[]> = new BehaviorSubject<Product[]>([]);

  constructor(private httpClient: HttpClient) { }

  get() {
    this.httpClient.get<ItemsResponse>("api/items/get")
    .pipe(untilDestroyed(this))
    .subscribe(response => {
      if (response && response.success) {
        this.$products.next(response.products);
      } else {
        // Let the user know there has been an issue
      }
    });
    return this.$products.asObservable();
  }
}
