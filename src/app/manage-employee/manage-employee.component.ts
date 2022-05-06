import { Component, OnInit ,ViewChild} from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { EmployeeDialogComponent } from '../employee-dialog/employee-dialog.component'; 
import { ApiService } from 'src/app/services/api.service';
import {MatPaginator} from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';


@Component({
  selector: 'app-manage-employee',
  templateUrl: './manage-employee.component.html',
  styleUrls: ['./manage-employee.component.scss']
})
export class ManageEmployeeComponent implements OnInit {

  displayedColumns: string[] = [ 'name', 'email', 'price','sell','manageEmp','manageConst','analyze','action'];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private dialog:MatDialog,private api:ApiService) { }

  ngOnInit(): void {
    this.getAllEmp();
  }
  openDialog(){
    this.dialog.open(EmployeeDialogComponent,{
      width: '30%'
    }).afterClosed().subscribe(val=>{
      if(val === 'Saved'){
        this.getAllEmp();
      }
    })
  }
  //console.log(this.api.getEmp);
  getAllEmp(){
    this.api.getEmp()
    .subscribe({
      next:(res)=>{
        this.dataSource=new MatTableDataSource(res);
        this.dataSource.paginator=this.paginator;
        this.dataSource.sort=this.sort;
      },
      error:(err)=>{
        alert("Error while fetching the data!!")
      }
    })
  }
  editEmp(row:any){
    this.dialog.open(EmployeeDialogComponent,{
      width:'30%',
      data:row
    }).afterClosed().subscribe(val=>{
      if(val==='update'){
        this.getAllEmp();
      }
    })
  }
  deleteEmp(id:number){
    this.api.deleteEmp(id)
    .subscribe({
      next:(res)=>{
        alert("Employee deleted Successfully")
        this.getAllEmp();
      },
      error:()=>{
        alert("Error while deleting the record")
      }
    })
  }
  
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}

