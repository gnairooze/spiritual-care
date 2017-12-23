import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/map';

import { PServiceConfig } from './p-service-config';
import { IPPersonMeeting } from '../models/i-p-person-meeting';

@Injectable()
export class PPersonExpectedMeetingService {
  private getAllUrl = this.config.BaseURL + 'P_Person_Expected_Meeting/GetP_Person_Expected_Meetings';
  private getOneUrl = this.config.BaseURL + 'P_Person_Expected_Meeting/GetP_Person_Expected_Meeting';
  private addUrl = this.config.BaseURL + 'P_Person_Expected_Meeting/PostP_Person_Expected_Meeting';
  private updateUrl = this.config.BaseURL + 'P_Person_Expected_Meeting/PutP_Person_Expected_Meeting';
  private deleteUrl = this.config.BaseURL + 'P_Person_Expected_Meeting/DeleteP_Person_Expected_Meeting';

  constructor(private http: HttpClient, private config: PServiceConfig) { }

  getAll(): Observable<IPPersonMeeting[]> {
    return this.http.get<IPPersonMeeting[]>(this.getAllUrl);
  }

  getOne(id: number): Observable<IPPersonMeeting> {
    return this.http.get<IPPersonMeeting>(this.getOneUrl + '/' + id);
  }

  add(person: IPPersonMeeting): Observable<IPPersonMeeting> {
    return this.http.post(this.addUrl, person, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPPersonMeeting);
  }

  update(person: IPPersonMeeting): Observable<IPPersonMeeting> {
    return this.http.post(this.updateUrl + '/' + person.ID, person, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPPersonMeeting);
  }

  delete(id: number): Observable<IPPersonMeeting> {
    return this.http.post(this.deleteUrl + '/' + id, {}, {
      headers: new HttpHeaders().set('content-type', 'application/json'),
    }).map(o => o as IPPersonMeeting);
  }
}