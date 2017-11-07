import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/map';

import { PServiceConfig } from './p-service-config';
import { IPPersonJob } from '../models/i-p-person-job';

@Injectable()
export class PPersonJobService {
  private getAllUrl = this.config.BaseURL + 'P_Person_Job/GetP_Person_Jobs';
  private getOneUrl = this.config.BaseURL + 'P_Person_Job/GetP_Person_Job';
  private addUrl = this.config.BaseURL + 'P_Person_Job/PostP_Person_Job';
  private updateUrl = this.config.BaseURL + 'P_Person_Job/PutP_Person_Job';
  private deleteUrl = this.config.BaseURL + 'P_Person_Job/DeleteP_Person_Job';

  constructor(private http: HttpClient, private config: PServiceConfig) { }

  getAll(): Observable<IPPersonJob[]> {
    return this.http.get<IPPersonJob[]>(this.getAllUrl);
  }

  getOne(id: number): Observable<IPPersonJob> {
    return this.http.get<IPPersonJob>(this.getOneUrl + '/' + id);
  }

  add(person: IPPersonJob): Observable<IPPersonJob> {
    return this.http.post(this.addUrl, person, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPPersonJob);
  }

  update(person: IPPersonJob): Observable<IPPersonJob> {
    return this.http.post(this.updateUrl + '/' + person.ID, person, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPPersonJob);
  }

  delete(id: number): Observable<IPPersonJob> {
    return this.http.post(this.deleteUrl + '/' + id, {}, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPPersonJob);
  }
}
