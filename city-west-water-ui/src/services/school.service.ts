import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import {ClassDto, StudentDto, StudentClassDto, CheckStudentDto} from 'src/models/school';
import { IValuedResult, IResult } from 'src/models/common';
const BASE_URL  = 'https://localhost:44338'; 

@Injectable({ providedIn: "root" })
export class SchoolService {
  
  constructor(private http: HttpClient) {}

  addClass(model:ClassDto){
    return this.http.post<IValuedResult<number>>(`${BASE_URL}/api/school/class/add`, model);
  }

  updateClass(model: ClassDto){
    return this.http.put<IResult>(`${BASE_URL}/api/school/class/update`, model);
  }

  getClass(id:number){
    return this.http.get<IValuedResult<ClassDto>>(`${BASE_URL}/api/school/class/${id}`)
  }

  getClassList(){
      return this.http.get<IValuedResult<Array<ClassDto>>>(`${BASE_URL}/api/school/class/list`);
  }

  deleteClass(id: number){
    return this.http.delete<IResult>(`${BASE_URL}/api/school/class/delete/${id}`);
  }

  getClassStudents(id:number){
    return this.http.get<IValuedResult<Array<StudentDto>>>(`${BASE_URL}/api/school/class/${id}/students`);
  }

  addStudent(model:StudentDto){
    return this.http.post<IValuedResult<number>>(`${BASE_URL}/api/school/student/add`, model);
  }

  enrolClass(model: StudentClassDto){
    return this.http.post<IResult>(`${BASE_URL}/api/school/enrol-class`,model);
  }

  updateStudent(model: StudentDto){
    return this.http.put<IResult>(`${BASE_URL}/api/school/student/update`, model);
  }

  deleteStudent(id:number){
    return this.http.delete<IResult>(`${BASE_URL}/api/school/student/delete/${id}`);
  }

  getStudennt(id:number){
    return this.http.get<IValuedResult<StudentDto>>(`${BASE_URL}/api/school/student/${id}`)
  }

  checkStudent(model: CheckStudentDto){
    return this.http.post<IValuedResult<boolean>>(`${BASE_URL}/api/school/check-student`, model);
  }
}