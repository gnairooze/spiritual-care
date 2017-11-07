import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/map';

import { PServiceConfig } from './p-service-config';
import { IPContactWay } from '../models/i-p-contact-way';

@Injectable()
export class PContactWay1Service {
  private getAllUrl = this.config.BaseURL + 'P_ContactWay1/GetP_ContactWay1';
  private getOneUrl = this.config.BaseURL + 'P_ContactWay1/GetP_ContactWay1';
  private addUrl = this.config.BaseURL + 'P_ContactWay1/PostP_ContactWay1';
  private updateUrl = this.config.BaseURL + 'P_ContactWay1/PutP_ContactWay1';
  private deleteUrl = this.config.BaseURL + 'P_ContactWay1/DeleteP_ContactWay1';

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
