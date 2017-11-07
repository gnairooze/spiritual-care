import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/map';

import { PServiceConfig } from './p-service-config';
import { IPPersonEducation } from '../models/i-p-person-education';

@Injectable()
export class PPersonEducationService {
  private getAllUrl = this.config.BaseURL + 'P_Person_Education/GetP_Person_Educations';
  private getOneUrl = this.config.BaseURL + 'P_Person_Education/GetP_Person_Education';
  private addUrl = this.config.BaseURL + 'P_Person_Education/PostP_Person_Education';
  private updateUrl = this.config.BaseURL + 'P_Person_Education/PutP_Person_Education';
  private deleteUrl = this.config.BaseURL + 'P_Person_Education/DeleteP_Person_Education';

  constructor(private http: HttpClient, private config: PServiceConfig) { }

  getAll(): Observable<IPPersonEducation[]> {
    return this.http.get<IPPersonEducation[]>(this.getAllUrl);
  }

  getOne(id: number): Observable<IPPersonEducation> {
    return this.http.get<IPPersonEducation>(this.getOneUrl + '/' + id);
  }

  add(person: IPPersonEducation): Observable<IPPersonEducation> {
    return this.http.post(this.addUrl, person, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPPersonEducation);
  }

  update(person: IPPersonEducation): Observable<IPPersonEducation> {
    return this.http.post(this.updateUrl + '/' + person.ID, person, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPPersonEducation);
  }

  delete(id: number): Observable<IPPersonEducation> {
    return this.http.post(this.deleteUrl + '/' + id, {}, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPPersonEducation);
  }
}
