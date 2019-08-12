import { Component, OnChanges, SimpleChanges, OnInit, Input, EventEmitter, Output  } from '@angular/core';
import { Iproject } from 'src/app/taskmodel/Iproject';
import { ProjectService } from 'src/app/service/project.service';

@Component({
  selector: 'app-viewproject',
  templateUrl: './viewproject.component.html',
  styleUrls: ['./viewproject.component.css']
})
export class ViewprojectComponent implements OnInit {

  errorMessage = '';
  projects : Iproject[] =[];
  @Output() valueProjectUpdate = new EventEmitter(); 
  @Input() project: string;
  constructor(private projectService: ProjectService) {

  }
  ngOnChanges(changes: SimpleChanges) {
     if (changes['project']) {
        this.projectService.getProjectDetails().subscribe(
        projectList => {
          this.projects = projectList;
        },
        error => this.errorMessage = <any>error
      );
    }
  }

  ngOnInit(): void {
    this.projectService.getProjectDetails().subscribe(
      projectList => {
        this.projects = projectList;
      },
      error => this.errorMessage = <any>error
    );
    }
    public onUpdateProjectClick(project)
    {
      this.valueProjectUpdate.emit(project); 
      console.log(project.Projects);
    }
    public onDeleteUserClick(project)
    {
      //console.log(user.UserId);
      this.projectService.deleteProjectDetails(project.prjectid).subscribe(
        taskList => {
          this.projectService.getProjectDetails().subscribe(
            projectList => {
              this.projects = projectList;
              alert("The Records has succussfully deleted.")
            },
            error => this.errorMessage = <any>error
          );
        });
    }

}
