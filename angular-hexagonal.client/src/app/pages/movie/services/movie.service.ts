import { inject, Injectable } from '@angular/core';
import { EnvService } from '../../../core/services/env.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Movie } from '../models/movie';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  private urlApi = ''; 
  private envService = inject(EnvService);

  constructor(private http: HttpClient) {
    this.urlApi = this.envService.getUrlApi() + 'movie';
   }

   public getMovieList(): Observable<Movie[]> {
    return this.http.get<Movie[]>(this.urlApi);
   }
}

