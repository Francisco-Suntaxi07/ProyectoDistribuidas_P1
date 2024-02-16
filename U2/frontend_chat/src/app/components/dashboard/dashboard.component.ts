import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserModel } from 'src/app/models/UserModel';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {

  private listUsers: UserModel[] = [];
  connectedListUsers: UserModel[] = [];
  private userId: Number = 0;

  constructor(
    private userService: UsersService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.userId = Number(this.route.snapshot.params["userId"]);
    this.loadUsers();
  }

  loadUsers() {
    this.userService.findAllUsers().subscribe(data => {
      this.listUsers = data;
      console.log("DASH: ", this.listUsers);
      this.listUsers.forEach((user: UserModel) => {
        if (this.userId != user.id) {
          this.connectedListUsers.push(user);
        }
      });
    });
  }

}
