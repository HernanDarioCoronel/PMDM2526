package com.example.practicaexamen.screens

import androidx.compose.foundation.layout.Column
import androidx.compose.material3.Button
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable

@Composable
fun Login(navigateToCochesList:()->Unit, navigateToOther:()->Unit){
    Column() {
        Text("Login")
        Button(
            onClick = navigateToCochesList,
            content = {Text("Go to List")}
        )
        Button(
            onClick = navigateToOther,
            content = {Text("Go to Otra Vista")}
        )
    }
}