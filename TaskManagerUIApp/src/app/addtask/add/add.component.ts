import { Component, OnInit } from '@angular/core';
import { TaskManagerService } from 'src/app/service/TaskManager.Service';
import { Itask } from 'src/app/taskmodel/Itask';
import { Router } from '@angular/router';
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
  constructor(private taskmanagerService: TaskManagerService,private router: Router) {

  }

  ngOnInit() {
   
  }
  public onSubmit(form) {
    console.log(form);
    
    
    this.tasks = {UserTaskId: null,ParentId:null,Task:form.name, ParentTask: form.parentTask,
      StartDate:form.startDate, EndDate:form.endDate,
      Priority:form.range};
     
    this.taskmanagerService.addTaskManagerDetails(this.tasks).subscribe(
         taskList => {
           alert("The Records has succussfully saved.")
          this.router.navigate(['/view']);
         });
        }
  

     public onResetClick(form) {
      form.reset();
     }
  }


