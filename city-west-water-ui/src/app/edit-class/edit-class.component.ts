import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators
} from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ClassDto } from 'src/models/school';
import { SchoolService } from 'src/services';

@Component({
  selector: 'app-edit-class',
  templateUrl: './edit-class.component.html',
  styleUrls: ['./edit-class.component.scss']
})
export class EditClassComponent implements OnInit {
  id:number;
  _submitted: boolean = false;
  _disabled: boolean = false;
  class: ClassDto = new ClassDto();
  classForm: FormGroup;

  constructor(private router: Router, 
    private route: ActivatedRoute, 
    private formBuilder: FormBuilder, 
    private service: SchoolService) { 
       
    }

  ngOnInit(): void {
    this.initForm();
    this.route.params.subscribe((params) => {
      this.id = params["id"];
    });
    this.service.getClass(this.id).subscribe(res=>{
      if(res.isSuccess){
        this.class = res.value;
        this.initForm();
      }
  
    })

  }

  private initForm() {
    this.classForm = this.formBuilder.group(
      {
        id: [
          { value: this.class.id, disabled: this._disabled }
        ],
        name: [
          { value: this.class.name, disabled: this._disabled },
          [Validators.required]
        ],
        location: [
          { value: this.class.location, disabled: this._disabled },
          [Validators.required]
        ],
        teacher: [
          { value: this.class.teacher, disabled: this._disabled },
          [Validators.required]
        ]
      },
    );
  }

  get f() {
    return this.classForm.controls;
  }

  setForm() {
    this.class.id = this.classForm.value.id;
    this.class.name = this.classForm.value.name;
    this.class.location = this.classForm.value.location;
    this.class.teacher = this.classForm.value.teacher;
  }

  onSubmit() {
    this._submitted = true;
    if (this.classForm.invalid) {
      return;
    }
    this.setForm();
    this.updateClass();
  }

  updateClass(){
    console.log(this.class);
    this.service.updateClass(this.class).subscribe(res=>{
      if(res.isSuccess){
        this.router.navigate([""]);
      }
    })
  }
}
