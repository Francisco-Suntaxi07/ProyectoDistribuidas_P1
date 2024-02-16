package com.sfsl.chat.Model.Repository;

import com.sfsl.chat.Model.Entity.ChatEntity;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface IChatRepository extends CrudRepository<ChatEntity,Long> {
}
