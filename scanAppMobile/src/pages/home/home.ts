import { Component } from '@angular/core';

import { NavController } from 'ionic-angular';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  productCode: string;
  showAdd: boolean;
  product: Product;
  constructor(public navCtrl: NavController, private productService: ProductService) {

  }

  showAddForm() {
    this.showAdd = true;
  }
  cancel() {
    this.showAdd = false;
  }

  search() {
    this.productService.searchByProductCode(this.productCode)
      .subscribe(p => {
        this.product = p
        console.log(p);
      }, e => { }, () => { });
  }

}
