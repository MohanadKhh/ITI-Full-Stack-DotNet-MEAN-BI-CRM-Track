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

  getProductById(id: string) {
    return this.http.get<product>(`${this.baseUrl}/${id}`);
  }

  updateById(id: string, newProduct: product) {
    return this.http.put(`${this.baseUrl}/${id}`, newProduct);
  }

  createProduct(newProduct: Omit<product, 'id'>) {
    return this.http.post<product>(this.baseUrl, newProduct);
  }


  deleteById(id: string) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}