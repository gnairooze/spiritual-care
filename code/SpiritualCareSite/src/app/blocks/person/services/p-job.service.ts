import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/map';

import { PServiceConfig } from './p-service-config';
import { IPJob } from '../models/i-p-job';

@Injectable()
export class PJobService {
  private getAllUrl = this.config.BaseURL + 'P_Job/GetP_Jobs';
  private getOneUrl = this.config.BaseURL + 'P_Job/GetP_Job';
  private addUrl = this.config.BaseURL + 'P_Job/PostP_Job';
  private updateUrl = this.config.BaseURL + 'P_Job/PutP_Job';
  private deleteUrl = this.config.BaseURL + 'P_Job/DeleteP_Job';

  constructor(private http: HttpClient, private config: PServiceConfig) { }

  getAll(): Observable<IPJob[]> {
    return this.http.get<IPJob[]>(this.getAllUrl);
  }

  getOne(id: number): Observable<IPJob> {
    return this.http.get<IPJob>(this.getOneUrl + '/' + id);
  }

  add(person: IPJob): Observable<IPJob> {
    return this.http.post(this.addUrl, person, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPJob);
  }

  update(person: IPJob): Observable<IPJob> {
    return this.http.post(this.updateUrl + '/' + person.ID, person, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPJob);
  }

  delete(id: number): Observable<IPJob> {
    return this.http.post(this.deleteUrl + '/' + id, {}, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPJob);
  }
}
