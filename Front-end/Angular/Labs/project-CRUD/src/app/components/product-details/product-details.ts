import { Component, signal } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { ProductsService } from '../../services/products-service';
import { product } from '../../utils/product';

@Component({
  selector: 'app-product-details',
  imports: [RouterModule],
  templateUrl: './product-details.html',
  styles: ``,
})
export class ProductDetails {

  productId!: string;
  product = signal({} as product);

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private productService: ProductsService
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');

    if (!id) {
      console.error('Invalid product id');
      return;
    }

    this.productId = id;

    this.productService.getProductById(this.productId).subscribe({
      next: (data) => {
        this.product.set(data);
      },
      error: (err) => {
        console.error('Error fetching product:', err);
      }
    });
  }

  deleteProduct() {
    this.productService.deleteById(this.productId).subscribe({
      next: () => {
        console.log('Product deleted successfully');
        this.router.navigate(['/products']);
      },
      error: (err) => {
        console.error('Error deleting product:', err);
      }
    });
  }
}
