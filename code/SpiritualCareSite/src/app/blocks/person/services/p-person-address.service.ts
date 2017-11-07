import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/map';

import { PServiceConfig } from './p-service-config';
import { IPPersonAddress } from '../models/i-p-person-address';

@Injectable()
export class PPersonAddressService {
  private getAllUrl = this.config.BaseURL + 'P_Person_Address/GetP_Person_Addresss';
  private getOneUrl = this.config.BaseURL + 'P_Person_Address/GetP_Person_Address';
  private addUrl = this.config.BaseURL + 'P_Person_Address/PostP_Person_Address';
  private updateUrl = this.config.BaseURL + 'P_Person_Address/PutP_Person_Address';
  private deleteUrl = this.config.BaseURL + 'P_Person_Address/DeleteP_Person_Address';

  constructor(private http: HttpClient, private config: PServiceConfig) { }

  getAll(): Observable<IPPersonAddress[]> {
    return this.http.get<IPPersonAddress[]>(this.getAllUrl);
  }

  getOne(id: number): Observable<IPPersonAddress> {
    return this.http.get<IPPersonAddress>(this.getOneUrl + '/' + id);
  }

  add(person: IPPersonAddress): Observable<IPPersonAddress> {
    return this.http.post(this.addUrl, person, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPPersonAddress);
  }

  update(person: IPPersonAddress): Observable<IPPersonAddress> {
    return this.http.post(this.updateUrl + '/' + person.ID, person, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPPersonAddress);
  }

  delete(id: number): Observable<IPPersonAddress> {
    return this.http.post(this.deleteUrl + '/' + id, {}, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPPersonAddress);
  }
}
