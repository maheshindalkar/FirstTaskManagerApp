import { Component, OnChanges, SimpleChanges, OnInit, Input, EventEmitter, Output  } from '@angular/core';
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
  @Output() valueUpdate = new EventEmitter(); 
  @Input() user: string;
  constructor(private userService: UserService) {

  }
  ngOnChanges(changes: SimpleChanges) {
     if (changes['user']) {
        this.userService.getUserDetails().subscribe(
        userList => {
          this.users = userList;
        },
        error => this.errorMessage = <any>error
      );
    }
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
      this.valueUpdate.emit(user); 
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
              alert("The Records has succussfully deleted.")
            },
            error => this.errorMessage = <any>error
          );
        });
    }

}
