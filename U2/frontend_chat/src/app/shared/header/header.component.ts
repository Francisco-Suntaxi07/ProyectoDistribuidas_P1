import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserModel } from 'src/app/models/UserModel';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  userId: number | undefined;
  user: UserModel = new UserModel();
  goBack(): void {
    window.history.back();
  }
  constructor(
    private route: ActivatedRoute,
    private userService: UsersService,
  ){

  }

  ngOnInit(): void {
    this.userId = this.route.snapshot.params["userId"];
    this.userService.findUserById(Number(this.userId)).subscribe(data =>{
      this.user = data;
    });
  }
}
