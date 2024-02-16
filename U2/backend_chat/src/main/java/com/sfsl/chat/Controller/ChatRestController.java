package com.sfsl.chat.Controller;

import com.sfsl.chat.Model.Entity.ChatEntity;
import com.sfsl.chat.Model.Service.IChatService;
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
public class ChatRestController {

    @Autowired
    private IChatService chatService;

    @CrossOrigin(origins = "*")
    @GetMapping("/chats/all")
    public ResponseEntity<List<ChatEntity>> findAllChats (){
        return ResponseEntity.ok().body(chatService.findAllChats());
    }

    @CrossOrigin(origins = "*")
    @GetMapping("/chats/{id}")
    public ResponseEntity<?> findChatById(@PathVariable Long id){
        Optional<ChatEntity> response = chatService.findChatById(id);
        if (!response.isPresent()){
            return ResponseEntity.notFound().build();
        }
        return ResponseEntity.ok().body(response.get());
    }

    @CrossOrigin(origins = "*")
    @PostMapping("/chats/save")
    public ResponseEntity<?> saveChat(@Valid @RequestBody ChatEntity chat, BindingResult result){
        if(result.hasErrors()) {
            return this.validar(result);
        }
        ChatEntity response = chatService.saveChat(chat);
        return ResponseEntity.status(HttpStatus.CREATED).body(response);
    }

    @CrossOrigin(origins = "*")
    @DeleteMapping("/chats/delete/{id}")
    public ResponseEntity<?> deleteChatByID(@PathVariable Long id){
        boolean response = chatService.deleteChatByID(id);
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
