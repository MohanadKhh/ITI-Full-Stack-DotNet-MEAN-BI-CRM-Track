import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { product } from '../utils/product';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  private readonly baseUrl: string = 'http://localhost:3000/products';
  constructor(private http: HttpClient) { }

  getProducts() {
    return this.http.get<product[]>(this.baseUrl);
  }

  getProductById(id: number) {
    return this.http.get<product>(`${this.baseUrl}/${id}`);
  }

  updateById(id: number, newProduct: product) {
    return this.http.put(`${this.baseUrl}/${id}`, newProduct);
  }

  createProduct(newProduct: product) {
    return this.http.post(this.baseUrl, newProduct);
  }

  deleteById(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}