package es.murallaromana.testcompose2

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.shape.CircleShape
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import androidx.navigation3.runtime.entryProvider
import androidx.navigation3.runtime.rememberNavBackStack
import androidx.navigation3.ui.NavDisplay
import es.murallaromana.testcompose2.ui.nav.PrimeraPantalla
import es.murallaromana.testcompose2.ui.nav.SegundaPantalla
import es.murallaromana.testcompose2.ui.screens.MiPrimeraPantalla
import es.murallaromana.testcompose2.ui.screens.MiSegundaPantalla
import es.murallaromana.testcompose2.ui.theme.TestCompose2Theme

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            TestCompose2Theme {
                val backStack = rememberNavBackStack(PrimeraPantalla)
                NavDisplay(
                    backStack = backStack,
                    onBack = {backStack.removeLastOrNull()},
                    entryProvider = entryProvider{
                        entry<PrimeraPantalla>{
                            MiPrimeraPantalla {
                                backStack.add(SegundaPantalla)
                            }
                        }
                        entry<SegundaPantalla> {
                            MiSegundaPantalla {
                                backStack.add(PrimeraPantalla)
                            }
                        }
                    }
                )
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

