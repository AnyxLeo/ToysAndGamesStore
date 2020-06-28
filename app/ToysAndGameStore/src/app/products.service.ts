import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  private apiURL = 'https://localhost:44318/api/game';

  constructor(private http: HttpClient) {
  }

  getAllItems() {
    return this.http.get(`${this.apiURL}/all`);
  }

  getItemById(id: string) {
    return this.http.get(`${this.apiURL}/${id}`);
  }

  createItem(item: any) {
    return this.http.post(`${this.apiURL}`, item);
  }

  updateItem(item: any) {
    return this.http.put(`${this.apiURL}`, item);
  }

  deleteItem(id: string) {
    return this.http.delete(`${this.apiURL}/${id}`);
  }
}
