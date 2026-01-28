import { Component, signal } from '@angular/core';
import { product } from '../../utils/product';
import { Router } from '@angular/router';
import { ProductsService } from '../../services/products-service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-product-creation',
  imports: [ReactiveFormsModule],
  templateUrl: './product-creation.html',
  styles: ``,
})
export class ProductCreation {
  colors: string[] = [];

  constructor(
    private router: Router,
    private productService: ProductsService
  ) { }

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
      Validators.pattern(
        /^(https?:\/\/.+)|(images\/[a-zA-Z0-9_-]+\.(png|jpg|jpeg|webp))$/)
    ]),
    inStock: new FormControl(false, [Validators.required])
  });

  toggleColor(event: any) {
    const color = event.target.value;
    if (event.target.checked) {
      this.colors.push(color);
    } else {
      this.colors = this.colors.filter(c => c !== color);
    }
    this.myForm.patchValue({ colors: this.colors });
  }

  createProduct() {
    if (this.myForm.valid) {
      const newProduct: Omit<product, 'id'> = {
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

      this.productService.createProduct(newProduct).subscribe({
        next: (created) => {
          // ✅ created.id is STRING
          this.router.navigate(['/products', created.id]);
        },
        error: (err) => {
          console.error('Error creating product:', err);
        }
      });
    }
  }

  cancelCreate() {
    this.router.navigate(['/products']);
  }
}
