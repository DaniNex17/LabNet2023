import { Component, OnInit } from '@angular/core';
import { EmpleadoService } from '../../services/empleado.service';
import { ActivatedRoute } from '@angular/router';
import { Empleado } from '../../interfaces/empleado';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-ver-empleado',
  templateUrl: './ver-empleado.component.html',
  styleUrls: ['./ver-empleado.component.css'],
})
export class VerEmpleadoComponent implements OnInit {
id: number;
empleado!: Empleado;
loading: boolean = false;



  constructor(
    private _empleadoService: EmpleadoService,
    private aRoute: ActivatedRoute
  ) {
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
    
  }

  ngOnInit(): void {
    this.obtenerEmpleado();
  }

  obtenerEmpleado() {
    this.loading = true;
    this._empleadoService.getEmpleado(this.id).subscribe(data => {
      this.empleado = data;
      this.loading = false;
    });
  }
}
