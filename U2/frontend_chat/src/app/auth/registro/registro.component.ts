import { Component } from '@angular/core';
import { UserModel } from 'src/app/models/UserModel';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.scss']
})
export class RegistroComponent {


  /*guardarUsuario() {
    const usuario: UserModel = new UserModel();

    usuario.name = 'Ejemplo'; // Cadena
    usuario.password = '123456'; // Cadena// Booleano
    console.log(usuario)
    this.userService.saveUser(usuario).subscribe(() => { }

    );

  }*/

}
