import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Empleado } from '../interfaces/empleado';

@Injectable({
  providedIn: 'root'
})
export class EmpleadoService {
  private myAppUrl: string = environment.endpoint;
  private myApiUrl: string = 'api/Employees/';

  constructor(private http: HttpClient) { }

  getEmpleados(): Observable<Empleado[]> {
    return this.http.get<Empleado[]>(`${this.myAppUrl}${this.myApiUrl}`);
  }

  getEmpleado(id: number): Observable<Empleado>{
    return this.http.get<Empleado>(`${this.myAppUrl}${this.myApiUrl}${id}`);
  }

  deleteEmpleado(id: number): Observable<void>{
    return this.http.delete<void>(`${this.myAppUrl}${this.myApiUrl}${id}`)
  }

  addEmpleado(empleado: Empleado): Observable<Empleado>{
   return this.http.post<Empleado>(`${this.myAppUrl}${this.myApiUrl}`, empleado)
  }

  updateEmpleado(id: number, empleado: Empleado): Observable<void>{
    return this.http.put<void>(`${this.myAppUrl}${this.myApiUrl}${id}`, empleado);

  }
}
