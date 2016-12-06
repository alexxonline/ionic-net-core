import { Component } from '@angular/core';

import { NavController } from 'ionic-angular';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
import { BarcodeScanner } from 'ionic-native';


@Component({
  selector: 'page-about',
  templateUrl: 'about.html'
})
export class AboutPage {
  productCode: string;
  product: Product;
  barCode: string;
  
  constructor(public navCtrl: NavController, private productService:ProductService) {
 
  }

  search() {
    this.productService.searchByProductCode(this.productCode)
      .subscribe(p => {
        if(p != null){
          this.productCode = "";
          this.product = p;  
        }
      }, e => { }, () => { });
  }

  useBarCode() {
    BarcodeScanner.scan().then((barcodeData) => {
      this.barCode = JSON.stringify(barcodeData);
    });
  }

}
