import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/Models/api.response';
import { NewsModel } from '../Models/NewsModel';

@Injectable({
  providedIn: 'root'
})
export class NewsManagerService {

  baseUrl = 'api/ManagerController';
  constructor(private http: HttpClient) { }

  getAllNews() {
    return this.http.get(this.baseUrl);
  }

  removeNews(id: number) {
    return this.http.post(this.baseUrl + '/RemoveNews/' + id, id, { headers: { 'Content-Type': 'application/json' } });
  }

  addNews(model: NewsModel): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(this.baseUrl, model);
  }

  editNews(id: number, model: NewsModel): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(this.baseUrl + '/editNews/' + id, model);
  }
}
