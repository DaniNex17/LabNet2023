import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Empleado } from '../../interfaces/empleado';
import { EmpleadoService } from '../../services/empleado.service';


@Component({
  selector: 'app-listado-empleado',
  templateUrl: './listado-empleado.component.html',
  styleUrls: ['./listado-empleado.component.css']
})
export class ListadoEmpleadoComponent implements OnInit, AfterViewInit  {
  displayedColumns: string[] = ['FirstName', 'LastName', 'City', 'Country', 'acciones'];
  dataSource = new MatTableDataSource<Empleado>();
  loading: boolean = false;
  
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private _snackBar: MatSnackBar, private _empleadoService:EmpleadoService) { }

  ngOnInit(): void {
    this.obtenerEmpleados();
  }

  ngAfterViewInit(){
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    if(this.dataSource.data.length > 0){
      this.paginator._intl.itemsPerPageLabel = 'Items Por Pagina'
    }
    
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  obtenerEmpleados(){
    this.loading = true;
    this._empleadoService.getEmpleados().subscribe(data =>{
      this.loading = false;
      this.dataSource.data = data;
    }, error => {
      this.loading = false;
      alert('¡Houston!, Tenemos un error')
    })
  }

  eliminarEmpleado(id: number){ 
    this.loading = true;

    this._empleadoService.deleteEmpleado(id).subscribe(() => {
      this.mensajeExito();
      this.loading = false;
      this.obtenerEmpleados();
    });
  
  }

  mensajeExito(){
    this._snackBar.open('El empleado fue eliminado con exito', '',{
      duration: 3000,
      horizontalPosition: 'right',
      verticalPosition: 'top'
    });
  }

}
