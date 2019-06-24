import { Component, OnInit } from '@angular/core';
import { TaskManagerService } from 'src/app/service/TaskManager.Service';
import { FormBuilder, Validators } from '@angular/forms';
@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  errorMessage = '';
  pageTitle:string="Add Task";
  private regForm:any;
  constructor(private taskmanagerService: TaskManagerService, private formBuilder: FormBuilder) {

  }

  ngOnInit() {
    this.regForm= this.formBuilder.group({
      taskName:['', Validators.required]
     })
  }
 public saveUserTasks(){
  if (this.regForm.dirty && this.regForm.valid) {
    alert(`FirstName: ${this.regForm.value.firstName}`);
  }
  //  this.taskmanagerService.addTaskManagerDetails(this.tasks).subscribe(
  //    taskList => {
  //      this.tasks = taskList;
  //    }
  
  //   error => this.errorMessage = <any>error
  );
 }
}
}
