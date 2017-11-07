import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/map';

import { PServiceConfig } from './p-service-config';

import { IPPerson } from '../models/i-p-person';

@Injectable()
export class PPersonService {
  private getAllUrl = this.config.BaseURL + 'P_Person/GetP_Persons';
  private getOneUrl = this.config.BaseURL + 'P_Person/GetP_Person';
  private addUrl = this.config.BaseURL + 'P_Person/PostP_Person';
  private updateUrl = this.config.BaseURL + 'P_Person/PutP_Person';
  private deleteUrl = this.config.BaseURL + 'P_Person/DeleteP_Person';

  constructor(private http: HttpClient, private config: PServiceConfig) { }

  getAll(): Observable<IPPerson[]> {
    return this.http.get<IPPerson[]>(this.getAllUrl);
  }

  getOne(id: number): Observable<IPPerson> {
    return this.http.get<IPPerson>(this.getOneUrl + '/' + id);
  }

  add(person: IPPerson): Observable<IPPerson> {
    return this.http.post(this.addUrl, person, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPPerson);
  }

  update(person: IPPerson): Observable<IPPerson> {
    return this.http.post(this.updateUrl + '/' + person.ID, person, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPPerson);
  }

  delete(id: number): Observable<IPPerson> {
    return this.http.post(this.deleteUrl + '/' + id, {}, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPPerson);
  }
}
