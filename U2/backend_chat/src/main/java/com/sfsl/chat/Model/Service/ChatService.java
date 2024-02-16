package com.sfsl.chat.Model.Service;

import com.sfsl.chat.Model.Entity.ChatEntity;
import com.sfsl.chat.Model.Repository.IChatRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
public class ChatService implements IChatService{

    @Autowired
    private IChatRepository chatRepository;

    @Override
    public List<ChatEntity> findAllChats() {
        return (ArrayList<ChatEntity>) chatRepository.findAll();
    }

    @Override
    public Optional<ChatEntity> findChatById(Long id) {
        return chatRepository.findById(id);
    }

    @Override
    public ChatEntity saveChat(ChatEntity chat) {
        return chatRepository.save(chat);
    }

    @Override
    public Boolean deleteChatByID(Long id) {
        try {
            chatRepository.deleteById(id);
            return true;
        }catch(Exception e){
            System.out.println("ERROR EN LA API CHAT: " + e.getMessage());
            return false;
        }
    }
}
