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
  selector: 'app-edit-student',
  templateUrl: './edit-student.component.html',
  styleUrls: ['./edit-student.component.scss']
})
export class EditStudentComponent implements OnInit {
  id:number;
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
    this.route.params.subscribe((params) => {
      this.id = params["id"];
    });
    this.initForm();
    this.getClassList();
    this.getStudent();
  }

  getStudent(){
    this.service.getStudennt(this.id).subscribe(res=>{
      if(res.isSuccess){
        this.student = res.value;
        this.initForm();
      }
    })
  }

  private initForm() {
    this.studentForm = this.formBuilder.group(
      {
        id: [
          { value: this.student.id, disabled: this._disabled }
        ],
        firstname: [
          { value: this.student.firstName, disabled: this._disabled },
          [Validators.required]
        ],
        lastname: [
          { value: this.student.lastName, disabled: this._disabled },
          [Validators.required]
        ],
        age: [
          { value: this.student.age, disabled: this._disabled },
          [Validators.required, Validators.pattern("^[0-9]*$")]
        ],
        gpa: [
          { value: this.student.gpa, disabled: this._disabled },
          [Validators.required, Validators.pattern('\\d+\\.\\d{1}')]
        ],
        enrolClass: [
          { value: this.student.enrolClass, disabled: this._disabled },
          [Validators.required]
        ],
      } 
    );
  }

  get f() {
    return this.studentForm.controls;
  }

  setForm() {
    this.student.id = this.studentForm.value.id;
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
    this.updateStudent();
  }

  updateStudent(){
    this.service.updateStudent(this.student).subscribe(res=>{
      if(res.isSuccess){
        let model = new StudentClassDto();
        model.studentId = this.student.id;
        model.classId = this.student.enrolClass;
        this.service.enrolClass(model).subscribe(res=>{
          if(res.isSuccess){
            this.router.navigate([""]);
          }
        });
      }
    });
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
    model.studentId = this.studentForm.value.id;
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
