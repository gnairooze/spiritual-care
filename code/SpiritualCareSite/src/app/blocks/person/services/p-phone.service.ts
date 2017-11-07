import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/map';

import { PServiceConfig } from './p-service-config';
import { IPContactWay } from '../models/i-p-contact-way';

@Injectable()
export class PPhoneService {
  private getAllUrl = this.config.BaseURL + 'P_Phone/GetP_Phones';
  private getOneUrl = this.config.BaseURL + 'P_Phone/GetP_Phone';
  private addUrl = this.config.BaseURL + 'P_Phone/PostP_Phone';
  private updateUrl = this.config.BaseURL + 'P_Phone/PutP_Phone';
  private deleteUrl = this.config.BaseURL + 'P_Phone/DeleteP_Phone';

  constructor(private http: HttpClient, private config: PServiceConfig) { }

  getAll(): Observable<IPContactWay[]> {
    return this.http.get<IPContactWay[]>(this.getAllUrl);
  }

  getOne(id: number): Observable<IPContactWay> {
    return this.http.get<IPContactWay>(this.getOneUrl + '/' + id);
  }

  add(person: IPContactWay): Observable<IPContactWay> {
    return this.http.post(this.addUrl, person, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPContactWay);
  }

  update(person: IPContactWay): Observable<IPContactWay> {
    return this.http.post(this.updateUrl + '/' + person.ID, person, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPContactWay);
  }

  delete(id: number): Observable<IPContactWay> {
    return this.http.post(this.deleteUrl + '/' + id, {}, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPContactWay);
  }
}
