import { Component, OnInit } from '@angular/core';
import { TaskManagerService } from 'src/app/service/TaskManager.Service';
import { ProjectService } from 'src/app/service/project.service';
import { UserService } from 'src/app/service/user.service';
import { Itask } from 'src/app/taskmodel/Itask';
import { Iproject } from 'src/app/taskmodel/Iproject';
import { Router } from '@angular/router';
import { Iuser } from 'src/app/taskmodel/Iuser';
@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  errorMessage = '';
  prntTask:string;
  pageTitle:string="Add Task";
  tasks:Itask ;
  project:Iproject;
  usre:Iuser;
  formUser = {};
  items=[];
  display = 'none';
  parentTaskdisplay = 'none';
  Projects:string ;
  uname: string;
  constructor(private taskmanagerService: TaskManagerService,private router: Router,
    private projectService:ProjectService,  private userService:UserService) {

  }

  ngOnInit() {
   
  }
  openprojectModal() {
    this.items=[];
    this.projectService.getProjectDetails().subscribe(
      projList => {
        for(var i = 0; i < projList.length; i++) {
           var obj = {
            "id":projList[i].ProjectId,
            "name":projList[i].Projects,
            "filterby":"projectfiltr"
            };
            
            this.items.push(obj);
          }
          this.display = 'block';
      }    
     );
  }

  openuserModal() {
    this.items=[];
    this.userService.getUserDetails().subscribe(
      usList => {
        for(var i = 0; i < usList.length; i++) {
           var obj = {
            "id":usList[i].UserId,
            "name":usList[i].FirstName,
            "filterby":"userfiltr"
            };
            
            this.items.push(obj);
          }
          this.display = 'block';
      }    
     );
  }

  openparenttaskModal() {
    this.items=[{id:'1',name:'parentTask1',filterby:'parenttaskfiltr'},
    {id:'2',name:'parentTask2',filterby:'parenttaskfiltr'}];
   
     this.display = 'block';
  }

  selectedItem: any={id:'',name:'',filterby:''};
  onSelect(manager): void {
    console.log(manager);
    this.selectedItem = manager;
    }

    
onClickSearchFilter() {
  
if (this.selectedItem) {
  if(this.selectedItem.filterby == "projectfiltr")
  {
    this.Projects = this.selectedItem.name;
  }
  if(this.selectedItem.filterby == "userfiltr")
  {
    this.uname = this.selectedItem.name;
  }
  if(this.selectedItem.filterby == "parenttaskfiltr")
  {
    this.prntTask = this.selectedItem.name;
  } 
}
        this.display = 'none';
}
onCloseHandled() {
  this.display = 'none';
}

  public onSubmit(frm,form) {
    console.log(form);
       
    this.tasks = {TaskId: null,ParentTask:form.parentTask,Task:form.taskDetail, Project: form.projectname,
      StartDate:form.startDate, EndDate:form.endDate,User:form.username,Status:null,
      Priority:form.priority};
     
    this.taskmanagerService.addTaskManagerDetails(this.tasks).subscribe(
         taskList => {
           alert("The Records has succussfully saved.")
           frm.reset();
         });
        }
  

     public onResetClick(frm,form) {
      frm.reset();
     }
  }


