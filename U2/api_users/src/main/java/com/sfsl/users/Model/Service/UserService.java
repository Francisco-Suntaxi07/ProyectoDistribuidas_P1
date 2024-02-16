package com.sfsl.users.Model.Service;

import com.sfsl.users.Model.Entity.UserEntity;
import com.sfsl.users.Model.Repository.IUserRepository;
import org.apache.catalina.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.Base64;
import java.util.List;
import java.util.Optional;

@Service
public class UserService implements IUserService{

    @Autowired
    private IUserRepository userRepository;

    @Override
    public List<UserEntity> findAllUsers() {
        return (ArrayList<UserEntity>) userRepository.findAll();
    }

    @Override
    public Optional<UserEntity> findUserById(Long id) {
        return userRepository.findById(id);
    }


    @Override
    public UserEntity saveUser(UserEntity user) {
        String password = this.encryptData(user.getPassword());
        user.setPassword(password);
        return userRepository.save(user);
    }
    private String encryptData(String data) {
        return Base64.getEncoder().encodeToString(data.getBytes());
    }

    @Override
    public Boolean deleteUserByID(Long id) {
        try {
            userRepository.deleteById(id);
            return true;
        }catch(Exception e){
            System.out.println("ERROR EN LA API USUARIO: " + e.getMessage());
            return false;
        }
    }
}
