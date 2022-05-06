import { Component, OnInit,Inject } from '@angular/core';
import { FormGroup,FormBuilder,Validators } from '@angular/forms';
import { MatDialogRef,MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ApiService } from 'src/app/services/api.service';
import { ManageEmployeeComponent } from '../manage-employee/manage-employee.component';

@Component({
  selector: 'app-employee-dialog',
  templateUrl: './employee-dialog.component.html',
  styleUrls: ['./employee-dialog.component.scss']
})
export class EmployeeDialogComponent implements OnInit {

  empForm !:FormGroup;
  actionBtn : string="Save";
  constructor(private formBuilder: FormBuilder,private api:ApiService,@Inject(MAT_DIALOG_DATA) public editData :any,private dialog:MatDialogRef<ManageEmployeeComponent>) { }

  ngOnInit(): void {
    this.empForm=this.formBuilder.group({
      name:['',Validators.required],

      email:['',Validators.required],
      price_prediction:[false],
      sell:[false],
      analyze:[false],
      manage_employees:[false],
      manage_properties:[false],
      manage_constraints:[false] 
     
    });

    //console.log(this.editData);
    if(this.editData){
      this.actionBtn="Update";
      this.empForm.controls['name'].setValue(this.editData.name);
      this.empForm.controls['email'].setValue(this.editData.email);
      this.empForm.controls['price_prediction'].setValue(this.editData.price_prediction);
      this.empForm.controls['sell'].setValue(this.editData.sell);
      this.empForm.controls['analyze'].setValue(this.editData.analyze);
      this.empForm.controls['manage_employees'].setValue(this.editData.manage_employees);
      this.empForm.controls['manage_properties'].setValue(this.editData.manage_properties);
      this.empForm.controls['manage_constraints'].setValue(this.editData.manage_constraints);
      
      
    }
  }
  addEmp(){
   if(!this.editData){
    if(this.empForm.valid){
      this.api.postEmp(this.empForm.value)
      .subscribe({
        next:(res)=>{
          alert("Employee added successfully");
          this.empForm.reset();\
          this.dialog.close("Saved");
        },
        error:()=>{
          alert("Error while adding employee");
        }
      })
    }
   }else{
     this.updateEmp();
   }
  }

  updateEmp(){
    this.api.putEmp(this.empForm.value,this.editData.id)
    .subscribe({
      next:(res)=>{
        alert("Employee updated successfully");
        this.empForm.reset();
        this.dialog.close('update');
      },
      error:()=>{
        alert("Error while updating the record");
      }
    })
  }

}
