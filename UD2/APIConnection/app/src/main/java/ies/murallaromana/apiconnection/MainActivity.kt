package ies.murallaromana.apiconnection

import ListaPersonajes
import ListaPersonajesScreen
import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.padding
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.tooling.preview.Preview
import androidx.navigation3.runtime.entryProvider
import androidx.navigation3.runtime.rememberNavBackStack
import androidx.navigation3.ui.NavDisplay
import ies.murallaromana.apiconnection.ui.theme.APIConnectionTheme

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            APIConnectionTheme {
                Scaffold(modifier = Modifier.fillMaxSize()) { innerPadding ->
                    Navegacion(modifier = Modifier.padding(innerPadding))
                }
            }
        }
    }
}

@Composable
fun Navegacion(modifier: Modifier) {
    val backStack = rememberNavBackStack(elements = arrayOf(ListaPersonajes))

    NavDisplay(
        modifier = modifier,
        backStack = backStack,
        onBack = {  },
        entryProvider = entryProvider {
            entry<ListaPersonajes> {
                ListaPersonajesScreen()
            }
        }
    )
}
