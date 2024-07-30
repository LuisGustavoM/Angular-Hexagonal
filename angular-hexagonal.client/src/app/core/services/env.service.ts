import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EnvService {
  private urlApi = signal<string>('');

  public setUrlApi() {
    const sla = (window as any).__env.urlApi;
    this.urlApi.set(sla);
  }

  public getUrlApi(): string {
    var response = this.urlApi(); 
    return response;
  }

}
