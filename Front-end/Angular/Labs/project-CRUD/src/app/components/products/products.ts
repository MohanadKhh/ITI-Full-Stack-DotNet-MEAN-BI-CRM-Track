import { Component, signal } from '@angular/core';
import { ProductsService } from '../../services/products-service';
import { product } from '../../utils/product';
import { Product } from "../product/product";
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-products',
  imports: [Product, RouterModule],
  templateUrl: './products.html',
  styles: ``,
})
export class Products {
  constructor(private productsService: ProductsService, private router: Router) { }
  products = signal([] as product[]);

  ngOnInit() {
    this.productsService.getProducts().subscribe({
      next: (data) => {
        this.products.set(data);
      },

      error: (err) => {
        console.error('Error fetching products:', err);
      }
    });
  }
}
