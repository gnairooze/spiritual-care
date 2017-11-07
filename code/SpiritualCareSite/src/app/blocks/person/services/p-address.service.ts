import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/map';

import { PServiceConfig } from './p-service-config';
import { IPAddress } from '../models/i-p-address';

@Injectable()
export class PAddressService {
  private getAllUrl = this.config.BaseURL + 'P_Address/GetP_Addresses';
  private getOneUrl = this.config.BaseURL + 'P_Address/GetP_Address';
  private addUrl = this.config.BaseURL + 'P_Address/PostP_Address';
  private updateUrl = this.config.BaseURL + 'P_Address/PutP_Address';
  private deleteUrl = this.config.BaseURL + 'P_Address/DeleteP_Address';

  constructor(private http: HttpClient, private config: PServiceConfig) { }

  getAll(): Observable<IPAddress[]> {
    return this.http.get<IPAddress[]>(this.getAllUrl);
  }

  getOne(id: number): Observable<IPAddress> {
    return this.http.get<IPAddress>(this.getOneUrl + '/' + id);
  }

  add(person: IPAddress): Observable<IPAddress> {
    return this.http.post(this.addUrl, person, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPAddress);
  }

  update(person: IPAddress): Observable<IPAddress> {
    return this.http.post(this.updateUrl + '/' + person.ID, person, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPAddress);
  }

  delete(id: number): Observable<IPAddress> {
    return this.http.post(this.deleteUrl + '/' + id, {}, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPAddress);
  }
}
