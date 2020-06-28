import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductGridComponent } from './product-grid/product-grid.component';
import { ProductFormComponent } from './product-form/product-form.component';


const routes: Routes = [
  { path: '', component: ProductGridComponent},
  { path: 'home', component: ProductGridComponent},
  { path: 'products/:id', component: ProductFormComponent},
  { path: 'products', component: ProductFormComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
