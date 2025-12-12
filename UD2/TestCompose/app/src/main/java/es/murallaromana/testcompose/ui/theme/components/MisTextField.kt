package es.murallaromana.testcompose.ui.theme.components

import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxHeight
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.windowInsetsEndWidth
import androidx.compose.material3.OutlinedTextField
import androidx.compose.material3.Text
import androidx.compose.material3.TextField
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.saveable.rememberSaveable
import androidx.compose.runtime.setValue
import androidx.compose.ui.tooling.preview.Preview
import  androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.unit.dp

//@Preview
@Composable
fun EjemploWeights2() {
    Column {
        Box(
            modifier = Modifier
                .fillMaxWidth()
                .background(Color.Red)
                .weight(1F)
        )       // 10%
        Box(
            modifier = Modifier
                .fillMaxWidth()
                .background(Color.Blue)
                .weight(5F)
        )      // 50%
        Box(
            modifier = Modifier
                .fillMaxWidth()
                .background(Color.Green)
                .weight(1F)
        )     // 10%
        Box(
            modifier = Modifier
                .fillMaxWidth()
                .background(Color.Yellow)
                .weight(1F)
        )    // 10%
        Box(
            modifier = Modifier
                .fillMaxWidth()
                .background(Color.Cyan)
                .weight(1F)
        )      // 10%
        Box(
            modifier = Modifier
                .fillMaxWidth()
                .background(Color.Magenta)
                .weight(1F)
        )   // 10%
    }
}

@Preview
@Composable
fun EjemploWeight1() {
    Column {
        Row(
            modifier = Modifier
                .background(Color.Red)
                .fillMaxWidth()
                .weight(1f)
        ) {}
        Row(
            modifier = Modifier
                .background(Color.Green)
                .fillMaxWidth()
                .weight(1f)
        ) {}
        Row(modifier = Modifier
            .fillMaxWidth()
            .weight(1f)) {
            Box (modifier = Modifier
                .fillMaxWidth()
                .weight(1f)
                .background(Color.Blue))
            Column {
                Box(modifier = Modifier
                    .fillMaxWidth()
                    .weight(1f)
                    .background(Color.Red))
                Box(modifier = Modifier
                    .fillMaxWidth()
                    .weight(1f)
                    .background(Color.Yellow))
            }
        }
    }
}

//@Preview
@Composable
fun MisTextField(modifier: Modifier = Modifier) {
    // var texto = remember { mutableStateOf("Hola!") }
    // var texto by remember { mutableStateOf("Hola!") }
    var nombre by rememberSaveable() { mutableStateOf("Juan") }
    var apellido by rememberSaveable() { mutableStateOf("Perez") }
    Column(
        modifier = Modifier
            .padding(25.dp)
            .fillMaxWidth()
            .fillMaxHeight(),
        verticalArrangement = Arrangement.SpaceEvenly
    ) {
        TextField(
            modifier = Modifier.fillMaxWidth(),
            value = nombre, onValueChange = {
                nombre = it
            },
            label = { Text("Nombre") }
        )

        //Spacer(Modifier.height(16.dp))

        OutlinedTextField(
            modifier = Modifier.fillMaxWidth(),
            value = apellido, onValueChange = {
                apellido = it
            },
            label = { Text("Apellido") }
        )
        TextField(
            modifier = Modifier.fillMaxWidth(),
            value = nombre, onValueChange = {
                nombre = it
            },
            label = { Text("Nombre") }
        )

        //Spacer(Modifier.height(16.dp))

        OutlinedTextField(
            modifier = Modifier.fillMaxWidth(),
            value = apellido, onValueChange = {
                apellido = it
            },
            label = { Text("Apellido") }
        )
        TextField(
            modifier = Modifier.fillMaxWidth(),
            value = nombre, onValueChange = {
                nombre = it
            },
            label = { Text("Nombre") }
        )

        //Spacer(Modifier.height(16.dp))

        OutlinedTextField(
            modifier = Modifier.fillMaxWidth(),
            value = apellido, onValueChange = {
                apellido = it
            },
            label = { Text("Apellido") }
        )
        TextField(
            modifier = Modifier.fillMaxWidth(),
            value = nombre, onValueChange = {
                nombre = it
            },
            label = { Text("Nombre") }
        )

        //Spacer(Modifier.height(16.dp))

        OutlinedTextField(
            modifier = Modifier.fillMaxWidth(),
            value = apellido, onValueChange = {
                apellido = it
            },
            label = { Text("Apellido") }
        )
    }
}