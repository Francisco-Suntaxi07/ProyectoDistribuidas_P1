package com.sfsl.chat.Model.Service;

import com.sfsl.chat.Model.Entity.ChatEntity;

import java.util.List;
import java.util.Optional;

public interface IChatService {
    public List<ChatEntity> findAllChats();
    public Optional<ChatEntity> findChatById(Long id);
    public ChatEntity saveChat(ChatEntity chat);
    public Boolean deleteChatByID(Long id);
}
