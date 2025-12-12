package es.murallaromana.testcompose.ui.theme.layouts

import androidx.compose.foundation.layout.Row
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier


@Composable
fun MiRow (modifier: Modifier = Modifier) {
    Row {
        Text("Hola Mundo!.")
    }
}