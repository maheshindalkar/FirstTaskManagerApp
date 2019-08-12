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
  task:{};
  userTaskId: any;
  parentId: any;
  tasks:Itask ;
  display='none'; 
  formUser = {};
  constructor( private route: ActivatedRoute,private taskmanagerService: TaskManagerService,private router: Router) {  
  }
  sdate:Date;
  edate:Date;
  tsk: string;
  psk:string;
  pror:string;
  ngOnInit() {
    this.display='block'; 
    this.route.paramMap.subscribe(params => {
        
      this.task = {"tsk":params.getAll("Task"),"psk":params.getAll("ParentTask"),"sdate":params.getAll("StartDate"),
      "edate":params.getAll("EndDate"),"pror":params.getAll("Priority")};
      console.log(params.getAll("StartDate"));

      this.userTaskId = params.getAll("TaskId")
      //this.parentId = this.task.params.ParentId;
    });
  }

  public onModelSubmit(form) {
    console.log(form.value.efDate);
    console.log(form.value.efDate[0]);
    //alert(form.value.straDate[0]);
    //alert(form.value.efDate[0]);
      // alert(form.value.efDate.parTask.value);
    this.tasks = {TaskId:parseInt(this.userTaskId, 10),
      Task:form.value.tname[0], 
      ParentTask: form.value.parTask[0],
      StartDate:form.value.straDate[0], 
      EndDate:form.value.efDate[0],
      Project:null,
      User:null,
      Status:null,
      Priority:form.value.range[0]
    };
      console.log(this.tasks);
      this.taskmanagerService.updateTaskManagerDetails(this.tasks).subscribe(
        taskList => {
          alert("The Records has succussfully Updated.")
          this.router.navigate(['/viewtask']);
          this.display='none';
        });
  }
      
      
  public onResetModelClick(form){
    form.reset();
  }
}
