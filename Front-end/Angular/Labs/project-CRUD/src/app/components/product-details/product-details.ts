import { Component, signal } from '@angular/core';
import { ActivatedRoute, RouterLink, RouterModule } from '@angular/router';
import { ProductsService } from '../../services/products-service';
import { product } from '../../utils/product';

@Component({
  selector: 'app-product-details',
  imports: [RouterModule],
  templateUrl: './product-details.html',
  styles: ``,
})
export class ProductDetails {
  productId: number = 0;
  product = signal({} as product);
  constructor(private route: ActivatedRoute, private productService: ProductsService) {
    this.productId = +this.route.snapshot.params['id'];
  }

  ngOnInit() {
    this.productService.getProductById(this.productId).subscribe({
      next: (data) => {
        this.product.set(data);
      },
      error: (err) => {
        console.error('Error fetching product details:', err);
      }
    });
  }

  deleted(productId: number) {
    this.productService.deleteById(productId).subscribe({
      next: () => {
        console.log('Product deleted successfully');
      },

      complete: () => {
        window.location.href = '/products';
      },

      error: (err) => {
        console.error('Error deleting product:', err);
      }
    });
  }
}
