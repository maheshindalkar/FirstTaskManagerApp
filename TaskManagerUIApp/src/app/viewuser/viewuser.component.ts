import { Component, OnInit, Input} from '@angular/core';
import { Iuser } from 'src/app/taskmodel/Iuser';
import { UserService } from 'src/app/service/user.service';
import { $ } from 'protractor';

@Component({
  selector: 'app-viewuser',
  templateUrl: './viewuser.component.html',
  styleUrls: ['./viewuser.component.css']
})
export class ViewuserComponent implements OnInit {

  errorMessage = '';
  users : Iuser[] =[];
  //@Input() users: Iuser;
  constructor(private userService: UserService) {

  }

  ngOnInit(): void {
    this.userService.getUserDetails().subscribe(
      userList => {
        this.users = userList;
      },
      error => this.errorMessage = <any>error
    );
    }
    public onEditUserClick(user)
    {
       //$("#txtfirstname").val("5");
       //var myInput = $("#txtfirstname");
      console.log(user.UserId);
    }
    public onDeleteUserClick(user)
    {
      console.log(user.UserId);
      this.userService.deleteUserDetails(user.UserId).subscribe(
        taskList => {
          this.userService.getUserDetails().subscribe(
            userList => {
              this.users = userList;
              window.location.reload();
            },
            error => this.errorMessage = <any>error
          );
        });
    }

}
