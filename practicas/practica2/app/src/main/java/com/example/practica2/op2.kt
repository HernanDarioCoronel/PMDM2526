package com.example.practica2

import androidx.compose.material3.Button
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable

@Composable
fun Op2(navigateToop1:()->Unit){
    Button (
        onClick = navigateToop1,
        content = { Text("OP 1") }
    )
}