package es.murallaromana.testcompose.ui.theme.components

import androidx.compose.foundation.Image
import androidx.compose.foundation.layout.size
import androidx.compose.material3.ExperimentalMaterial3Api
import androidx.compose.material3.Text
import androidx.compose.material3.TopAppBar
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.unit.dp
import es.murallaromana.testcompose.R

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun MiTopBar(modifier: Modifier = Modifier) {
    TopAppBar(
        title = { Text("Mi Top Bar") },
        navigationIcon =
            {
                Image(
                    modifier = Modifier.size(15.dp),
                    painter = painterResource(id = R.drawable.icons8_lock),
                    contentDescription = "img_correo"
                )
            }
    )
}