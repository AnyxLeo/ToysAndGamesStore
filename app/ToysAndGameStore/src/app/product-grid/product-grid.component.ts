import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../products.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-grid',
  templateUrl: './product-grid.component.html',
  styleUrls: ['./product-grid.component.sass'],
})
export class ProductGridComponent implements OnInit {
  items: [];
  error;
  showError;
  isLoading: boolean = false;
  mySubscription: any;
  constructor(
    protected service: ProductsService,
    protected router: Router  
  ) {
    }

  ngOnInit(): void {
    this.onGetAllItems();
  }

  onGetAllItems() {
    this.service.getAllItems().subscribe(
      (data: any) => (this.items = data),
      (error: any) => console.error('Ups! Something went wrong', error)
    );
  }

  onDelete(id) {
    this.isLoading = true;
    this.items = [];
    this.service.deleteItem(id).subscribe(
      () => {
        setTimeout(() => { 
          this.onGetAllItems();         
          this.isLoading = false;
        }, 2000);
      },
      (error: any) => {
        this.showError = true;
        this.error = error.error.title;
        this.isLoading = false;
      }
    );
  }

  onCloseErrorAlert() {
    this.showError = false;
  }
}
