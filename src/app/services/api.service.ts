import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ApiService {

  readonly APIUrl = "http://127.0.0.1:8000";
  readonly PhotoUrl = "http://127.0.0.1:8000/media/";

  constructor(private http:HttpClient) { }
  
  postEmp(data :any){
    return this.http.post<any>("http://127.0.0.1:8000/EdenManageProperty/employee/",data);
  }
  getEmp(){
    return this.http.get<any>("http://127.0.0.1:8000/EdenManageProperty/employee/");
  }
  putEmp(data:any,id: number){
    return this.http.put<any>("http://127.0.0.1:8000/EdenManageProperty/employee/"+id,data);
  }
  deleteEmp(id:number){
    return this.http.delete<any>("http://127.0.0.1:8000/EdenManageProperty/employee/"+id);
  }
  postProp(data :any){
    return this.http.post<any>("http://localhost:3000/properties-list/",data);
  }
  UploadPhoto(val:any){
    return this.http.post(this.APIUrl+'/SaveFile',val);
  }
/*  postProp(val:any){
    return this.http.post<any>("http://localhost:3000/properties-list/",data);
  }
  getProp(){
    return this.http.get<any>("http://localhost:3000/properties-list/");
  }
  putProp(val:any){
    return this.http.put<any>("http://localhost:3000/properties-list/"+id,data);
  }
  deleteProp(id:number){
    return this.http.delete<any>("http://localhost:3000/properties-list/"+id);
  }
  postCons(val:any){
    return this.http.post<any>("http://localhost:3000/Constraints/",data);
  }
  */
  
}
