import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaskManagerService } from 'src/app/service/TaskManager.Service';
import { Itask } from 'src/app/taskmodel/Itask';
import { Router } from '@angular/router';
@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  task:any;
  userTaskId: any;
  parentId: any;
  tasks:Itask ;
  display='none'; 
  formUser = {};
  constructor( private route: ActivatedRoute,private taskmanagerService: TaskManagerService,private router: Router) {  
  }
  ngOnInit() {
    this.display='block'; 
    this.route.paramMap.subscribe(params => {
        this.task = params;
      this.userTaskId = this.task.params.UserTaskId;
      this.parentId = this.task.params.ParentId;
    });
  }

  public onModelSubmit(form) {
       
    this.tasks = {UserTaskId:parseInt(this.userTaskId, 10),ParentId:parseInt(this.parentId, 10),Task:form.name, ParentTask: form.parentTask,
      StartDate:form.startDate, EndDate:form.endDate,
      Priority:form.range};
      
      this.taskmanagerService.updateTaskManagerDetails(this.tasks).subscribe(
        taskList => {
          this.router.navigate(['/view']);
        });
  }
      
      
  public onResetModelClick(form){
    form.reset();
  }
}
