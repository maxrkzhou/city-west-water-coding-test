import { Component, OnInit } from '@angular/core';
import { SchoolService } from 'src/services';
import { ClassDto, StudentDto } from 'src/models/school';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  classList:Array<ClassDto>;
  studentList: Array<StudentDto>;
  selectedClass: string;
  selectedClassId: number;
  constructor(private service: SchoolService) { }

  ngOnInit(): void {
    this.getClassList();
  }

  getClassList(){
    this.service.getClassList().subscribe(res=>{
      if(res.isSuccess){
        this.classList = res.value;
      }
    });
  }

  deleteClass(id:number){
    this.service.deleteClass(id).subscribe(res=>{
      if(res.isSuccess){
        this.getClassList();
      }
    })
  }

  getClassStudents(id:number){
    this.service.getClassStudents(id).subscribe(res=>{
      if(res.isSuccess){
        this.studentList = res.value;
        this.selectedClass = this.classList.filter(x=>x.id == id)[0].name;
        this.selectedClassId = id;
      }
    })
  }

  deleteStudent(id:number){
    this.service.deleteStudent(id).subscribe(res=>{
      if(res.isSuccess){
        this.getClassStudents(this.selectedClassId);
      }
    })
  }
}
