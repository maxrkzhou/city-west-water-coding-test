import { Component, OnInit } from "@angular/core";
import {SchoolService} from 'src/services';
import {ClassDto} from 'src/models/school';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit  {
  classList: Array<ClassDto>;

  constructor(private service: SchoolService){}

  ngOnInit() {
    this.getClassList();
  }

  getClassList(){
    this.service.getClassList();
  }
}
