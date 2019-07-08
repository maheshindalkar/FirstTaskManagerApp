import { Component, OnInit } from '@angular/core';
import { TaskManagerService } from 'src/app/service/TaskManager.Service';
import { Itask } from 'src/app/taskmodel/Itask';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  errorMessage = '';
  pageTitle:string="Add Task";
  tasks:Itask ;
  formUser = {};
  constructor(private taskmanagerService: TaskManagerService) {

  }

  ngOnInit() {
   
  }
  public onSubmit(form) {
    this.tasks = {TaskId: null,ParentTaskId:null,Task:form.name, ParentTask: form.parentTask,StartDate:form.startDate,EndDate:form.endDate,
      Priority:form.range};
    this.taskmanagerService.addTaskManagerDetails(this.tasks).subscribe(
         taskList => {
            this.tasks = taskList;
         });
     }
  
 //public saveUserTasks(){
  //if (this.regForm.dirty && this.regForm.valid) {
  //  alert(`FirstName: ${this.regForm.value.firstName}`);
  //}
  //  this.taskmanagerService.addTaskManagerDetails(this.tasks).subscribe(
  //    taskList => {
  //      this.tasks = taskList;
  //    }
  
  //   error => this.errorMessage = <any>error
  
 }


