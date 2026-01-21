package es.murallaromana.testcompose2.ui.screens

import androidx.compose.material3.Button
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier


@Composable
fun MiPrimeraPantalla(modifier: Modifier = Modifier, irASegundaPantalla: () -> Unit) {
    Button(
        onClick = {
            irASegundaPantalla()
        }
    )
    {
        Text("Ir a segunda pantalla")
    }
}