import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { UserModel } from 'src/app/models/UserModel';
import { UsersService } from 'src/app/services/users.service';
import { RegistroComponent } from '../registro/registro.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  hide = true;
  private listUsers: UserModel[] = [];
  private user: UserModel = new UserModel();
  userName: string | undefined;
  password: string | undefined;

  constructor(
    private router: Router,
    private userService: UsersService,
    private snackBar: MatSnackBar,
    public dialog: MatDialog) { }

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
    if (this.verifyUser()) {
      this.router.navigate(['/home', this.user.id]);
    } else {
      this.snackBar.open("❌ Usuario o contraseña incorrecta", "Cerrar", {
        duration: 3000
      });
    }
  }

  verifyUser(): boolean {
    let name = this.userName;
    let password = this.password;
    for (let i = 0; i < this.listUsers.length; i++) {
      if (name == this.listUsers[i].name && password == this.listUsers[i].password) {
        this.user = this.listUsers[i];
        return true;
      }
    }
    return false;
  }

  openSignIn(): void {
    const dialogRef = this.dialog.open(RegistroComponent);

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.loadUsers();
    });
  }

}
