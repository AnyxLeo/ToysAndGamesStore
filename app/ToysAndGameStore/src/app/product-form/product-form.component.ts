import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../products.service';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.sass'],
})
export class ProductFormComponent implements OnInit {
  Id;
  productForm;
  showSucces;
  showError;
  error;

  private formInitialValue = {
    Id: [0],
    Name: ['', [Validators.required]],
    Description: ['', [Validators.maxLength(100)]],
    AgeRestriction: ['', [Validators.min(0), Validators.max(0)]],
    Company: ['', [Validators.required, Validators.maxLength(50)]],
    Price: ['', [Validators.required, Validators.min(0), Validators.max(1000)]],
  };
  constructor(
    private route: ActivatedRoute,
    private service: ProductsService,
    private formBuilder: FormBuilder
  ) {
    this.productForm = this.formBuilder.group(this.formInitialValue);
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.Id = params.get('id');
      if (this.Id) {
        this.service.getItemById(this.Id).subscribe(
          (data: any) => {
            this.productForm.patchValue({...data});
          },
          (error: any) => {
            this.showError = true;
            this.error = error.error.title;
          }
        );
      }
    });
  }

  get productFormControl() {
    console.log(this.productForm);
    return this.productForm.controls;
  }

  onSubmit(product) {
    if (product.Id === 0) {
      this.service.createItem(product).subscribe(
        () => {
          this.showSucces = true;
          this.productForm.patchValue({...this.formInitialValue});
        },
        (error: any) => {
          this.error = error.error.title;
          this.showError = true;
        }
      );
    } else {
      this.service.updateItem(product).subscribe(
        () => (this.showSucces = true),
        (error: any) => {
          this.showError = true;
          this.error = error.error.title
        }
      );
    }
  }
  
  onCloseErrorAlert() {
    this.showError = false;
  }
  onCloseSuccesAlert() {
    this.showSucces = false;
  }
}
