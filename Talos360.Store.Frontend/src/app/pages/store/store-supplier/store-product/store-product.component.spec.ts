import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoreProductComponent } from './store-product.component';

describe('ItemComponent', () => {
  let component: StoreProductComponent;
  let fixture: ComponentFixture<StoreProductComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StoreProductComponent]
    });
    fixture = TestBed.createComponent(StoreProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
