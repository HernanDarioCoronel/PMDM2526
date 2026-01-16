package es.murallaromana.testcompose

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.width
import androidx.compose.foundation.shape.CircleShape
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.font.FontStyle
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import es.murallaromana.testcompose.ui.theme.TestComposeTheme
import es.murallaromana.testcompose.ui.theme.components.MiTopBar
import es.murallaromana.testcompose.ui.theme.components.MisTextField
import es.murallaromana.testcompose.ui.theme.layouts.MiColumna

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            TestComposeTheme {
                Scaffold(
                    modifier = Modifier.fillMaxSize(),
                    containerColor = Color.LightGray,
                    topBar = { MiTopBar(modifier = Modifier) }

                ) { innerPadding ->
                    MisTextField(modifier = Modifier.padding(innerPadding))
                }

            }
        }
    }


    @Preview(showSystemUi = true)
    @Composable
    fun MostrarTexto() {
        Text(
            text = "Hola Mundo",
            modifier = Modifier
                .height(180.dp)
                .padding(top = 36.dp)
                .fillMaxWidth()
                .clip(CircleShape)
                .background(Color.Red),

            fontSize = 25.sp,
            textAlign = TextAlign.Center
        )
    }
}