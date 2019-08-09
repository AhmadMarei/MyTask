import { environment } from './../../environments/environment';
import { RoomData } from './../_models/roomData';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class RoomService {
  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

  getRoomsInfo(id): Observable<RoomData[]> {
    return this.http.get<RoomData[]>(this.baseUrl + '/home/' + id + '/data');

  }

}
