import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Storage } from '@ionic/storage';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'
import { Product } from '../models/product';


@Injectable()
export class ProductService {
    serverUrl : string
    constructor(private http: Http, private storage : Storage) {
        storage.get('server-url').then(res => this.serverUrl = res);
        //this.serverUrl = "http://localhost:8100";
    }

    searchByProductCode(productCode: string) {
        return this.http.get(`${this.serverUrl}/api/products/${productCode}`)
            .map((r: Response) => {
                return r.json() as Product;});
    }
}