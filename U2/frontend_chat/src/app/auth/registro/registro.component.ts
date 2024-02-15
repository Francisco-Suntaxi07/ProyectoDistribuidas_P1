import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { UserModel } from 'src/app/models/UserModel';
import { UsersService } from 'src/app/services/users.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.scss']
})
export class RegistroComponent {

  hide = true;
  private listUsers: UserModel[] = [];
  private _form: FormGroup = this.formBuilder.group({
    name: ['', Validators.required],
    password: ['', Validators.required],
  });
  
  constructor(
    public dialogRef: MatDialogRef<RegistroComponent>,
    private formBuilder: FormBuilder,
    private userService: UsersService,
    private snackBar: MatSnackBar,
  ) { }

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers() {
    this.userService.findAllUsers().subscribe(data => {
      this.listUsers = data;
    });
  }

  closeSignIn(): void {
    this.dialogRef.close();
  }


  saveUser() {
    let user: UserModel = new UserModel();
    try{
      user = this.form.value;
      this.verifyUsers(user)
      if(this.verifyUsers(user)){
        this.userService.saveUser(user).subscribe({
          next: () => {
            this.snackBar.open("✅ El usuario se registro correctamente", "Cerrar", {
              duration: 2000
            });
          },
          error: (error) => {
            this.snackBar.open("⛔ Ocurrió un error al guardar el usuario", "Cerrar", {
              duration: 2000
            });
            console.log(error);
          }
        });
      }else{
        this.snackBar.open("🚫 El usuario ya se encuentra registrado", "Cerrar", {
          duration: 2000
        });
      }

    } catch (error) {
      console.error(error);
    }

  }

  verifyUsers(user: UserModel): boolean {
    this.loadUsers();
    for (let i = 0; i < this.listUsers.length; i++) {
      if (user.name === this.listUsers[i].name && user.password === this.listUsers[i].password) {
        return false;
      }
    }
    return true;
  }

  public get form(): FormGroup {
    return this._form;
  }

}
