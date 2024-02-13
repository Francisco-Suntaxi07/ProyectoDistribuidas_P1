package com.sfsl.chat.Model;

import lombok.AllArgsConstructor;
import lombok.Data;

@Data
@AllArgsConstructor
public class MessageDto {

    private String message;
    private String user;
}
