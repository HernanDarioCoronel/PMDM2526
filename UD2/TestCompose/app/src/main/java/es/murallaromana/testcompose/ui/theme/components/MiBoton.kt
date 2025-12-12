package es.murallaromana.testcompose.ui.theme.components

import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.shape.CircleShape
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material3.Button
import androidx.compose.material3.ButtonDefaults
import androidx.compose.material3.FloatingActionButton
import androidx.compose.material3.Icon
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import es.murallaromana.testcompose.R

@Preview
@Composable
fun MiBoton(modifier: Modifier = Modifier) {
    Button(
        onClick = {},
        //enabled = false,
        modifier = Modifier
            .fillMaxWidth(),
        shape = RoundedCornerShape(8.dp),
        colors = ButtonDefaults.buttonColors(
            Color.Black,
            Color.Cyan,
            Color.DarkGray,
            Color.Magenta
        )
    ) {
        Text("Pulsar")
    }
}

@Preview
@Composable
fun MiFloatingActionButton() {
    Box(
        Modifier
            .fillMaxSize()
            .padding(12.dp),
        contentAlignment = Alignment.BottomEnd,
    )
    {
        FloatingActionButton(
            onClick = {},
            modifier = Modifier,
            containerColor = Color.Cyan,
            shape = CircleShape
        ) {
            Icon(
                modifier = Modifier.size(48.dp),
                painter = painterResource(R.drawable.plus_icon),
                contentDescription = "plus icon"
            )
        }
    }
}