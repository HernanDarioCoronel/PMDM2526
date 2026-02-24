package com.example.practica2

import androidx.compose.material3.Button
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable

@Composable
fun Op1(navigateToop2:()->Unit){
    Button (
        onClick = navigateToop2,
        content = { Text("OP 2") }
    )
}