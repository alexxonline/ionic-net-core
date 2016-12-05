import { Component } from '@angular/core';

import { NavController } from 'ionic-angular';
import { Storage } from '@ionic/storage';

@Component({
  selector: 'page-contact',
  templateUrl: 'contact.html'
})
export class ContactPage {
  serverUrl: string = "http://default";
  constructor(public navCtrl: NavController, private storage: Storage) {
    
  }

  save() {
    this.storage.set('server-url', this.serverUrl);
  }

  ionViewDidEnter() {
      this.storage.get('server-url').then((val) => {
       this.serverUrl = val;
     });
  }

}
