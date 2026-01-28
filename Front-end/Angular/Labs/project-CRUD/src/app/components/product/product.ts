import { Component, Input, input } from '@angular/core';
import { product } from '../../utils/product';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-product',
  imports: [RouterModule],
  templateUrl: './product.html',
  styles: ``,
})
export class Product {
  @Input() product: product = {} as product;
}
