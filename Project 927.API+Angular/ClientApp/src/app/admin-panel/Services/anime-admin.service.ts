import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AnimeModel } from '../Models/AnimeModel';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/Models/api.response';

@Injectable({
  providedIn: 'root'
})
export class AnimeManagerService {

  baseUrl = '/api/AnimeManager';
  constructor(private http: HttpClient) { }

  getAllAnimes() {
    return this.http.get(this.baseUrl);
  }

  removeAnime(id: number) {
    return this.http.get(this.baseUrl + `/RemoveAnime/${id}`, { headers: { 'Content-Type': 'application/json' } });
  }

  addAnime(model: AnimeModel): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(this.baseUrl, model);
  }

  editAnime(id: number, model: AnimeModel): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(this.baseUrl + '//' + id, model);
  }
}
