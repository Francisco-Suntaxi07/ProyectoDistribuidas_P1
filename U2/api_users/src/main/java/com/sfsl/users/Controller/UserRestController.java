package com.sfsl.users.Controller;

import com.sfsl.users.Model.Entity.UserEntity;
import com.sfsl.users.Model.Service.IUserService;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Optional;

@RestController
@RequestMapping("/api")
public class UserRestController {

    @Autowired
    private IUserService userService;

    @GetMapping("/users/all")
    public ResponseEntity<List<UserEntity>> findAllUsers (){
        return ResponseEntity.ok().body(userService.findAllUsers());
    }

    @GetMapping("/users/{id}")
    public ResponseEntity<?> findUserById(@PathVariable Long id){
        Optional<UserEntity> response = userService.findUserById(id);
        if (!response.isPresent()){
            return ResponseEntity.notFound().build();
        }
        return ResponseEntity.ok().body(response.get());
    }

    @PostMapping("/users/save")
    public ResponseEntity<?> saveUser(@Valid @RequestBody UserEntity user, BindingResult result){
        if(result.hasErrors()) {
            return this.validar(result);
        }
        UserEntity response = userService.saveUser(user);
        return ResponseEntity.status(HttpStatus.CREATED).body(response);
    }

    @DeleteMapping("/users/delete/{id}")
    public ResponseEntity<?> deleteUserByID(@PathVariable Long id){
        boolean response = userService.deleteUserByID(id);
        if(response) {
            return ResponseEntity.status(HttpStatus.OK).body(true);
        }
        return ResponseEntity.status(HttpStatus.NOT_FOUND).body(false);
    }

    protected ResponseEntity<?> validar(BindingResult result){
        Map<String, Object> errores = new HashMap<>();
        result.getFieldErrors().forEach(err -> {
            errores.put(err.getField(),"El campo "+err.getField()+" "+err.getDefaultMessage());
        });
        return ResponseEntity.badRequest().body(errores);
    }
}
