import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/service/user.Service';
import { Iuser } from 'src/app/taskmodel/Iuser';
import { Router } from '@angular/router';

@Component({
  selector: 'app-adduser',
  templateUrl: './adduser.component.html',
  styleUrls: ['./adduser.component.css']
})
export class AdduserComponent implements OnInit {
  errorMessage = '';
  pageTitle:string="Add Task";
  user:Iuser ;
  formUser = {};
  constructor(private userService: UserService,private router: Router) {

  }

  ngOnInit() {
  }
  public onSubmit(form) {
    console.log(form);
       
    this.user = {UserId: null,FirstName:form.firstname, LastName: form.lastname,
      EmployeeId:form.employeeid};
     
    this.userService.addUserDetails(this.user).subscribe(
         taskList => {
           alert("The Records has succussfully saved.")
           window.location.reload();
          //this.router.navigate(['/adduser']);
         });
        }
  

     public onResetClick(form) {
      form.reset();
     }

}
