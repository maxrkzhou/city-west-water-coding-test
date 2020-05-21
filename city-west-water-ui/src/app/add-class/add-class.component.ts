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
  selector: 'app-add-class',
  templateUrl: './add-class.component.html',
  styleUrls: ['./add-class.component.scss']
})
export class AddClassComponent implements OnInit {
  
  _submitted: boolean = false;
  _disabled: boolean = false;
  class: ClassDto = new ClassDto();
  classForm: FormGroup;

  constructor(private router: Router, 
    private route: ActivatedRoute, 
    private formBuilder: FormBuilder, 
    private service: SchoolService) { }

  ngOnInit(): void {
    this.initForm();
  }

  private initForm() {
    this.classForm = this.formBuilder.group(
      {
        name: [
          { value: "", disabled: this._disabled },
          [Validators.required]
        ],
        location: [
          { value: "", disabled: this._disabled },
          [Validators.required]
        ],
        teacher: [
          { value: "", disabled: this._disabled },
          [Validators.required]
        ]
      },
    );
  }

  get f() {
    return this.classForm.controls;
  }

  setForm() {
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
    this.addclass();
  }

  addclass(){
    this.service.addClass(this.class).subscribe(res =>{
      if(res.isSuccess){
        this.router.navigate([""]);
      }
    });
  }
}
