import { Injectable } from '@angular/core';
import { FormControl , FormGroup , Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class PricepredictionService {

  constructor() { }

  form: FormGroup = new FormGroup({
    $key: new FormControl(null),
    area: new FormControl('',Validators.required),
    type: new FormControl('',Validators.required),
    bedrooms: new FormControl('',Validators.required),
    bathrooms: new FormControl('',Validators.required),
    location: new FormControl(0,Validators.required)
  });

}
 