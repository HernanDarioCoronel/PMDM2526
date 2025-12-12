package es.murallaromana.testcompose.ui.theme.layouts

import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.tooling.preview.Preview
import es.murallaromana.testcompose.ui.theme.components.MiBoton

@Preview
@Composable
fun MiColumna(modifier: Modifier = Modifier) {
    Box() {
        Column(modifier = modifier) {
            MiRow()
            MiRow()
            MiRow()
        }
        Column(modifier = modifier) {
            MiRow()
            MiRow()
            MiRow()
        }
        MiBoton()
    }
}