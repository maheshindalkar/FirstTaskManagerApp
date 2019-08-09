import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/service/project.service';
import { Iproject } from 'src/app/taskmodel/Iproject';
import { Router } from '@angular/router';
@Component({
  selector: 'app-addproject',
  templateUrl: './addproject.component.html',
  styleUrls: ['./addproject.component.css']
})
export class AddprojectComponent implements OnInit {
  errorMessage = '';
  pageTitle:string="Add Task";
  project:Iproject ;
  formUser = {};
  constructor(private userService: UserService,private router: Router) {
  }
  ngOnInit() {
  }

}
