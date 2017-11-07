import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/map';

import { PServiceConfig } from './p-service-config';
import { IPPersonPerson } from '../models/i-p-person-person';

@Injectable()
export class PPersonPersonService {
  private getAllUrl = this.config.BaseURL + 'P_Person_Person/GetP_Person_Persons';
  private getOneUrl = this.config.BaseURL + 'P_Person_Person/GetP_Person_Person';
  private addUrl = this.config.BaseURL + 'P_Person_Person/PostP_Person_Person';
  private updateUrl = this.config.BaseURL + 'P_Person_Person/PutP_Person_Person';
  private deleteUrl = this.config.BaseURL + 'P_Person_Person/DeleteP_Person_Person';

  constructor(private http: HttpClient, private config: PServiceConfig) { }

  getAll(): Observable<IPPersonPerson[]> {
    return this.http.get<IPPersonPerson[]>(this.getAllUrl);
  }

  getOne(id: number): Observable<IPPersonPerson> {
    return this.http.get<IPPersonPerson>(this.getOneUrl + '/' + id);
  }

  add(person: IPPersonPerson): Observable<IPPersonPerson> {
    return this.http.post(this.addUrl, person, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPPersonPerson);
  }

  update(person: IPPersonPerson): Observable<IPPersonPerson> {
    return this.http.post(this.updateUrl + '/' + person.ID, person, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPPersonPerson);
  }

  delete(id: number): Observable<IPPersonPerson> {
    return this.http.post(this.deleteUrl + '/' + id, {}, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPPersonPerson);
  }
}
