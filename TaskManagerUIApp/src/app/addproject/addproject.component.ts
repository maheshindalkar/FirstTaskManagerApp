import { Component, OnInit } from '@angular/core';
import { ProjectService } from 'src/app/service/project.service';
import { UserService } from 'src/app/service/user.service';
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
  display = 'none';
  selectedItem: any={id:'',name:''};
  ManagerId:number;
  ProjectId:number;
  selectedmanager:string;
   
    Projects:string;
    Priority:string;
      StartDate:Date;
      EndDate:Date;
  constructor(private projectService: ProjectService, private userService: UserService,private router: Router) {
  }
  Users: any[];
  disabledDate: Boolean = true;
  changeCheck(event) {
    this.disabledDate = !event.target.checked;
  }
  openModal() {
    
    this.userService.getUserDetails().subscribe(
      userList => {
        this.Users = userList;
        this.display = 'block';
      },
      error => this.errorMessage = <any>error
    );
  }
  onCloseHandled() {
    this.display = 'none';
  }
  ngOnInit() {
  }
  onSelect(manager): void {
        this.selectedItem = manager;
  }
  onSelectedManager1() {
    if (this.selectedItem) {
         this.ManagerId =this.selectedItem.EmployeeId};
          this.display = 'none';
    }
    getProjectUpdatedvalue($event) {  
      console.log($event.Project); 
      

      var stdateOut = new Date($event.StartDate);
      stdateOut.setDate(stdateOut.getDate());
      stdateOut.setSeconds(0);
      stdateOut.setMinutes(0);
      stdateOut.setHours(0);
      var enddateOut = new Date($event.EndDate);
      enddateOut.setDate(stdateOut.getDate());
      enddateOut.setSeconds(0);
      enddateOut.setMinutes(0);
      enddateOut.setHours(0);

      this.ProjectId = $event.ProjectId
      this.ManagerId = $event.ManagerId;  
      this.Projects = $event.Projects;
      this.StartDate =  stdateOut;
      this.EndDate = enddateOut;
      document.getElementById('btnaddproject').innerHTML = "Update";
      } 
    public onSubmit(reForm,form) {
      console.log(form);
      
      this.project = {
        ProjectId:this.ProjectId,
        ManagerId:this.ManagerId,
        Projects:form.projectname,
        Priority:form.range,
          StartDate:form.stDate,
          EndDate:form.eDate,
         };
         console.log(this.project);
      if(document.getElementById('btnaddproject').innerHTML == "Update")
         {
           this.projectService.updateProjectDetails(this.project).subscribe(
            taskList => {
              alert("The Records has succussfully updated.")
              document.getElementById('btnaddproject').innerHTML = "Add";
               reForm.reset();
            });
         }
         else
         {
           this.projectService.addProjectDetails(this.project).subscribe(
           taskList => {
             alert("The Records has succussfully saved.")
             reForm.reset();
            });
          }
         
    }
  
       public onResetClick(form) {
        form.reset();
       // document.getElementById('btnadditem').innerHTML = "Add";
        //this.istrue = false;
       }
  
  }


