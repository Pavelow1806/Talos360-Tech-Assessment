import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, concatMap, delay, retry, retryWhen, take, throwError } from 'rxjs';
import { Product } from 'src/app/shared/shared.types';
import { StoreResponse, StoreSupplier } from './store.types';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';

@UntilDestroy()
@Injectable({
  providedIn: 'root'
})
export class StoreService {
  private $suppliers: BehaviorSubject<StoreSupplier[] | undefined | "error"> = new BehaviorSubject<StoreSupplier[] | undefined | "error">(undefined);

  constructor(private httpClient: HttpClient) { }

  get() {
    this.httpClient.get<StoreResponse>("api/store")
    .pipe(
      untilDestroyed(this),
      retryWhen(errors => errors.pipe(delay(1000), take(10), concatMap(throwError)))
    )
    .subscribe(response => {
      if (response && response.success) {
        this.$suppliers.next(response.suppliers);
      } else {
        this.$suppliers.next("error");
      }
    });
    return this.$suppliers.asObservable();
  }
  supplier(supplierId: number) {
    var suppliers = this.$suppliers.value;
    if (suppliers && typeof(suppliers) !== "string") {
      return suppliers.find(s => s.supplierId === supplierId);
    }
    return undefined;
  }
  product(productId: number) {
    var suppliers = this.$suppliers.value;
    if (suppliers && typeof(suppliers) !== "string") {
      return suppliers.flatMap(s => s.products).find(p => p.productId === productId);
    }
    return undefined;
  }
}
