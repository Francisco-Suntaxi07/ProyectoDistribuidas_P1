import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { UserModel } from 'src/app/models/UserModel';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  private listUsers: UserModel[] = [];
  userName: string = '';
  password: string = '';

  constructor(
    private router: Router,
    private userService: UsersService,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers() {
    this.userService.findAllUsers().subscribe(data => {
      this.listUsers = data;
      console.log(this.listUsers);
    });
  }

  goToChat() {
    if (this.verifyUsers()) {
      this.router.navigate(['/chat', this.userName]);
    } else {
      this.snackBar.open("Usuario o contraseña incorrecta", "Cerrar", {
        duration: 3000
      });
    }
  }

  verifyUsers(): boolean {
    let user = this.userName;
    let password = this.password;
    for (let i = 0; i < this.listUsers.length; i++) {
      if (user == this.listUsers[i].name && password == this.listUsers[i].password) {
        return true;
      }
    }
    return false;
  }

}
