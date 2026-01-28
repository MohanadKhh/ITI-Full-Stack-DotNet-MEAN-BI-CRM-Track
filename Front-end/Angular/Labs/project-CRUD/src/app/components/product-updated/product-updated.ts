import { Component, signal } from '@angular/core';
import { product } from '../../utils/product';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductsService } from '../../services/products-service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-product-updated',
  imports: [ReactiveFormsModule],
  templateUrl: './product-updated.html',
  styles: ``,
})
export class ProductUpdated {

  // ✅ ID is STRING
  productId!: string;

  product = signal({} as product);
  colors: string[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private productService: ProductsService
  ) {
    // ✅ DO NOT convert
    this.productId = this.route.snapshot.paramMap.get('id')!;
  }

  myForm = new FormGroup({
    name: new FormControl("", [Validators.required, Validators.minLength(2)]),
    description: new FormControl("", [Validators.required, Validators.minLength(2)]),
    category: new FormControl("", [Validators.required, Validators.minLength(2)]),
    brand: new FormControl("", [Validators.required, Validators.minLength(2)]),
    colors: new FormControl<string[]>([], [Validators.required]),
    price: new FormControl(0, [Validators.required, Validators.min(1)]),
    rating: new FormControl(0, [Validators.required, Validators.min(0), Validators.max(5)]),
    image: new FormControl("", [
      Validators.required,
      Validators.pattern(/^(https?:\/\/.+)|(images\/[a-zA-Z0-9_-]+\.(png|jpg|jpeg|webp))$/)]),
    inStock: new FormControl(false, [Validators.required])
  });

  ngOnInit() {
    this.productService.getProductById(this.productId).subscribe({
      next: (data) => {
        this.product.set(data);

        this.myForm.patchValue({
          name: data.name,
          description: data.description,
          category: data.category,
          brand: data.brand,
          colors: data.colors,
          price: data.price,
          rating: data.rating,
          image: data.image,
          inStock: data.inStock
        });

        this.colors = data.colors ?? [];
      },
      error: (err) => {
        console.error('Error fetching product details:', err);
      }
    });
  }

  toggleColor(event: any) {
    const color = event.target.value;

    if (event.target.checked) {
      this.colors.push(color);
    } else {
      this.colors = this.colors.filter(c => c !== color);
    }

    this.myForm.patchValue({ colors: this.colors });
  }

  updateProduct() {
    if (this.myForm.valid) {
      const updatedProduct: product = {
        id: this.productId, // ✅ string id
        name: this.myForm.value.name!,
        description: this.myForm.value.description!,
        category: this.myForm.value.category!,
        brand: this.myForm.value.brand!,
        colors: this.myForm.value.colors!,
        price: +this.myForm.value.price!,
        rating: +this.myForm.value.rating!,
        image: this.myForm.value.image!,
        inStock: !!this.myForm.value.inStock,
      };

      this.productService.updateById(this.productId, updatedProduct).subscribe({
        next: () => {
          console.log('Product updated successfully');
          this.router.navigate(['/products', this.productId]);
        },
        error: (err) => {
          console.error('Error updating product:', err);
        }
      });
    }
  }

  cancelUpdate() {
    this.router.navigate(['/products', this.productId]);
  }
}
