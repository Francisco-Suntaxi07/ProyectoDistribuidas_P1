package com.sfsl.users.Model.Service;

import com.sfsl.users.Model.Entity.UserEntity;

import java.util.List;
import java.util.Optional;

public interface IUserService {
    public List<UserEntity> findAllUsers();
    public Optional<UserEntity> findUserById(Long id);
    public UserEntity saveUser(UserEntity user);
    public Boolean deleteUserByID(Long id);
}
