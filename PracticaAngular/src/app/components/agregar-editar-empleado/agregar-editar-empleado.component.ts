import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, ActivatedRoute } from '@angular/router';
import { Empleado } from '../../interfaces/empleado';
import { EmpleadoService } from '../../services/empleado.service';





@Component({
  selector: 'app-agregar-editar-empleado',
  templateUrl: './agregar-editar-empleado.component.html',
  styleUrls: ['./agregar-editar-empleado.component.css']
})
export class AgregarEditarEmpleadoComponent implements OnInit {
  loading: boolean = false;
  form: FormGroup;
  id: number;
  operacion: string = 'Agregar';

  constructor(private fb: FormBuilder,
    private _empleadoService: EmpleadoService,
    private _snackBar: MatSnackBar,
    private router: Router,
    private aRoute: ActivatedRoute) {
    this.form = this.fb.group({
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      ciudad: ['', Validators.required],
      pais: ['', Validators.required],

    })
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
   }

  ngOnInit(): void {

    if(this.id != 0){
      this.operacion = 'Editar';
      this.obtenerEmpleado(this.id)
    }


      
   


  }

  obtenerEmpleado(id: number){
    this.loading = true;
    this._empleadoService.getEmpleado(id).subscribe(data =>{
      this.form.patchValue({
        nombre: data.FirstName,
        apellido: data.LastName,
        ciudad: data.City,
        pais: data.Country

      });
      this.loading = false;
    });
  }

  agregarEditarEmpleado(){

    const empleado: Empleado = {
      FirstName: this.form.value.nombre,
      LastName: this.form.value.apellido,
      City: this.form.value.ciudad,
      Country: this.form.value.pais
    }   

    if (this.id != 0){
      empleado.EmployeeId = this.id;
      this.editarEmpleado(this.id, empleado);

    }else{
      this.agregarEmpleado(empleado)
    }
  }

  editarEmpleado(id: number, empleado: Empleado){
    this.loading = true;
    this._empleadoService.updateEmpleado(id, empleado).subscribe(() =>{
      this.loading = false;
      this.mensajeExito('actualizado');
      this.router.navigate(['/listEmpleados']);
    })
  }

  agregarEmpleado(empleado: Empleado){
    this._empleadoService.addEmpleado(empleado).subscribe(data =>{
      this.mensajeExito('registrado');
      this.router.navigate(['/listEmpleados']);
    })
  }

  mensajeExito(text: string){
    this._snackBar.open(`El empleado fue ${text} con exito`, '',{
      duration: 3000,
      horizontalPosition: 'right',
      verticalPosition: 'top'
    });
  }

}
