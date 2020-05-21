import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators
} from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";

import { StudentDto, ClassDto, StudentClassDto, CheckStudentDto } from 'src/models/school';
import { SchoolService } from 'src/services';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.scss']
})
export class AddStudentComponent implements OnInit {

  _submitted: boolean = false;
  _disabled: boolean = false;
  _invalidStudent: boolean = true;
  student: StudentDto = new StudentDto();
  studentForm: FormGroup;
  classList:Array<ClassDto>;

  constructor(private router: Router, 
    private route: ActivatedRoute, 
    private formBuilder: FormBuilder, 
    private service: SchoolService) { }

  ngOnInit(): void {
    this.initForm();
    this.getClassList();
  }

  private initForm() {
    this.studentForm = this.formBuilder.group(
      {
        firstname: [
          { value: "", disabled: this._disabled },
          [Validators.required]
        ],
        lastname: [
          { value: "", disabled: this._disabled },
          [Validators.required]
        ],
        age: [
          { value: "", disabled: this._disabled },
          [Validators.required, Validators.pattern("^[0-9]*$")]
        ],
        gpa: [
          { value: "", disabled: this._disabled },
          [Validators.required, Validators.pattern('\\d+\\.\\d{1}')]
        ],
        enrolClass: [
          { value: "", disabled: this._disabled },
          [Validators.required]
        ],
      } 
    );
  }

  get f() {
    return this.studentForm.controls;
  }

  setForm() {
    this.student.firstName = this.studentForm.value.firstname;
    this.student.lastName = this.studentForm.value.lastname;
    this.student.age = this.studentForm.value.age;
    this.student.gpa = this.studentForm.value.gpa;
    this.student.enrolClass = this.studentForm.value.enrolClass;
  }

  onSubmit() {
    this.checkStudent();
    this._submitted = true;
    if (this.studentForm.invalid) {
      return;
    }
    if(this._invalidStudent){
      return;
    }
    this.setForm();
    this.addStudent();
  }

  addStudent(){
    this.service.addStudent(this.student).subscribe(res=>{
      if(res.isSuccess){
        let model = new StudentClassDto();
        model.studentId = res.value;
        model.classId = this.student.enrolClass;
        this.service.enrolClass(model).subscribe(res=>{
          if(res.isSuccess){
            this.router.navigate([""]);
          }
        });

      }
    })
  }

  getClassList(){
    this.service.getClassList().subscribe(res=>{
      if(res.isSuccess){
        this.classList = res.value;
      }
    });
  }

  checkStudent(){
    let model = new CheckStudentDto();
    model.classId = this.studentForm.value.enrolClass;
    model.surname = this.studentForm.value.lastname;
    if(model.classId && model.surname){
      this.service.checkStudent(model).subscribe(res=>{
        if(res.isSuccess){
          this._invalidStudent = res.value;
        }else{
          this._invalidStudent = true;
        }
      })
    }
  }
}